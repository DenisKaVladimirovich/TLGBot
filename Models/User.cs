using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegrammBot.Models
{
    public class User
    {
        private long id;
        public long UserID { get { return this.id; } }
        private ITelegramBotClient _client;
        private string lastMessage;
        public string Name { get; set; }
        public User(ITelegramBotClient botClient, long id)
        {
            this.id = id;
            this._client = botClient;
            
        }



        public void HandleMessage(Message m) {
            
            if (m.Text != null)
            {
                if (lastMessage == "/start"&&this.Name==null)
                {
                    this.Name = m.Text;
                    _client.SendTextMessageAsync(chatId: m.Chat.Id, text: $"Hello my dear {this.Name}");
                }
                else if (TBot.messages.ContainsKey(m.Text))
                {
                    lastMessage = m.Text;
                    TBot.messages[m.Text].Execute(m, _client, this);
                    
                }
                else
                {
                    _client.SendTextMessageAsync(chatId: m.Chat.Id, text: $"Command not found");
                }
            }
            Console.WriteLine(lastMessage);
        }
    }
}
