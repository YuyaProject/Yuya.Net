using System;
using System.Collections;
using log4net;
using log4net.Repository;

namespace Yuya.Net.Logging.Log4Net
{
    /// <summary>
    /// Log4Net Extensions Class
    /// </summary>
    public static class Log4NetExtensions
    {
        /// <summary>
        /// Uses the log4 net.
        /// </summary>
        /// <param name="loggingConfiguration">The logging configuration.</param>
        /// <returns></returns>
        public static Log4NetLoggingConfiguration UseLog4Net(this LoggingConfiguration loggingConfiguration) {
            return new Log4NetLoggingConfiguration(loggingConfiguration);
        }
    }
}