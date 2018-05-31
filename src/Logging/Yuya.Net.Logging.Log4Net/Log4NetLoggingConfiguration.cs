using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;
using System.Reflection;

namespace Yuya.Net.Logging.Log4Net
{
    public class Log4NetLoggingConfiguration : LoggingConfiguration
    {
        public Log4NetLoggingConfiguration(LoggingConfiguration loggingConfiguration): base(loggingConfiguration)
        {
        }

        public override ILogManager Create()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var configs = XmlConfigurator.Configure(logRepository, new FileInfo(internalConfigurationFileName ?? "log4net.config"));

            return new Log4NetLogManager(logRepository, configs);
        }
    }
}
