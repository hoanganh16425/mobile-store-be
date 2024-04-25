using static MBBE.Common.Constant.Enum;

namespace MBBE.Models
{
    public class Role
    {
        public UserRoles RoleId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; }
    }
}
