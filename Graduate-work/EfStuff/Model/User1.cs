using Graduate_work.EfStuff.Model;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Graduate_work.Model
{
    public class User1 : IdentityUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string DateOfBirth { get; set; }

        public string homeСountry { get; set; }

        public string homeСity { get; set; }

        public int Tel { get; set; }

        public string AvatarUrl { get; set; } = "/images/user avatar/avatar.gif";

        public Role Role { get; set; }

        public Language Lang { get; set; }

        public virtual List<Book> MyFavoriteBooks { get; set; } 

        public virtual List<Comment> CommentsCreatedByMe { get; set; }

        public virtual List<Picture> PicturesCreatedByMe { get; set; }
    }
}
