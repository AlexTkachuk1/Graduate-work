using Graduate_work.EfStuff.Model;
using System;
using System.Collections.Generic;

namespace Graduate_work.Model
{
    public class User : BaseModel
    { 
        public bool ProfileIsBlocked { get; set; }=false;
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string homeСountry { get; set; }

        public string homeСity { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; } = "/images/demo/avatar.png";

        public Role Role { get; set; }

        public Language Lang { get; set; }

        public virtual List<Book> MyFavoriteBooks { get; set; }

        public virtual List<Comment> CommentsCreatedByMe { get; set; }

        public virtual List<Picture> PicturesCreatedByMe { get; set; }
    }
}
