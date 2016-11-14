using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal
{
    public class Object
    {
        public string oType { get; set; }
        public string oValue { get; set; }
        public string oId { get; set; }
        public string oPassword { get; set; }
        public string oName { get; set; }

        public Object(string oType, string oName, string oId, string oPassword)
    {
        this.oType= oType;
        this.oName = oName;
        this.oId = oId;
        this.oPassword = oPassword;
    }
        public Object(string oType, string oId, string oValue)
        {
            this.oType = oType;
            this.oValue = oValue;
            this.oId = oId;
        }


    }

  
}