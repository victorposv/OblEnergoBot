using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class Main
    {
        public const string HTTP_TOKEN = "5038476140:AAE_bL-kMBGZl3INsiXTh-fU7qpOQdNyMAE";

        private TelegramBotClient botClient;
        

    public Main()
        {

        }

        public void HelloWorldMethod()
        {
            ReceiverOptions receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };

            using var cts = new CancellationTokenSource();
            botClient = new TelegramBotClient(HTTP_TOKEN);


            botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cts.Token);

            var me = botClient.GetMeAsync();
            
            Console.WriteLine(me.Id);

            Console.WriteLine($"Start listening for @{me.Result.FirstName}");
            Console.ReadLine();

            cts.Cancel();
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Type != UpdateType.Message)
                return;
            // Only process text messages
            if (update.Message!.Type != MessageType.Text)
                return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;
            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");


            string reply = "Привіт! Я бот, що дає змогу дізнатись про планові та аварійні відключення, що проводяться ТернопільОблЕнерго\n" +
                $"Ось список доступних команд {string.Empty}\n" +
                 "Для початку роботи, введіть /start";


            
            /*
            var rkm = new ReplyKeyboardMarkup(new KeyboardButton[][]
              {
            new KeyboardButton[]
              {
            new KeyboardButton("item"),
            new KeyboardButton("item")
                },
            new KeyboardButton[]
             {
            new KeyboardButton("item")
              }
               });

            */

            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: reply,
                cancellationToken: cancellationToken);
            
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private string CheckMessageForCommand(string message)
        {
            return string.Empty;
        }
    }
}
