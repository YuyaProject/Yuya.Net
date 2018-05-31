using System;

namespace Yuya.Net.Logging
{
    /// <summary>
    /// Boş Log yöneticisidir. Bu sınıf hiç bir iş yapmaz.
    /// </summary>
    /// <seealso cref="Yuya.Net.Logging.ILogManager" />
    public class NullLogManager : ILogManager
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="NullLogManager"/> class from being created.
        /// </summary>
        private NullLogManager()
        {

        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static NullLogManager Instance { get; } = new NullLogManager();

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns></returns>
        public ILogger GetLogger(string loggerName)
        {
            return NullLogger.Instance;
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="loggerType">Type of the logger.</param>
        /// <returns></returns>
        public ILogger GetLogger(Type loggerType)
        {
            return NullLogger.Instance;
        }
    }
}