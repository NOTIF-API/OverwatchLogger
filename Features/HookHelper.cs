using System;
using System.Collections.Generic;

using Exiled.API.Features;

using MEC;

using OverwatchLogger.Serelizables;
using OverwatchLogger.Structs;

namespace OverwatchLogger.Features
{
    public class HookHelper
    {
        private static Queue<QueueLog> _queue = new();

        private static object _lock = new object();

        public static float Deloy { get; set; } = 7;

        private static CoroutineHandle _coroutine;

        public static void AddLogMessage(string message, WeebHookSerelizable hook)
        {
            lock (_lock)
            {
                foreach (var item in SplitByLength(message, 1900))
                {
                    _queue.Enqueue(new(hook, new(item, hook.HookName, hook.HookAvatar)));
                }
            }
        }

        public static IEnumerable<string> SplitByLength(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) yield break;
            if (text.Length <= maxLength)
            {
                yield return text;
                yield break;
            }

            int offset = 0;
            while (offset < text.Length)
            {
                int length = Math.Min(maxLength, text.Length - offset);
                yield return text.Substring(offset, length);

                offset += maxLength;
            }
        }

        public static void Start()
        {
            Timing.KillCoroutines(_coroutine);
            _coroutine = Timing.RunCoroutine(AutoSender());
        }

        public static void Stop()
        {
            Timing.KillCoroutines(_coroutine);
        }

        private static IEnumerator<float> AutoSender()
        {
            for (; ; )
            {
                yield return Timing.WaitForSeconds(Deloy);
                lock (_lock)
                {
                    if (_queue.TryDequeue(out QueueLog queue))
                    {
                        queue.Hook.SendMessage(queue.Message);
                        Log.Debug("[AutoSender] Sended auto queue log");
                    }
                }
            }
        }
    }
}
