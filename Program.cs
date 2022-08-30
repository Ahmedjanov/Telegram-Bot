

using System.Text;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace TelegramBot
{
    internal class Program
    {
        private static string token { get; set; } 
        private static TelegramBotClient Bot { get; set; }

        static void Main(string[] args)
        {
            using (var sr = new StreamReader("Token.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    token = sr.ReadLine();
                }
            }
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