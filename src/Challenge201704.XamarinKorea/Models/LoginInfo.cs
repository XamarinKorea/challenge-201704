using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge201704.XamarinKorea.Models
{
    /// <summary>
    /// LoginInfo Class
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// get or set UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// get or set Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// get or set Salt
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// get or set Md5
        /// </summary>
        public string Md5 { get; set; }
        /// <summary>
        /// get or set Sha1
        /// </summary>
        public string Sha1 { get; set; }
        /// <summary>
        /// get or set Sha256
        /// </summary>
        public string Sha256 { get; set; }
    }
}
