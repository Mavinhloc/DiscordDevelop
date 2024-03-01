using DiscordDevelop.commands;
using DiscordDevelop.config;
using DSharpPlus;
using DSharpPlus.CommandsNext;

public class Program
{
    private static DiscordClient Client {get; set;}
    private static CommandsNextExtension Commands { get; set; }
    public static async Task Main()
    {
        var jsonReader = new JSONReader();
        await jsonReader.ReadJSON();

        var discordConfig = new DiscordConfiguration()
        {
            Intents = DiscordIntents.All,
            Token = jsonReader.token,
            TokenType = TokenType.Bot,
            AutoReconnect = true,
        };

        Client = new DiscordClient(discordConfig);

        Client.Ready += Client_Ready;
        Client.GuildMemberRemoved += Client_GuildMemberRemoved;
        Client.GuildBanAdded += Client_GuildBanAdded;

        var commandsConfig = new CommandsNextConfiguration()
        {
            StringPrefixes = new string[] {jsonReader.prefix},
            EnableMentionPrefix = true,
            EnableDms = true,
            EnableDefaultHelp = true,
        };

        Commands = Client.UseCommandsNext(commandsConfig);

        Commands.RegisterCommands<TestCommands>();
        TestCommands.RegisterEvents(Client);

        await Client.ConnectAsync();
        await Task.Delay(-1);
    }

    private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
    {
        return Task.CompletedTask;
    }
    private static async Task Client_GuildMemberRemoved(DiscordClient sender, DSharpPlus.EventArgs.GuildMemberRemoveEventArgs args)
    {
        var guild = args.Guild;
        var channel = await sender.GetChannelAsync(1073548515151708161); // Replace CHANNEL_ID with the ID of the channel where you want to send the message
        await channel.SendMessageAsync($"Địt con mẹ thằng {args.Member.Username} nó bỏ rồi ae ơi."); // Send a message to the specified channel when a member leaves
    }
    private static async Task Client_GuildBanAdded(DiscordClient sender, DSharpPlus.EventArgs.GuildBanAddEventArgs args)
    {
        var guild = args.Guild;
        var channel = await sender.GetChannelAsync(1073548515151708161); // Replace CHANNEL_ID with the ID of the channel where you want to send the message
        await channel.SendMessageAsync($"Thằng {args.Member.Username} láo quá nên Kick."); // Send a message to the specified channel when a member is kicked
    }
}