using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace TestProject.Utilities
{
    public class AddRoleToClaimOnSignIn : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal != null)
            {
                var identity = principal.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    identity.AddClaim(new("TestClaim", "Yes", ClaimValueTypes.String));
                }
            }

            return Task.FromResult(principal);
        }
    }
}
