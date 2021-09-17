using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graduate_work.Model
{
    public class User : BaseModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string DateOfBirth { get; set; }

        public string AvatarUrl { get; set; }

        public Role Role { get; set; }

        public Language Lang { get; set; }
    }
}
