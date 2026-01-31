using System;
using System.Collections.Generic;

using Exiled.API.Features;

using PlayerRoles;

namespace OverwatchLogger.Structs
{
    public struct RoleAliveCounter
    {
        public string Tracked { get; private set; }

        public Dictionary<RoleTypeId, int> TotalSeconds { get; private set; }

        public RoleAliveCounter(Player player)
        {
            Tracked = player.Nickname;
            TotalSeconds = new();
        }

        public void AppendTime(RoleTypeId role, TimeSpan time)
        {
            if (!TotalSeconds.ContainsKey(role))
            {
                TotalSeconds.Add(role, (int)time.TotalSeconds);
                return;
            }
            TotalSeconds[role] += (int)time.TotalSeconds;
        }

        public void AppendTime(RoleTypeId role, DateTime start, DateTime end)
        {
            AppendTime(role, (end - start));
        }

        public void AppendTime(RoleTypeId role, int seconds) => AppendTime(role, TimeSpan.FromSeconds(seconds));

        public static (int hours, int minutes, int seconds) GetHoursMinutesSeconds(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int remainingSecondsAfterHours = totalSeconds % 3600;
            int minutes = remainingSecondsAfterHours / 60;
            int seconds = remainingSecondsAfterHours % 60;
            return (hours, minutes, seconds);
        }
    }
}
