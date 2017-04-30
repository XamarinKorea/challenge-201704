using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge201704.XamarinKorea.Models
{
    /// <summary>
    /// 주소 정보 Class
    /// </summary>
    public class Address
    {
        /// <summary>
        /// get or set Street
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// get or set City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// get or set State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// get or set Post Code
        /// </summary>
        public string PostCode { get; set; }
    }
}
