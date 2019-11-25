using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegrammBot.Models.Messages
{
    class HelloMessage : AMessage
    {
        public override async void Execute(Message m, ITelegramBotClient client)
        {
            await client.SendTextMessageAsync(chatId: m.Chat.Id, text: "Hello. I'm zerno bot");
        }

        public override void Execute(Message m, ITelegramBotClient client, User user)
        {
            Execute(m, client);
        }
    }
}
