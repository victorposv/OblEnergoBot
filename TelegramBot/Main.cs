using System;
using Telegram.Bot;

namespace TelegramBot
{
    public class Main
    {
        public const string HTTP_TOKEN = "5038476140:AAE_bL-kMBGZl3INsiXTh-fU7qpOQdNyMAE";
        public void HelloWorldMethod()
        {
            var bot = new TelegramBotClient(HTTP_TOKEN);
            bot.SendTextMessageAsync("Hello World!");
        }
    }
}
