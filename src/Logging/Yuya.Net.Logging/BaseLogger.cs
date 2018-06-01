using System;

namespace Yuya.Net.Logging
{
    /// <summary>
    /// Logger sınıfları için baz işlemleri içeren temel sınıftır. 
    /// </summary>
    /// <seealso cref="Yuya.Net.Logging.ILogger" />
    public abstract class BaseLogger : ILogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLogger"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected BaseLogger(string name)
        {
            Name = name;
        }

        public string Name { get; }

        #region Debug
        /// <summary>
        /// Log debug messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Debug(string format, params object[] arguments);

        /// <summary>
        /// Log debug messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Debug(Exception innerException, string format, params object[] arguments);


        /// <summary>
        /// Debugs the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        public virtual void Debug(LogMessageGenerator logMessageGenerator)
        {
            Debug(logMessageGenerator());
        }
        #endregion

        #region Error
        /// <summary>
        /// Log error messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Error(string format, params object[] arguments);

        /// <summary>
        /// Log error messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Error(Exception innerException, string format, params object[] arguments);

        /// <summary>
        /// Errors the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        public virtual void Error(LogMessageGenerator logMessageGenerator)
        {
            Error(logMessageGenerator());
        }
        #endregion

        #region Fatal
        /// <summary>
        /// Log fatal messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Fatal(string format, params object[] arguments);

        /// <summary>
        /// Log fatal messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Fatal(Exception innerException, string format, params object[] arguments);

        /// <summary>
        /// Fatals the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        public virtual void Fatal(LogMessageGenerator logMessageGenerator)
        {
            Fatal(logMessageGenerator());
        }
        #endregion

        #region Info
        /// <summary>
        /// Log information messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Info(string format, params object[] arguments);

        /// <summary>
        /// Log information messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Info(Exception innerException, string format, params object[] arguments);

        /// <summary>
        /// Informations the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        public virtual void Info(LogMessageGenerator logMessageGenerator)
        {
            Info(logMessageGenerator());
        }
        #endregion

        #region Warn
        /// <summary>
        /// Log warning messages.
        /// </summary>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Warn(string format, params object[] arguments);

        /// <summary>
        /// Log warning messages with the specified inner exception.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public abstract void Warn(Exception innerException, string format, params object[] arguments);

        /// <summary>
        /// Warns the specified log message generator.
        /// </summary>
        /// <param name="logMessageGenerator">The log message generator.</param>
        public virtual void Warn(LogMessageGenerator logMessageGenerator)
        {
            Warn(logMessageGenerator());
        }
        #endregion

        #region Log
        /// <summary>
        /// Log messages with the severity type.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public virtual void Log(LoggingSeverity severity, string format, params object[] arguments)
        {
            switch (severity)
            {
                case LoggingSeverity.Debug:
                    Debug(format, arguments);
                    break;
                case LoggingSeverity.Info:
                    Info(format, arguments);
                    break;
                case LoggingSeverity.Warn:
                    Warn(format, arguments);
                    break;
                case LoggingSeverity.Error:
                    Error(format, arguments);
                    break;
                case LoggingSeverity.Fatal:
                    Fatal(format, arguments);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Log messages with the severity type and the specified inner exception.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The message format string.</param>
        /// <param name="arguments">The message format argument array.</param>
        public virtual void Log(LoggingSeverity severity, Exception innerException, string format, params object[] arguments)
        {
            switch (severity)
            {
                case LoggingSeverity.Debug:
                    Debug(innerException, format, arguments);
                    break;
                case LoggingSeverity.Info:
                    Info(innerException, format, arguments);
                    break;
                case LoggingSeverity.Warn:
                    Warn(innerException, format, arguments);
                    break;
                case LoggingSeverity.Error:
                    Error(innerException, format, arguments);
                    break;
                case LoggingSeverity.Fatal:
                    Fatal(innerException, format, arguments);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Logs the specified severity.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="logMessageGenerator">The log message generator.</param>
        public virtual void Log(LoggingSeverity severity, LogMessageGenerator logMessageGenerator)
        {
            Log(severity, logMessageGenerator());
        }
        #endregion
    }
}