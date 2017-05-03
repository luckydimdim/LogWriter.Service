using System;
using Microsoft.Extensions.Logging;

namespace Cmas.Services.LogWriter
{
    public class LogWriterService
    {
        private ILogger _logger;

        public LogWriterService(IServiceProvider serviceProvider)
        {
            var _loggerFactory = (ILoggerFactory)serviceProvider.GetService(typeof(ILoggerFactory));

            _logger = _loggerFactory.CreateLogger<LogWriterService>();
        }

        public void Log(LogMessage logMessage)
        {
            _logger.Log(logMessage.Level, (EventId)0, logMessage.Message, (Exception)null, (state, error) => state.ToString());
        }
    }

}
