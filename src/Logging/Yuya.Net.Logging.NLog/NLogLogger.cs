using NLog;
using System;

namespace Yuya.Net.Logging.NLog
{
    /// <summary>
    /// NLog Logger Class
    /// </summary>
    /// <seealso cref="Yuya.Net.Logging.BaseLogger" />
    internal class NLogLogger : BaseLogger
    {
        private readonly global::NLog.ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogger"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        internal NLogLogger(global::NLog.ILogger logger) : base(logger.Name)
        {
            _logger = logger;
        }

        /// <summary>
        /// Log debug messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Debug(string format, params object[] arguments)
        {
            _logger.Debug(format, arguments);
        }

        /// <summary>
        /// Log debug messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Debug(Exception innerException, string format, params object[] arguments)
        {
            _logger.Debug(innerException, format, arguments);
        }

        /// <summary>
        /// Log error messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Error(string format, params object[] arguments)
        {
            _logger.Error(format, arguments);
        }

        /// <summary>
        /// Log error messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Error(Exception innerException, string format, params object[] arguments)
        {
            _logger.Error(innerException, format, arguments);
        }

        /// <summary>
        /// Log fatal messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Fatal(string format, params object[] arguments)
        {
            _logger.Fatal(format, arguments);
        }

        /// <summary>
        /// Log fatal messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Fatal(Exception innerException, string format, params object[] arguments)
        {
            _logger.Fatal(innerException, format, arguments);
        }

        /// <summary>
        /// Log information messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Info(string format, params object[] arguments)
        {
            _logger.Info(format, arguments);
        }

        /// <summary>
        /// Log information messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Info(Exception innerException, string format, params object[] arguments)
        {
            _logger.Info(innerException, format, arguments);
        }

        /// <summary>
        /// Log warning messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Warn(string format, params object[] arguments)
        {
            _logger.Warn(format, arguments);
        }

        /// <summary>
        /// Log warning messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Warn(Exception innerException, string format, params object[] arguments)
        {
            _logger.Warn(innerException, format, arguments);
        }
    }
}
