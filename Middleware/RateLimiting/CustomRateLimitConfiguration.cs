using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;

namespace RateLimitingWebApi.Middleware.RateLimiting
{
    public class CustomRateLimitConfiguration:RateLimitConfiguration
    {
        public CustomRateLimitConfiguration(IOptions<IpRateLimitOptions> ipOpt, IOptions<ClientRateLimitOptions> clientOpt)
            :base(ipOpt, clientOpt){  }
        public override void RegisterResolvers()
        {
            ClientResolvers.Add(new ClientIdResolverContributer());
        }
    }
}
