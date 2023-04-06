using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarFleet.Filter
{
    public class TokenAuthorizationFilter : AuthorizeFilter
    {
        private readonly AuthorizationPolicy _policy;

        public TokenAuthorizationFilter(AuthorizationPolicy policy) : base(policy)
        {
            _policy = policy;
        }

        public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAsyncAuthorizationFilter && item != this))
            {
                await Task.FromResult(0);
            }

            await base.OnAuthorizationAsync(context);
        }
    }
}
