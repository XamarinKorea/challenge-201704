using Newtonsoft.Json;
using RandomUsers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RandomUsers.Service
{
    public class DataService
    {
        private const int MAX_PAGE = 100;
        private HttpClient client = new HttpClient();
        private int _page = 3;
        public DataService()
        {
        }

        public async Task<IList<User>> GetUsersMore()
        {
            IList<User> users = null;
            if (MAX_PAGE <= _page)
            {
                users = new List<User>();
                return users;
            }

            _page++;
#if DEBUG
            var result = JsonConvert.DeserializeObject<Result>(App.Json);
            users = result.Results.ToList();
#else
            try
            {
                var json = await client.GetStringAsync("https://randomuser.me/api/?page="+_page+"&results=5&seed=abc");
                var result = JsonConvert.DeserializeObject<Result>(json);
                users = result.Results.ToList();
            }
            catch (Exception ex)
            {
                users = new List<User>();
                users.Add(new User
                {
                    Name = new UserName
                    {
                        Last = ex.InnerException.Message,
                    }
                });
            }
#endif
            return users;
        }

        public async Task<IList<User>> GetUsers()
        {
            _page = 3;
            IList<User> users = null;

#if DEBUG
            var result = JsonConvert.DeserializeObject<Result>(App.Json);
            users = result.Results.ToList();
#else
            try
            {
                var json = await client.GetStringAsync("https://randomuser.me/api/?page=1&results=15&seed=abc");
                var result = JsonConvert.DeserializeObject<Result>(json);
                users = result.Results.ToList();
            }
            catch (Exception ex)
            {
                users = new List<User>();
                users.Add(new User
                {
                    Name = new UserName
                    {
                        Last = ex.InnerException.Message,
                    }
                });
            }
#endif
            return users;
        }
    }
}