using System;

using Exiled.API.Features;

using OverwatchLogger.Features;

namespace OverwatchLogger
{
    public class Plugin: Plugin<Config>
    {
        public static Plugin Instance { get; private set; }

        public override string Author => "notifapi";

        public override Version RequiredExiledVersion => new Version(9, 0 ,0);

        public override Version Version => new Version(1,0,0);

        public WeebHookClient whook { get; private set; }

        private OverTracker OverTracker;

        public override void OnEnabled()
        {
            Instance = this;
            whook = new WeebHookClient(Config.WeebHookUrl, Config.WeebHookName, Config.WeebHookAvatarUrl);
            OverTracker = new OverTracker();
            Exiled.Events.Handlers.Player.ChangingRole += OverTracker.OnOverwactEnabled;
            Exiled.Events.Handlers.Player.Verified += OverTracker.OnPlayerVerefied;
            Exiled.Events.Handlers.Server.WaitingForPlayers += OverTracker.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundEnded += OverTracker.OnRoundEnded;
            if (string.IsNullOrWhiteSpace(Config.WeebHookUrl))
            {
                Log.Warn("Weebhook url do not entered into config");
                OnDisabled();
                return;
            }
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= OverTracker.OnOverwactEnabled;
            Exiled.Events.Handlers.Player.Verified -= OverTracker.OnPlayerVerefied;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OverTracker.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundEnded -= OverTracker.OnRoundEnded;
            OverTracker = null;
            whook = null;
            Instance = null;
            base.OnDisabled();
        }
    }
}
