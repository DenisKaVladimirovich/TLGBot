using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegrammBot.Models.Messages
{
    class ImgHandler : AMessage
    {
        public async override void Execute(Message m, ITelegramBotClient client)
        {
            await client.SendPhotoAsync(
            chatId: m.Chat,
            photo: "https://telegrambots.github.io/book/2/docs/shot-photo_msg.jpg",
            caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
            parseMode: ParseMode.Html
);
        }

        public override void Execute(Message m, ITelegramBotClient client, User user)
        {
            Execute(m, client);
        }
    }
}
