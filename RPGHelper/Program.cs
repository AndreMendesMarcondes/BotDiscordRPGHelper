using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace RPGHelper
{
    public class Program
    {
        static void Main(string[] args)
                => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandHandler _handler;

        public async Task StartAsync()
        {
           
            Console.WriteLine("Começou");
            _client = new DiscordSocketClient();

            await _client.LoginAsync(TokenType.Bot, "Token");

            await _client.StartAsync();

            _handler = new CommandHandler(_client);

            Console.WriteLine("Esperando");
            await Task.Delay(-1);
            Console.WriteLine("Parou");
        }
    }
}
