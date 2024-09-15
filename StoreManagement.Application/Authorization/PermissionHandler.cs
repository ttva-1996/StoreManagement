using Microsoft.AspNetCore.Authorization;

namespace StoreManagement.Application.Authorization;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        /// Implement mock, cannot running yet
        var hasPermission = context.User.Claims
            .Any(c => 
                //c.Type == "Permission" &&
                c.Value == requirement.Permissions.Where(c => c == Domain.Enums.EnumPermission.ADMIN).ToString());

        if (hasPermission)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

