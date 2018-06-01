using log4net;
using System;

namespace Yuya.Net.Logging.Log4Net
{
    /// <summary>
    /// Log4Net için logger sınıf uygulaması.
    /// </summary>
    /// <seealso cref="Yuya.Net.Logging.BaseLogger" />
    internal class Log4NetLogger : BaseLogger
    {
        private readonly ILog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetLogger"/> class.
        /// </summary>
        /// <param name="log">The log.</param>
        internal Log4NetLogger(ILog log) : base(log.Logger.Name)
        {
            _log = log;
        }

        /// <summary>
        /// Log debug messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Debug(string format, params object[] arguments)
        {
            _log.DebugFormat(format, arguments);
        }

        /// <summary>
        /// Log debug messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Debug(Exception innerException, string format, params object[] arguments)
        {
            _log.Debug(string.Format(format, arguments), innerException);
        }

        /// <summary>
        /// Log error messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Error(string format, params object[] arguments)
        {
            _log.ErrorFormat(format, arguments);
        }

        /// <summary>
        /// Log error messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Error(Exception innerException, string format, params object[] arguments)
        {
            _log.Error(string.Format(format, arguments), innerException);
        }

        /// <summary>
        /// Log fatal messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Fatal(string format, params object[] arguments)
        {
            _log.FatalFormat(format, arguments);
        }

        /// <summary>
        /// Log fatal messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Fatal(Exception innerException, string format, params object[] arguments)
        {
            _log.Fatal(string.Format(format, arguments), innerException);
        }

        /// <summary>
        /// Log information messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Info(string format, params object[] arguments)
        {
            _log.InfoFormat(format, arguments);
        }

        /// <summary>
        /// Log information messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Info(Exception innerException, string format, params object[] arguments)
        {
            _log.Info(string.Format(format, arguments), innerException);
        }

        /// <summary>
        /// Log warning messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Warn(string format, params object[] arguments)
        {
            _log.WarnFormat(format, arguments);
        }

        /// <summary>
        /// Log warning messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Warn(Exception innerException, string format, params object[] arguments)
        {
            _log.Warn(string.Format(format, arguments), innerException);
        }
    }
}
