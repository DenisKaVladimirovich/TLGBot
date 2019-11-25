using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegrammBot.Models.Messages
{
    class StartHandler : AMessage
    {
        private User user;
            
        public async override void Execute(Message m, ITelegramBotClient client, User user)
        {
          await client.SendTextMessageAsync(chatId: m.Chat.Id, text: "Введите свое имя:");
        }

        public override void Execute(Message m, ITelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
