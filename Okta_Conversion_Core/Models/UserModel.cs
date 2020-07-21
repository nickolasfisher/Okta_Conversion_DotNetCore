using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Okta_Conversion_Core.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string website { get; set; }
    }
}
