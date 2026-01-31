using System;
using System.Collections.Generic;
using System.Linq;

using Exiled.API.Features;

using OverwatchLogger.Structs;

using PlayerRoles;

namespace OverwatchLogger.Features
{
    public class EnterHandler
    {
        public static List<RoleAliveCounter> Counters { get; private set; } = new();

        private static object _lock = new object();

        public static void AddPlayer(Player player, RoleTypeId role, TimeSpan used)
        {
            if (player == null) return;
            lock (_lock)
            {
                RoleAliveCounter counter = Counters.FirstOrDefault(x => x.Tracked == player.Nickname);
                if (default(RoleAliveCounter).Equals(counter))
                {
                    counter = new(player);
                    counter.AppendTime(role, used);
                    Counters.Add(counter);
                    return;
                }
                else counter.AppendTime(role, used);
            }
        }

        public static void AddPlayer(Player player, RoleTypeId role, DateTime start, DateTime end)
        {
            if (player == null) return;
            AddPlayer(player, role, (end - start));
        }
    }
}
