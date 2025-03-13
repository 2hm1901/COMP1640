using Microsoft.AspNetCore.Authorization;
using Models.Core;

namespace COMP1640.WebAPI.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(params Role[] roles)
        {
            if (roles != null && roles.Length > 0)
            {
                Roles = string.Join(",", roles.Select(r => r.ToString()));
            }
        }
    }
}
