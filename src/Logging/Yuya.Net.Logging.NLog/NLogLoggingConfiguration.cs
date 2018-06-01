using NLog;
using System;

namespace Yuya.Net.Logging.NLog
{

    public class NLogLoggingConfiguration : LoggingConfiguration
    {
        public NLogLoggingConfiguration(LoggingConfiguration loggingConfiguration) : base(loggingConfiguration)
        {
        }

        /// <summary>
        /// Creates the Log Manager instance.
        /// </summary>
        /// <returns></returns>
        public override ILogManager Create()
        {
            LogManager.Configuration = new global::NLog.Config.XmlLoggingConfiguration(internalConfigurationFileName ?? "nlog.config");
            return new NLogLogManager();
        }
    }
}
