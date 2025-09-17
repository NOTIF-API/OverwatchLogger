using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Exiled.API.Features;

using Newtonsoft.Json;

namespace OverwatchLogger.Features
{
    public class WeebHookClient
    {
        private string WeebhookUrl { get; set; }
        private string DefaultName { get; set; }
        private string DefaultAvatar { get; set; }

        public WeebHookClient(string weebhookUrl, string defaultName = "", string defaultAvatar = "")
        {
            WeebhookUrl = weebhookUrl;
            DefaultName = defaultName;
            DefaultAvatar = defaultAvatar;
        }

        public void SendMessage(string message)
        {
            string formated = message.Replace("\n", "\\n");
            NetworkMessage msg = new NetworkMessage(message, DefaultName, DefaultAvatar);
            string msgS = JsonConvert.SerializeObject(msg);
            Log.Debug(msgS);
            Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage res = await client.PostAsync(WeebhookUrl, new StringContent(msgS, Encoding.UTF8, "application/json"));
                        Log.Debug($"{nameof(SendMessage)}: Status({res.StatusCode}) Content({res.Content})");
                    }
                    catch (Exception e)
                    {
                        Log.Debug($"{nameof(SendMessage)}: {e}");
                    }
                }
            });
        }

        public void SendMessage(string message, string name, string avatar)
        {
            string formated = message.Replace("\n", "\\n");
            NetworkMessage msg = new NetworkMessage(message, name, avatar);
            string msgS = JsonConvert.SerializeObject(msg);
            Log.Debug(msgS);
            Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage res = await client.PostAsync(WeebhookUrl, new StringContent(msgS, Encoding.UTF8, "application/json"));
                        Log.Debug($"{nameof(SendMessage)}: Status({res.StatusCode}) Content({res.Content})");
                    }
                    catch (Exception e)
                    {
                        Log.Debug($"{nameof(SendMessage)}: {e}");
                    }
                }
            });
        }
    }
}
