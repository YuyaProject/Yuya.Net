using NLog;
using System;

namespace Yuya.Net.Logging.NLog
{

    /// <summary>
    /// NLog Log Manager Class
    /// </summary>
    /// <seealso cref="Yuya.Net.Logging.ILogManager" />
    internal class NLogLogManager : ILogManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogManager"/> class.
        /// </summary>
        public NLogLogManager()
        {
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns></returns>
        public ILogger GetLogger(string loggerName)
        {
            var log = LogManager.GetLogger(loggerName);
            return new NLogLogger(log);
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="loggerType">Type of the logger.</param>
        /// <returns></returns>
        public ILogger GetLogger(Type loggerType)
        {
            return new NLogLogger(LogManager.GetLogger(loggerType.Name));
        }
    }
}
