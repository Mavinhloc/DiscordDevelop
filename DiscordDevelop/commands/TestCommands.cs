using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDevelop.commands
{
    public class TestCommands : BaseCommandModule
    {
        [Command("test")]
        public async Task FirstCommand(CommandContext context)
        {
            await context.Channel.SendMessageAsync($"Hello {context.User.Username}");
        }

        [Command("Yo")]
        public async Task ThirdCommand(CommandContext context)
        {
            await context.RespondAsync("whatsup");
        }
        public static void RegisterEvents(DiscordClient client)
        {
            client.MessageCreated += OnMessage;
        }
        public static async Task OnMessage(DiscordClient sender, MessageCreateEventArgs e)
        {
            // Check if the message content contains the word "Minh"
            if (e.Message.Content.ToLower() == "minh")
            {
                // Respond with "Lưới"
                await e.Message.RespondAsync("Lưới");
            }
        }

    }
}
