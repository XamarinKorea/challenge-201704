using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteScroll.Models
{
    public class UserInfo
    {

        public string Idnumber { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string NameTitle { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string Location { get; set; }
        public string LocationStreet { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public string Email { get; set; }
        public string LoginUsername { get; set; }
        public string LoginPassword { get; set; }
        public string Dob { get; set; }
        public string Registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string Picturelarge { get; set; }
        public string Picturemedium { get; set; }

        public UserInfo(string idnumber, string gender, string nametitle, string namefirst, string namelast, string locationstreet, string locationcity, string locationstate, string email, string loginusername, string loginpassword, string dob, string registered, string phone, string cell, string picturelarge, string picturemedium )
        {

            Idnumber = idnumber;
            Gender = gender;
            Name = namefirst + " " + namelast;
            NameTitle = nametitle;
            NameFirst = namefirst;
            NameLast = namelast;
            Location = locationcity + " , " + locationstate;
            LocationStreet = locationstreet;
            LocationCity = locationcity;
            LocationState = locationstate;
            Email = email;
            LoginUsername = loginusername;
            LoginPassword = loginpassword;
            Dob = dob;
            Registered = registered;
            Phone = phone;
            Cell = cell;
            Picturelarge = picturelarge;
            Picturemedium = picturemedium;
        }
    }
    
}
