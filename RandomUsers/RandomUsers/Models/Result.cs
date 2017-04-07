using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUsers.Models
{
    public class ResultInfo
    {
        public string Seed { get; set; }
        public int Results { get; set; }
        public int Page { get; set; }
        public string Version { get; set; }
    }
    public class Result
    {
        public IEnumerable<User> Results { get; set; }
        public ResultInfo Info { get; set; }
    }
}
