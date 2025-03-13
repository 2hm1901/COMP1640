using Microsoft.AspNetCore.Mvc.Filters;
using Models.Core;
using System.Security.Claims;

namespace COMP1640.WebAPI.Filters
{
    public class AutoAddUserFilter(params Type[] supportedModelTypes) : IActionFilter
    {
        private readonly Type[] _supportedModelTypes = supportedModelTypes;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action needed after execution in this case
        }

        // This method is called before the action method executes
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Get HTTP method of the current request
            string httpMethod = context.HttpContext.Request.Method;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                // Get current userId from authenticated user's identity
                if (!int.TryParse(context.HttpContext.User.Identity.Name, out int userId))
                {
                    userId = 0;
                }

                // The filter iterates over all the arguments (feedbackDto and anotherDto).
                // Checks if the type matches one of the supported model types
                // If the argument is of the supported model types , the filter sets the CurrentUser and CurrentUserRole properties.
                foreach (object argument in context.ActionArguments.Values)
                {
                    var argumentType = argument.GetType();

                    if (_supportedModelTypes.Any(rootType => rootType.IsAssignableFrom(argumentType)))
                    {
                        // Set 'CurrentUser' property of the argument to current username
                        var userIdProperty = argumentType.GetProperty("CurrentUserId");
                        if (userIdProperty != null && userIdProperty.PropertyType == typeof(int))
                        {
                            userIdProperty.SetValue(argument, userId);
                        }

                        // Set 'CurrentUserRole' property of the argument to current user's role
                        var userRoleProp = argumentType.GetProperty("CurrentUserRole");
                        if (userRoleProp != null && userRoleProp.PropertyType == typeof(Role))
                        {
                            // Get current user's role from claims
                            if (!Enum.TryParse(context.HttpContext.User.FindFirstValue(ClaimTypes.Role), out Role role))
                            {
                                role = Role.STUDENT;
                            }
                            userRoleProp.SetValue(argument, role);
                        }

                    }

                }
            }
        }
    }
}
