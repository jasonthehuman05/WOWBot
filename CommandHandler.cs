using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WOWBot
{
    class CommandHandler
    {
        public CommandHandler()
        {

        }

        public async Task<SlashCommandProperties> LoadCommands()
        {
            //Creates the command and assigns the informaiton needed
            SlashCommandBuilder commandBuilder = new SlashCommandBuilder();

            commandBuilder.WithName("wow");
            commandBuilder.WithDescription("Finds a random clip of owen wilson saying WOW.");

            //Builds it to be added
            SlashCommandProperties scp = commandBuilder.Build();

            return scp;
        }

        public async Task<Task> CommandExecuted(SocketSlashCommand arg)
        {
            await DoAction(arg);

            return Task.CompletedTask;
        }

        public async Task<Task> DoAction(SocketSlashCommand arg)
        {
            arg.DeferAsync();
            List<Wow> responseWow = WowFetcher.GetWow(); // Gets a wow from the API

            string url = Shortener.ShortenUrl(responseWow[0].video._1080p);

            //await arg.RespondAsync(url);
            await arg.FollowupAsync(url);

            return Task.CompletedTask;
        }
    }
}
