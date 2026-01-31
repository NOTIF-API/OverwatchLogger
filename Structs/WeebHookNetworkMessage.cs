using Newtonsoft.Json;

namespace OverwatchLogger.Structs
{
    public struct WeebHookNetworkMessage
    {
        public string content { get; set; }
        public string username { get; set; }
        public string avatar_url { get; set; }

        public WeebHookNetworkMessage(string content, string username, string avatar_uri)
        {
            this.content = content;
            this.username = string.IsNullOrWhiteSpace(username) ? "" : username;
            avatar_url = string.IsNullOrWhiteSpace(avatar_uri) ? "" : avatar_uri;
        }
    }
}