using LookUpBrazil.API.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;
using System.Security.Claims;

namespace LookUpBrazil.API.Extension
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var results = new List<Claim>()
            {
                new(ClaimTypes.Name, user.Email)
            };

            results.AddRange(
                user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            return results;
        }
    }
}
