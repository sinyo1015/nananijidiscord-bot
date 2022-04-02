using Discord;
using Discord.WebSocket;
using NanabunDiscord.Interfaces;
using NanabunDiscord.Toolkit;

namespace NanabunDiscord.DiscordClient;

public class Client
{
    private static readonly Client instance = new();

    public static Client Instance => instance;
    private static DiscordSocketClient DiscordClient = new();

    public async Task MainLoop(IRunnableMain main)
    {
        DiscordClient.Log += Logger;

        string token = EnvironmentValue.Instance.GetValue("DISCORD_API_KEY");

        await DiscordClient.LoginAsync(TokenType.Bot, token);
        await DiscordClient.StartAsync();

        DiscordClient.Ready += async () =>
        {
            await main.Run();
        };
    }

    private Task Logger(LogMessage message)
    {
        Console.WriteLine(message);
        return Task.CompletedTask;
    }
}