using System.Text;
using dotenv.net;

namespace NanabunDiscord.Toolkit;

public class EnvironmentValue
{
    private static readonly EnvironmentValue instance = new();

    public static EnvironmentValue Instance => instance;

    public void PrepareEnvironment()
    {
        //Check if .env file was not created
        if (!File.Exists($"{Environment.CurrentDirectory}/.env"))
        {
            ReadOnlySpan<char> contents = "DISCORD_API_KEY=\"\"\nSERVER_ID=\"\"";
            using (var file = new StreamWriter($"{Environment.CurrentDirectory}/.env"))
            {
                file.Write(contents);
            }
        }

        DotEnv.Load();
    }

    public string GetValue(string Key)
    {
        IDictionary<string, string> keys = DotEnv.Read();

        return keys[Key];
    }
}