using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Extensions;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        public RequestLogger(ILogger<TRequest> logger, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var userName = userId.HasValue ?  _userManager.GetUserName(_httpContextAccessor.HttpContext.User) : string.Empty;
            _logger.LogInformation("CleanArchitecture Request: {Name} {@UserId} {@UserName} {@Request}", requestName, userId, userName ,request);
            return Task.CompletedTask;
        }
    }
}
