using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

using Exiled.API.Features;

using Newtonsoft.Json;

using OverwatchLogger.Structs;

namespace OverwatchLogger.Serelizables{
    public class WeebHookSerelizable
    {
        private static HttpClient Client { get; } = new();

        [Description("Link to the webhook through which the message will be sent")]
        public string HookUrl { get; set; } = "";
        [Description("Link to webhook avatar (can be left blank, in which case the avatar posted on Discord will be used)")]
        public string HookAvatar { get; set; } = "";
        [Description("Webhook name, used to separate the message with a name (empty form field = name configured in Discord)")]
        public string HookName { get; set; } = "";

        public void SendMessage(WeebHookNetworkMessage message)
        {
            if (string.IsNullOrEmpty(HookUrl))
            {
                Log.Warn("Any hook not have specifiq url");
                return;
            }
            try
            {
                Task.Run(async () =>
                {
                    string content = JsonConvert.SerializeObject(message);
                    await Client.PostAsync(HookUrl, new StringContent(content, System.Text.Encoding.UTF8, "application/json"));
                    Log.Debug($"[SendMessage] Sended WeenHook message with lenght {content.Length}");
                });
            }
            catch (Exception e)
            {
                Log.Debug($"[SendMessage] Error while send or parse network message {e.Message}");
            }
        }

        public void SendMessage(string content, string userName = "", string avatar = "")
        {
            if (content.Length > 1900) return;
            WeebHookNetworkMessage msg = new(content, userName, avatar);
            SendMessage(msg);
        }
    }
}
