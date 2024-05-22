using Microsoft.AspNetCore.Identity;
using static MBBE.Common.Constant.Enum;

namespace MBBE.Models
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRoleMap> UserRoleMaps { get; set; }
    }
}
