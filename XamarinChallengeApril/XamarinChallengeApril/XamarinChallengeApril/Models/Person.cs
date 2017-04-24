using System;

namespace XamarinChallengeApril.Models
{
    public class Person
    {
        public string Name { get; private set; }

        public string ImageUrl { get; private set; }

        public string PhoneNumber { get; private set; }

        public Person(string name, string imageUrl, string phoneNumber)
        {
            Name = name;
            ImageUrl = imageUrl;
            PhoneNumber = phoneNumber;
        }

    }
}
