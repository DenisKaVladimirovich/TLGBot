using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegrammBot.Models;
using System.Linq;
using TelegrammBot.Models.Messages;
using System.Threading;

namespace TelegrammBot
{
    class TBot
    {
        static ITelegramBotClient botClient;
        static List<User> users = new List<User>();
        public static Dictionary<string, AMessage> messages = new Dictionary<string, AMessage>();
        private bool working = true;
        public TBot()
        {
            messages.Add("/hello", new HelloMessage());
            messages.Add("/time", new TimeClass());
            messages.Add("/img", new ImgHandler());
            messages.Add("/sound", new SoundBird());
            messages.Add("/start", new StartHandler());
        }

        public void Run()
        {
            botClient = new TelegramBotClient(AppSettings.Key);
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"I'm started."
            );
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            while (working) {
                Console.WriteLine("Type command");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "/users":
                        foreach(User u in users)
                        {
                            Console.Write($"{u.Name};");
                        }
                        Console.WriteLine();
                        break;
                    case "/exit":
                        Exit();
                        break;
                    case "/post":
                        SendPost();
                        break;
                    default:
                        Console.WriteLine("Command not recognised");
                        break;
                }
            }
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            User user = users.Where(p => p.UserID == e.Message.Chat.Id).FirstOrDefault();
            if (user != null)
            {
                if (e.Message.Text != "/start")
                {
                    user.HandleMessage(e.Message);
                }
                else
                {
                    await botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, text: $"Вы уже начали диалог");
                }
                
            }
            else
            {
                User _user = new User(botClient, e.Message.Chat.Id);
                users.Add(_user);
                _user.HandleMessage(e.Message);
            }
        }


        async void SendPost() {
            Console.WriteLine("Введите имя новости");
            string title = Console.ReadLine();
            Console.WriteLine("Введите текст новости");
            string text = Console.ReadLine();
            if (title != string.Empty && text != string.Empty)
            {
                Console.WriteLine("начали отправку");
                foreach (User u in users)
                {
                    Console.WriteLine(u.Name);
                    await botClient.SendTextMessageAsync(chatId: u.UserID, text: $"<strong>{title}</strong>.\n <i>{text}</i>", parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
                }
            }
        }

        async void Exit()
        {
            Console.Write("Вы действительно хотите выйти(y or no): ");
            string answer = Console.ReadLine().ToLower();
            if(answer=="y"|| answer == "yes")
            {
                foreach (User u in users)
                {
                    await botClient.SendTextMessageAsync(chatId: u.UserID, text: $"<b>Бот пошел спать</b>", parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
                }
                Console.WriteLine("Bot goes to sleep... ZZzzzz");
                Thread.Sleep(300);
                Console.WriteLine("Procces is shutdown");
                Thread.Sleep(500);
            }
        }
    }
}
