using AspNetCoreRateLimit;

namespace RateLimitingWebApi.Middleware.RateLimiting
{
    internal class ClientIdResolverContributer : IClientResolveContributor
    {
        public async Task<string> ResolveClientAsync(HttpContext httpContext)
        {
            return await Task.FromResult<string>(httpContext.Request.Query["CustomKey"]);
        }
    }
}