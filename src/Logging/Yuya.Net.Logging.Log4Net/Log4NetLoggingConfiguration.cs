using log4net;
using log4net.Config;
using log4net.Repository;
using System.IO;
using System.Reflection;

namespace Yuya.Net.Logging.Log4Net
{
    /// <summary>
    /// Log4Net Logging Configuration Class
    /// </summary>
    /// <seealso cref="Yuya.Net.Logging.LoggingConfiguration" />
    public class Log4NetLoggingConfiguration : LoggingConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetLoggingConfiguration"/> class.
        /// </summary>
        /// <param name="loggingConfiguration">The logging configuration.</param>
        public Log4NetLoggingConfiguration(LoggingConfiguration loggingConfiguration): base(loggingConfiguration)
        {
        }

        /// <summary>
        /// Creates the Log Manager instance.
        /// </summary>
        /// <returns></returns>
        public override ILogManager Create()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            return Create(logRepository);
        }

        /// <summary>
        /// Creates the specified log repository.
        /// </summary>
        /// <param name="logRepository">The log repository.</param>
        /// <returns></returns>
        public ILogManager Create(ILoggerRepository logRepository)
        {
            var configs = XmlConfigurator.Configure(logRepository, new FileInfo(internalConfigurationFileName ?? "log4net.config"));

            return new Log4NetLogManager(logRepository, configs);
        }
    }
}
