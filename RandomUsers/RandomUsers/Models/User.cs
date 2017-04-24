using System;

namespace RandomUsers.Models
{

    public class User
    {
        public string DisplayName
        {
            get
            {
                return Name.ToString();
            }
        }

        public string Gender { get; set; }
        public UserName Name { get; set; }
        public UserLocation Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public DateTime Registered { get; set; }
        public UserPicture Picture { get; set; }   
        public string Nat { get; set; }
    }
}
