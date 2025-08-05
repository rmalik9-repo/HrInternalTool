using Microsoft.AspNetCore.Authorization;

namespace HrInternalTool.Api.Middleware
{
    public class MinimumAgeAuthorizationReq : IAuthorizationRequirement// MinimumAgeAuthorizationRequirement
    {
        public int MinimumAge { get; }
        public MinimumAgeAuthorizationReq(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
    public class MinimumAgeAuthorizationReqHandler : AuthorizationHandler<MinimumAgeAuthorizationReq>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeAuthorizationReq requirement)
        {
            var ageclaim = context.User.Claims.FirstOrDefault(c => c.Type == "age");
            if (ageclaim != null && int.TryParse(ageclaim.Value, out var age) && age >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }

    }
}
