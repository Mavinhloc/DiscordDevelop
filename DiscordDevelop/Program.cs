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
}