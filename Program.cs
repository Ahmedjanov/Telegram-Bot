

using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace TelegramBot
{
    internal class Program
    {
        private static string token { get; set; } = "5793069579:AAEaD0Y2aPymYy7VZd3JwUwhL1wLIg7jGDs";
        private static TelegramBotClient Bot { get; set; }
        static void Main(string[] args)
        {
            Bot = new TelegramBotClient(token);

            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = { }
            };

            Bot.StartReceiving(Handlers.HandleUpdateAsync,
                               Handlers.HandleErrorAsync,
                               receiverOptions,
                               cts.Token);

            Console.WriteLine($"Бот запущен и ждет сообщения...");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();
        }
    }
}