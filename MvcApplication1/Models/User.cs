using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class User
    {
        public int PK_user { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}