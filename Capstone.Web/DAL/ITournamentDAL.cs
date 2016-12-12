using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface ITournamentDAL
    {


        Tournament GetTournament(string username, string id);
        Tournament GetTournament(string username);
        Tournament CreateTournament(string name, string url, string type, string format);

        
    }
}
