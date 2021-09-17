using Graduate_work.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graduate_work.Models
{
    public class UserViewModel
    {
        public string Login { get; set; }

        public string AvatarUrl { get; set; }

        public Role Role { get; set; }
    }
}