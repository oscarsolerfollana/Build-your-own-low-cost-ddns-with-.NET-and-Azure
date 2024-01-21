using ddns.Models;
using System.Text.Json;

namespace ddns
{
    public static class Settings
    {
        private static SettingsModel settings=new SettingsModel()
        {
            Credentials= new Credentials() { }
        };

        public static bool Initialize()
        {
            if (File.Exists("config.json"))
            {
                string jsonContent = File.ReadAllText("config.json");
                settings = JsonSerializer.Deserialize<SettingsModel>(jsonContent);
                return true;
            }
            return false;
        }
        public static void SaveIp(string ip)
        {
            settings.Ip=ip;
            string jsonContent = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("config.json", jsonContent);
        }
        public static string ReadIp()
        {
            return settings.Ip;
        }

        public static void SaveCredentials(Credentials credentials)
        {
            settings.Credentials=credentials;
            string jsonContent = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("config.json", jsonContent);
        }

        public static Credentials ReadCredentials()
        {
            return settings.Credentials;
        }

        public static bool IsConfigured()
        {
            return File.Exists("config.json");
        }
    }
}
