using System.Collections.Generic;
using System.ComponentModel;

using Exiled.API.Interfaces;

using OverwatchLogger.Serelizables;

using PlayerRoles;

namespace OverwatchLogger
{
    public class Config: IConfig
    {
        [Description("Will the plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Will debug messages be visible?")]
        public bool Debug { get; set; } = true;
        [Description("Hook settings")]
        public WeebHookSerelizable Hook { get; set; } = new()
        {
            HookName="Role enter time logger"
        };
        [Description("Settings for display message in weebhook")]
        public LogMessagesSerelizable LogMessages { get; set; } = new();
        [Description("List roles for display assgned round time")]
        public List<RoleTypeId> TrackedRoles { get; set; } = new()
        {
            RoleTypeId.Overwatch,
            RoleTypeId.Tutorial
        };
        [Description("Will the plugin only log server staff")]
        public bool LogOnlyStaffRoles { get; set; } = false;
        [Description("Groups to be ignored (only if staff logging is enabled)")]
        public List<string> IgnoredGroups { get; set; } = new()
        {
            "owner"
        };
    }
}
