using ChallongeCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class TournamentHolder
    {
        public List<ChallongeTournament> ownerList { get; set; }
        public List<ChallongeTournament> participantList { get; set; }

    }
}