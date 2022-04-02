using NanabunDiscord.Interfaces;

namespace NanabunDiscord.Modules;

public class MainModule : IRunnableMain
{
    public Task Run()
    {
        Console.WriteLine("Logged In!");
        
        return Task.CompletedTask;
    }
}