using System.ComponentModel;

using Exiled.API.Interfaces;

namespace OverwatchLogger
{
    public class Config: IConfig
    {
        [Description("Will the plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Will debug messages be visible?")]
        public bool Debug { get; set; } = true;
        [Description("Webhook link for sending messages")]
        public string WeebHookUrl { get; set; } = "";
        [Description("Overrides the webhook name (if left blank it uses the default one set in discord)")]
        public string WeebHookName { get; set; } = "";
        [Description("Overrides the webhook avatar (if left blank it uses the default one set in discord)")]
        public string WeebHookAvatarUrl { get; set; } = "";
        [Description("When the admin turns on the overmatch (any player who has been given this role)")]
        public string EnterMessage { get; set; } = "Staff %player% entered to overwatch mode.";
        [Description("When the admin turns off the overmatch (any player who was given this role)")]
        public string ExitMessage { get; set; } = "Staff %player% exited from overwatch mode.";
        [Description("Top message, displayed for the total (1 line)")]
        public string RoundEndSummary { get; set; } = "Round ended. Staff's who used overwatch";
        [Description("Message constructor for each player who turned on overmatch in the round")]
        public string StaffSummary { get; set; } = "[%player%] used overwatch %hours% %minutes% %seconds%";
        [Description("message replacement for %hours%, where %h% is the total number of hours (if = 0 then the message will not be output)")]
        public string Hhours { get; set; } = "%h% hours";
        [Description("message replacement for %minutes%, where %m% is the total number of minutes (if = 0 then the message will not appear)")]
        public string Mminutes { get; set; } = "%m% minutes";
        [Description("message replacement for %seconds%, where %s% is the final number of seconds (if = 0 then the message will not be output)")]
        public string Sseconds { get; set; } = "%s% seconds";
    }
}
