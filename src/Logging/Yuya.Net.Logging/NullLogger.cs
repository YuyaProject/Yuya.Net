using System;

namespace Yuya.Net.Logging
{
    /// <summary>
    /// Boş logger sınıfı. Bu sınıf hiç bir iş yapmaz. 
    /// </summary>
    /// <seealso cref="Yuya.Net.Logging.ILogger" />
    public sealed class NullLogger : BaseLogger, ILogger
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="NullLogger" /> class from being created.
        /// </summary>
        private NullLogger() : base(string.Empty)
        {

        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static NullLogger Instance { get; } = new NullLogger();

        /// <summary>
        /// Log debug messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Debug(string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log debug messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Debug(Exception innerException, string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log error messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Error(string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log error messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Error(Exception innerException, string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log fatal messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Fatal(string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log fatal messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Fatal(Exception innerException, string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log information messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Info(string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log information messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Info(Exception innerException, string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log messages with the severity type.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Log(LoggingSeverity severity, string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log messages with the severity type and the specified inner exception.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Log(LoggingSeverity severity, Exception innerException, string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log warning messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Warn(string format, params object[] arguments)
        {
        }

        /// <summary>
        /// Log warning messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public override void Warn(Exception innerException, string format, params object[] arguments)
        {
        }
    }
}