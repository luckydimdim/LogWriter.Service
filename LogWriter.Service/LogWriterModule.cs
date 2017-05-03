using System;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using System.Threading.Tasks;
using System.Threading;
using Nancy.Validation;
using Cmas.Infrastructure.ErrorHandler;

namespace Cmas.Services.LogWriter
{
    /// <summary>
    /// Логирует полученные сообщения
    /// </summary>
    public class LogWriterModule : NancyModule
    {
        private LogWriterService _logWriterService;

        public LogWriterModule(IServiceProvider serviceProvider)
        {
            _logWriterService = new LogWriterService(serviceProvider);

            Post<Negotiator>("log", LogMessageHandlerAsync);
        }

        #region Обработчики

        private async Task<Negotiator> LogMessageHandlerAsync(dynamic args, CancellationToken token)
        {
            LogMessage request = this.Bind<LogMessage>();

            var validationResult = this.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationErrorException(validationResult.FormattedErrors);
            }

            _logWriterService.Log(request);

            return Negotiate.WithStatusCode(HttpStatusCode.OK);
        }

        #endregion
    }
}