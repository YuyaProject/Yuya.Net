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
        /// Debugs the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        void Debug(LogMessageGenerator logMessageGenerator);

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
        /// Informations the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        void Info(LogMessageGenerator logMessageGenerator);

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
        /// Warns the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        void Warn(LogMessageGenerator logMessageGenerator);

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
        /// Errors the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        void Error(LogMessageGenerator logMessageGenerator);

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
        /// Fatals the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        void Fatal(LogMessageGenerator logMessageGenerator);

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

        /// <summary>
        /// Logs the specified severity.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="logMessageGenerator">The log message generator.</param>
        void Log(LoggingSeverity severity, LogMessageGenerator logMessageGenerator);

    }
}