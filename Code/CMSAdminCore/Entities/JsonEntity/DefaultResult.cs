using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.JsonEntity
{
    public class DefaultResult
    {
        /// <summary>
        /// status:-1:need login;  0:Operate unseccssfully;  1:Operate seccessfully
        /// </summary>
        public int Status { get; set; }

        public string Msg { get; set; }
        public string Data { get; set; }
    }
}
