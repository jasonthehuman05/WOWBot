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
            Wow responseWow = WowFetcher.GetWow(); // Gets a wow from the API
            arg.RespondAsync("Working Command"); //Temp line, for command testing
            return Task.CompletedTask;
        }
    }
}
