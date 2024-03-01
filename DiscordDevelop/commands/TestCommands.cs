using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
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

        [Command("Sus")]
        public async Task SusCommand(CommandContext context)
        {
            var message = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder().WithTimestamp(DateTime.UtcNow)
                .WithDescription("⬛⬛⬛⬛⬛⬛\r\n⬛\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5⬛\r\n⬛⬛⬛⬛⬛\U0001f7e5\U0001f7e5⬛⬛\r\n⬛\U0001f7e6\U0001f7e6\U0001f7e6\U0001f7e6⬛\U0001f7e5⬛\U0001f7e5⬛\r\n⬛\U0001f7e6\U0001f7e6\U0001f7e6⬛\U0001f7e5\U0001f7e5⬛\U0001f7e5⬛\r\n‍‌‍‌‍‌‍‌‍‌‍‌‌‍‍‍‍‌‍‌‍‌‍‌‍‌‍‌⬛⬛⬛⬛\U0001f7e5\U0001f7e5\U0001f7e5⬛\U0001f7e5⬛\r\n⬛\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5⬛\U0001f7e5⬛\r\n⬛\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5⬛\U0001f7e5⬛\r\n⬛\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5\U0001f7e5⬛⬛\r\n⬛\U0001f7e5\U0001f7e5⬛⬛\U0001f7e5\U0001f7e5⬛\r\n⬛\U0001f7e5\U0001f7e5⬛⬛\U0001f7e5\U0001f7e5⬛")
                );

            await context.Channel.SendMessageAsync(message);
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

            //// Check if the message content contains the word "tranf"
            //if (e.Message.Content.ToLower().Contains("trang"))
            //{
            //    // Replace "stickerId" with the ID of your sticker in the Discord server
            //    ulong stickerId = 1212975821187194881;

            //    // Send the sticker as a response
            //    await e.Message.RespondAsync($"<:{stickerId}>");
            //}
        }
    }
}
