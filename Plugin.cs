using System;

using Exiled.API.Features;

using OverwatchLogger.Features;

namespace OverwatchLogger
{
    public class Plugin: Plugin<Config>
    {
        public static Plugin Instance { get; private set; }

        public override string Author { get; } = "notifapi";

        public override Version RequiredExiledVersion { get; } = new Version(9, 0 ,0);

        public override Version Version { get; } = new Version(2, 0, 1);

        public override bool IgnoreRequiredVersionCheck { get; } = false;

        public override void OnEnabled()
        {
            Instance = this;

            HookHelper.Start();

            Exiled.Events.Handlers.Server.WaitingForPlayers += EventHandler.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundEnded += EventHandler.OnRoundEnded;
            Exiled.Events.Handlers.Player.Spawned += EventHandler.OnSpawned;
            
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= EventHandler.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundEnded -= EventHandler.OnRoundEnded;
            Exiled.Events.Handlers.Player.Spawned -= EventHandler.OnSpawned;

            HookHelper.Stop();

            Instance = null;
            base.OnDisabled();
        }
    }
}
