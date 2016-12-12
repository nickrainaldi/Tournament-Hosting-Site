using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class UserTournament
    {
        public int user_id { get; set; }
        public int tournament_id { get; set; }
        public bool owner { get; set; }
    }
}