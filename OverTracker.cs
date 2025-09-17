using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;

namespace OverwatchLogger
{
    public class OverTracker
    {
        private Dictionary<string, int> PlayerOvermatchUsed { get; set; } = new Dictionary<string, int>();

        private Dictionary<string, DateTime> OverwachEnabled { get; set; } = new Dictionary<string, DateTime>();

        public IReadOnlyDictionary<string, int> PlayerOverwatch => PlayerOvermatchUsed;

        public void UpdateTime(Player player, int time)
        {
            UpdateTime(player.DisplayNickname, time);
        }

        public void UpdateTime(string player, int time)
        {
            if (!PlayerOvermatchUsed.ContainsKey(player))
            {
                PlayerOvermatchUsed.Add(player, time);
                return;
            }
            PlayerOvermatchUsed[player] += time;
        }

        public void OnOverwactEnabled(ChangingRoleEventArgs e)
        {
            if (!e.IsAllowed) return;
            if (e.NewRole == PlayerRoles.RoleTypeId.Overwatch)
            {
                Plugin.Instance.whook.SendMessage(Plugin.Instance.Config.EnterMessage.Replace("%player%", e.Player.DisplayNickname));
                OverwachEnabled[e.Player.DisplayNickname] = DateTime.Now;
                return;
            }
            if (e.NewRole != PlayerRoles.RoleTypeId.Overwatch && OverwachEnabled.ContainsKey(e.Player.DisplayNickname))
            {
                Plugin.Instance.whook.SendMessage(Plugin.Instance.Config.ExitMessage.Replace("%player%", e.Player.DisplayNickname));
                int time = Math.Abs((int)(DateTime.Now - OverwachEnabled[e.Player.DisplayNickname]).TotalSeconds);
                UpdateTime(e.Player, time);
                OverwachEnabled.Remove(e.Player.DisplayNickname);
                return;
            }
        }

        public void OnWaitingForPlayers()
        {
            PlayerOvermatchUsed.Clear();
            OverwachEnabled.Clear();
        }

        public void OnPlayerVerefied(VerifiedEventArgs e)
        {
            if (e.Player.Role.Type == PlayerRoles.RoleTypeId.Overwatch) e.Player.Role.Set(PlayerRoles.RoleTypeId.Spectator);
        }

        public void OnRoundEnded(RoundEndedEventArgs e)
        {
            Config cfg = Plugin.Instance.Config;
            foreach (KeyValuePair<string, DateTime> item in OverwachEnabled)
            {
                UpdateTime(item.Key, (int)(DateTime.Now-item.Value).TotalSeconds);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(cfg.RoundEndSummary);
            foreach (KeyValuePair<string, int> item in PlayerOvermatchUsed)
            {
                string m = cfg.StaffSummary;
                (int hours, int minutes, int seconds) a = GetHoursMinutesSeconds(item.Value);
                m = m.Replace("%player%", item.Key);
                m = m.Replace("%hours%", a.hours == 0 ? string.Empty : cfg.Hhours.Replace("%h%", a.hours.ToString()));
                m = m.Replace("%minutes%", a.minutes == 0 ? string.Empty : cfg.Mminutes.Replace("%m%", a.minutes.ToString()));
                m = m.Replace("%seconds%", a.seconds == 0 ? string.Empty : cfg.Sseconds.Replace("%s%", a.seconds.ToString()));
                sb.AppendLine(m);
            }
            if (PlayerOvermatchUsed.Count > 0)
            {
                Plugin.Instance.whook.SendMessage(sb.ToString());
            }
            PlayerOvermatchUsed.Clear();
            OverwachEnabled.Clear();
        }

        public (int hours, int minutes, int seconds) GetHoursMinutesSeconds(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int remainingSecondsAfterHours = totalSeconds % 3600;
            int minutes = remainingSecondsAfterHours / 60;
            int seconds = remainingSecondsAfterHours % 60;
            return (hours, minutes, seconds);
        }
    }
}
