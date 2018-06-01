using System;

namespace Yuya.Net.Logging
{
    public interface ILogManager
    {
        ILogger GetLogger(string loggerName);

        ILogger GetLogger(Type loggerType);
    }
}