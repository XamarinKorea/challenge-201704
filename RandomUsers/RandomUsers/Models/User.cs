using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomUsers.Models
{
    public class UserName
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

        public override string ToString()
        {
            var title = string.IsNullOrEmpty(Title) ? string.Empty : string.Format("({0})",Title);
            var last = string.IsNullOrEmpty(Last) ? string.Empty : string.Format("{0}", Last);
            var first = string.IsNullOrEmpty(First) ? string.Empty : string.Format(",{0}", First);
            return title + last + first;
        }
    }

    public class UserLocation
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
    }

    public class UserPicture
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }

        public ImageSource MediumSource
        {
            get
            {
#if DEBUG
                var source = ImageSource.FromFile("person.png");
                return source;
#else
                return new UriImageSource
                {
                    CachingEnabled = true,
                    Uri = new Uri(Medium),
                };
#endif
            }
        }

        public ImageSource LargeSource
        {
            get
            {
#if DEBUG
                var source = ImageSource.FromFile("person.png");
                return source;
#else
                return new UriImageSource
                {
                    CachingEnabled = true,
                    Uri = new Uri(Large),
                };
#endif
            }
        }

        public ImageSource ThumbnailSource
        {
            get
            {
#if DEBUG
                var source = ImageSource.FromFile("person.png");
                return source;
#else
                return new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new Uri(Thumbnail),
                };
#endif
            }
        }
    }

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
