using System;

namespace Yuya.Net.Logging
{
    /// <summary>
    /// Temel Logger Arayüzü. Bütün loglamalar için ortak bir arayüz sağlar. 
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log debug messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Debug(string format, params object[] arguments);

        /// <summary>
        /// Log debug messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Debug(Exception innerException, string format, params object[] arguments);

        /// <summary>
        /// Log information messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Info(string format, params object[] arguments);

        /// <summary>
        /// Log information messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Info(Exception innerException, string format, params object[] arguments);

        /// <summary>
        /// Log warning messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Warn(string format, params object[] arguments);

        /// <summary>
        /// Log warning messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Warn(Exception innerException, string format, params object[] arguments);

        /// <summary>
        /// Log error messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Error(string format, params object[] arguments);

        /// <summary>
        /// Log error messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Error(Exception innerException, string format, params object[] arguments);

        /// <summary>
        /// Log fatal messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Fatal(string format, params object[] arguments);

        /// <summary>
        /// Log fatal messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Fatal(Exception innerException, string format, params object[] arguments);

        /// <summary>
        /// Log messages with the severity type.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Log(LoggingSeverity severity, string format, params object[] arguments);

        /// <summary>
        /// Log messages with the severity type and the specified inner exception.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        void Log(LoggingSeverity severity, Exception innerException, string format, params object[] arguments);
    }
}