using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class User
    {
        public int user_id { get; set; }

        public string name { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string Salt { get; set; }

    }
}