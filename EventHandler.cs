using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;

using OverwatchLogger.Features;
using OverwatchLogger.Structs;

namespace OverwatchLogger
{
    public class EventHandler
    {

        public static Config Config
        {
            get
            {
                if (Plugin.Instance == null) return new();
                return Plugin.Instance.Config;
            }
        }

        public static void OnSpawned(SpawnedEventArgs e)
        {
            Config l = Config;
            if (e.Player == null) return;
            if (e.Player.SessionVariables.ContainsKey($"{e.OldRole.Type}-time"))
            {
                EnterHandler.AddPlayer(e.Player, e.OldRole, (DateTime)e.Player.SessionVariables[$"{e.OldRole.Type}-time"], DateTime.Now);
                e.Player.SessionVariables.Remove($"{e.OldRole.Type}-time");
                string exited = l.LogMessages.ExitedMessage.Replace("%player%", e.Player.Nickname).Replace("%role%", e.OldRole.Type.ToString());
                HookHelper.AddLogMessage(exited, l.Hook);
            }
            if (l.TrackedRoles.Contains(e.Player.Role.Type))
            {
                if (Config.LogOnlyStaffRoles)
                {
                    if (e.Player.Group == null) return;
                    if (Config.IgnoredGroups.Contains(e.Player.Group.Name)) return;
                }
                string entered = l.LogMessages.EnteredMessage.Replace("%player%", e.Player.Nickname).Replace("%role%", e.Player.Role.Type.ToString());
                HookHelper.AddLogMessage(entered, l.Hook);
                if (!e.Player.SessionVariables.ContainsKey($"{e.Player.Role.Type}-time")) e.Player.SessionVariables[$"{e.Player.Role.Type}-time"] = DateTime.Now;
            }
        }

        public static void OnWaitingForPlayers()
        {
            EnterHandler.Counters.Clear();
        }

        public static void OnRoundEnded(RoundEndedEventArgs e)
        {
            foreach (var item in Player.List.Where(x => Config.TrackedRoles.Contains(x.Role.Type)))
            {
                if (item.SessionVariables.ContainsKey($"{item.Role.Type}-time"))
                {
                    EnterHandler.AddPlayer(item, item.Role, (DateTime)item.SessionVariables[$"{item.Role.Type}-time"], DateTime.Now); // force calculate round time
                    item.SessionVariables.Remove($"{item.Role.Type}-time");
                }
            }
            StringBuilder rs = new();
            foreach (RoleAliveCounter item in EnterHandler.Counters)
            {
                foreach (var item1 in item.TotalSeconds)
                {
                    Log.Debug($"[OnRoundEnded] Handling line for {item1.Key} and value {item1.Value} for {item.Tracked}");
                    var count = RoleAliveCounter.GetHoursMinutesSeconds(item1.Value);
                    rs.AppendLine(Config.LogMessages.Summary
                        .Replace("%player%", item.Tracked)
                        .Replace("%role%", item1.Key.ToString())
                        .Replace("%hours%", Config.LogMessages.Hours.Replace("%count%", $"{count.hours}"))
                        .Replace("%minutes%", Config.LogMessages.Minutes.Replace("%count%", $"{count.minutes}"))
                        .Replace("%seconds%", Config.LogMessages.Seconds.Replace("%count%", $"{count.seconds}"))
                        );
                }
            }
            string msg = Config.LogMessages.SummaryInfo.Replace("%summary%", rs.ToString());
            Log.Debug($"[OnRoundEnded] Result game message: {msg}");
            HookHelper.AddLogMessage(msg, Config.Hook);
        }
    }
}