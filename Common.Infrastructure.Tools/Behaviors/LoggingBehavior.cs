using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Infrastructure.Tools.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("----- Handling command or query {CommandOrQueryName} ({@CommandOrQueryName})", request.GetType().Name, request);
            var response = await next();
            _logger.LogInformation("----- Command or query {CommandOrQueryName} handled - response: {@Response}", request.GetType().Name, response);

            return response;
        }
    }
}
