using System;

namespace Yuya.Net.Logging
{
    /// <summary>
    /// Log sisteminin konfigüre edilip ayağa kaldırılması için bu ayarlama aracı kullanılır. 
    /// </summary>
    public class LoggingConfiguration {
        protected string internalConfigurationFileName;

        public LoggingConfiguration()
        {

        }

        protected LoggingConfiguration(LoggingConfiguration copy)
        {
            internalConfigurationFileName = copy.internalConfigurationFileName;
        }

        /// <summary>
        /// Configurations the name of the file.
        /// </summary>
        /// <param name="configurationFileName">Name of the configuration file.</param>
        /// <returns></returns>
        public virtual LoggingConfiguration ConfigurationFileName(string configurationFileName)
        {
            this.internalConfigurationFileName = configurationFileName;
            return this;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public virtual ILogManager Create()
        {
            return NullLogManager.Instance;
        }
    }
}