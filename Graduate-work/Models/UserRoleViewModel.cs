using Graduate_work.Model;

namespace Graduate_work.Models
{
    public class UserRoleViewModel
    {
        public Role Role { get; set; }
        public string Login { get; set; }
        public bool ProfileIsBlocked { get; set; }
    }
}
