using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace WOWBot
{
    internal class Program
    {
        public static DiscordSocketClient client;
        static string token = File.ReadAllText("token.txt");

        static void Main(string[] args)
        {
            MainAsyncProcess();
            while (true) ;
        }

        static async void MainAsyncProcess()
        {
            Console.WriteLine("========Discord WOWBot v1========\nBy Jason Chesters-salt");
            Console.WriteLine("Attempting to open connection to Discord...");

            //Create the discord client and wire up all needed events
            client = new DiscordSocketClient();
            client.Log += DiscordLog;
            client.Disconnected += ConnectionLost;
            client.Ready += BotReady;
            client.MessageReceived += NewMessage;
            //Attempt first log in
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            //Do nothing until program is closed
            await Task.Delay(-1);
            await client.StopAsync();
            client.Dispose();
        }

        private static Task NewMessage(SocketMessage arg)
        {
            Console.WriteLine($"{arg.Channel}/{arg.Author} == {arg.Content}");
            return Task.CompletedTask;
        }

        private static async Task BotReady()
        {
            Console.WriteLine("Bot Ready!");
        }

        private static Task ConnectionLost(Exception arg) //Reconnects the bot
        {
            Console.WriteLine("BOT ATTEMPTING TO RECONNECT!");
            ConnectBot();
            return Task.CompletedTask;
        }

        static async void ConnectBot() //Establishes connection to discord
        {
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
        }

        private static Task DiscordLog(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }
    }
}
