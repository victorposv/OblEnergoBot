using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot
{
    public class Main
    {
        public const string HTTP_TOKEN = "5038476140:AAE_bL-kMBGZl3INsiXTh-fU7qpOQdNyMAE";

        private TelegramBotClient botClient;

        public Main()
        {
            botClient = new TelegramBotClient(HTTP_TOKEN);
        }

        public void HelloWorldMethod()
        {
            var me = botClient.GetMeAsync();

            Console.WriteLine(me.Id);
        }

        public async Task RespFromTelegram(Update update)
        {
            if (update == null)
            {
                return;
            }
            if (update.Type != UpdateType.Message)
            {
                return;
            }
            var message = update.Message;

            switch (message.Type)
            {
                case MessageType.Text:
                    // Echo each Message
                    await this.botClient.SendTextMessageAsync(message.Chat.Id, message.Text);
                    break;
                default:
                    break;
            }
        }
    }
}
