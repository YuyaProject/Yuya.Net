using NLog;
using System;

namespace Yuya.Net.Logging.NLog
{
    public static class NLogExtensions
    {
        /// <summary>
        /// Uses the log4 net.
        /// </summary>
        /// <param name="loggingConfiguration">The logging configuration.</param>
        /// <returns></returns>
        public static NLogLoggingConfiguration UseNLog(this LoggingConfiguration loggingConfiguration)
        {
            return new NLogLoggingConfiguration(loggingConfiguration);
        }
    }
}
