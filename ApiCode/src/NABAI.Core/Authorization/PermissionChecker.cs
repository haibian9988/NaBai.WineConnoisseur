using Abp.Authorization;
using NABAI.Authorization.Roles;
using NABAI.Authorization.Users;

namespace NABAI.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
