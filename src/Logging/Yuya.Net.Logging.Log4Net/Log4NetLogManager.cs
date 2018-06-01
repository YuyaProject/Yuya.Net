using System;
using System.Collections;
using log4net;
using log4net.Repository;

namespace Yuya.Net.Logging.Log4Net
{
    /// <summary>
    /// Log4Net Log Manager Class
    /// </summary>
    /// <seealso cref="Yuya.Net.Logging.ILogManager" />
    internal class Log4NetLogManager : ILogManager
    {
        private readonly ILoggerRepository _logRepository;
        private readonly ICollection _configs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetLogManager"/> class.
        /// </summary>
        /// <param name="logRepository">The log repository.</param>
        /// <param name="configs">The configs.</param>
        public Log4NetLogManager(ILoggerRepository logRepository, ICollection configs)
        {
            this._logRepository = logRepository;
            this._configs = configs;
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns></returns>
        public ILogger GetLogger(string loggerName)
        {
            var log = LogManager.GetLogger(_logRepository.Name, loggerName);
            return new Log4NetLogger(log);
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="loggerType">Type of the logger.</param>
        /// <returns></returns>
        public ILogger GetLogger(Type loggerType)
        {
            return new Log4NetLogger(LogManager.GetLogger(loggerType));
        }
    }
}