using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;

namespace RateLimitingWebApi.Services
{
    public class RateLimitingService : IRateLimitingService
    {
        private readonly IpRateLimitOptions _opt;
        private readonly IIpPolicyStore _policyStore;

        public RateLimitingService(IOptions<IpRateLimitOptions> opt, IIpPolicyStore policyStore)
        {
            _opt = opt.Value;
            _policyStore = policyStore;
        }

        public async Task AddIpRateLimitPolices(IpRateLimitPolicies ıpRateLimitPolicies)
        {
            var policies = await _policyStore.GetAsync(_opt.IpPolicyPrefix);
            if(policies != null) 
            {
                policies.IpRules.Add(new IpRateLimitPolicy
                {
                    Ip="1.1.1.1",
                    Rules=new List<RateLimitRule>(new RateLimitRule[6])
                    {
                        new RateLimitRule
                        {
                            Endpoint="*:/update",
                            Limit=10,
                            Period="1d"
                        }
                    }
                });
                await _policyStore.SetAsync(_opt.IpPolicyPrefix, policies);
            }
        }

        public async Task<IpRateLimitPolicies> GetIpRateLimitPolicies()
        {
            var policies = await _policyStore.GetAsync(_opt.IpPolicyPrefix);
            return policies;
        }
    }
}