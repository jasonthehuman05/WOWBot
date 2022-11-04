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
            List<Wow> responseWow = WowFetcher.GetWow(); // Gets a wow from the API

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle($"{responseWow[0].character} in {responseWow[0].movie}");
            //eb.WithUrl(responseWow[0].video._1080p);
            eb.WithDescription(responseWow[0].video._1080p);

            Embed e = eb.Build();

            arg.RespondAsync(embed: e);

            return Task.CompletedTask;
        }
    }
}
