using AspNetCoreRateLimit;

namespace RateLimitingWebApi.Services
{
    public interface IRateLimitingService
    {
        Task<IpRateLimitPolicies> GetIpRateLimitPolicies();
        Task AddIpRateLimitPolices(IpRateLimitPolicies ıpRateLimitPolicies);
    }
}
