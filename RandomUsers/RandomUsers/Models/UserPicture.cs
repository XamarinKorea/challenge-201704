using System;
using Xamarin.Forms;

namespace RandomUsers.Models
{

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
}