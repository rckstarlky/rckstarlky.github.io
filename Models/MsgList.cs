using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class  MsgList
    {
        public Nullable<int> mobilenumber { get; set; }
        public string Email { get; set; }
        public string message { get; set; }
        public string Name { get; set; }
    }

    public class Ienummsg
    {
        public IEnumerable<MsgList> MsgList { get; set; }
    }
}