using Newtonsoft.Json;

namespace OverwatchLogger.Features
{
    public struct NetworkMessage
    {
        public string content { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string username { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string avatar_url { get; set; }

        public NetworkMessage(string content, string username, string avatar_uri)
        {
            this.content = content;
            this.username = string.IsNullOrWhiteSpace(username) ? null : username;
            avatar_url = string.IsNullOrWhiteSpace(avatar_uri) ? null : avatar_uri;
        }
    }
}