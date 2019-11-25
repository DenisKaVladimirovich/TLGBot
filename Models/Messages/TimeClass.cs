using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegrammBot.Models.Messages
{
    class TimeClass : AMessage
    {
        public async override void Execute(Message m, ITelegramBotClient client)
        {
            await client.SendTextMessageAsync(chatId: m.Chat.Id, text: $"Сейчас {DateTime.Now.ToString("dddd, dd MMMM yyyy")}");
        }

        public override void Execute(Message m, ITelegramBotClient client, User user)
        {
            Execute(m, client);
        }
    }
}
