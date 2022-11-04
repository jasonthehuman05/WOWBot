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
            SlashCommandBuilder commandBuilder = new SlashCommandBuilder();

            commandBuilder.WithName("wow");
            commandBuilder.WithDescription("Finds a random clip of owen wilson saying WOW.");

            SlashCommandProperties scp = commandBuilder.Build();

            return scp;
        }

        public async Task<Task> CommandExecuted(SocketSlashCommand arg)
        {
            arg.RespondAsync("Working Command");
            return Task.CompletedTask;
        }
    }
}
