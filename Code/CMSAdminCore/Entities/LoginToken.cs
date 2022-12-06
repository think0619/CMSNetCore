using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoginToken
    {
        public int recid { get; set; } 
        public string LoginGuid { get; set; } 
        public DateTime Createtime { get; set; }  
        public int Status { get; set; }   
    }
}
