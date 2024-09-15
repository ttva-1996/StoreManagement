using Microsoft.AspNetCore.Authorization;

using StoreManagement.Domain.Enums;

namespace StoreManagement.Application.Authorization;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false)]
public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(EnumPermission permission) : base(permission.ToString())
    {
    }
}
