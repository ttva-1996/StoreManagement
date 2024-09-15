using Microsoft.AspNetCore.Authorization;
using StoreManagement.Domain.Enums;

namespace StoreManagement.Application.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public IEnumerable<EnumPermission> Permissions { get; }

    public PermissionRequirement(IEnumerable<EnumPermission> permissions)
    {
        Permissions = permissions;
    }
}
