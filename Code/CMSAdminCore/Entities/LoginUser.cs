using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoginUser
    {
        public int recid { get; set; }
        public string UserName { get; set; } 
        //MD5
        public string Password { get; set; } 
        public int Status { get; set; }
        public string UserInfo { get; set; } 
    }
}
