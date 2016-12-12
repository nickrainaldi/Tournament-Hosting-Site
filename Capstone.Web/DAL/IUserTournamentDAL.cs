using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    interface IUserTournamentDAL
    {
        UserTournament GetUserTournament(int user_id, int tournament_id);
        bool CreateUserTournament(int user_id, int tournament_id, int owner);
        bool CreateUserTournament(UserTournament newUserTournament);
        List<int> GetUserTournaments(int user_id);
    }
}
