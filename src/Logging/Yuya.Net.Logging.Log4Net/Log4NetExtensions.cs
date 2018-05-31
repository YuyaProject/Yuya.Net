using System;
using System.Collections;
using log4net;
using log4net.Repository;

namespace Yuya.Net.Logging.Log4Net
{
    public static class Log4NetExtensions
    {
        public static Log4NetLoggingConfiguration UseLog4Net(this LoggingConfiguration loggingConfiguration) {
            return new Log4NetLoggingConfiguration(loggingConfiguration);
        }
    }
}