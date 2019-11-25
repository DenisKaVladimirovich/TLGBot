using Telegram.Bot.Types;

namespace TelegrammBot.Models
{
    public abstract class AMessage
    {
        public abstract void Execute(Message m, Telegram.Bot.ITelegramBotClient client);
        public abstract void Execute(Message m, Telegram.Bot.ITelegramBotClient client, User user);
    }
}
