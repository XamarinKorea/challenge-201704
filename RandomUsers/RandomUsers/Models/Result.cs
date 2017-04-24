using System.Collections.Generic;

namespace RandomUsers.Models
{
    public class Result
    {
        public IEnumerable<User> Results { get; set; }
        public ResultInfo Info { get; set; }
    }
}
