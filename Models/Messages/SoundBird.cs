using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegrammBot.Models.Messages
{
    class SoundBird : AMessage
    {
        public async override void Execute(Message m, ITelegramBotClient client)
        {
            await client.SendVideoAsync(chatId: m.Chat, video: "https://vk.com/doc41062647_525084679", caption: "Nostalgi");
        }

        public override void Execute(Message m, ITelegramBotClient client, User user)
        {
            Execute(m, client);
        }
    }
}
