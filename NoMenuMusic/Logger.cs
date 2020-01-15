using IPALogger = IPA.Logging.Logger;

namespace NoMenuMusic
{
    internal static class Logger
    {
        public static IPALogger log { get; set; }

        internal static void Log(string message, IPALogger.Level level)
        {
            log.Log(level, $"{message}");
        }
    }
}