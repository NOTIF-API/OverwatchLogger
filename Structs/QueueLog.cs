using OverwatchLogger.Serelizables;

namespace OverwatchLogger.Structs
{
    public struct QueueLog
    {
        public WeebHookNetworkMessage Message;

        public WeebHookSerelizable Hook;

        public QueueLog(WeebHookSerelizable hook, WeebHookNetworkMessage message)
        {
            Message = message;
            Hook = hook;
        }
    }
}