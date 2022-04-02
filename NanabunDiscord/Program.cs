
using NanabunDiscord.DiscordClient;
using NanabunDiscord.Modules;
using NanabunDiscord.Toolkit;

namespace NanabunDiscord
{
    class Program
    {
        public static void Main(string[] args)
        {
            var env = EnvironmentValue.Instance;
            env.PrepareEnvironment();

            Client.Instance.MainLoop(new MainModule()).GetAwaiter().GetResult();
            
            Task.Delay(-1).GetAwaiter().GetResult();
        }
    }
}