using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharp
{
    public class GetTournamentsOptions
    {
        public string state { get; set; }   // all, pending, in_progress, ended
        public string type { get; set; }       // single_elimination, double_elimination, round_robin, swiss
        public string created_after { get; set; }  // YYYY-MM-DD
        public string created_before { get; set; }  // YYYY-MM-DD
        public string subdomain { get; set; }   // A Challonge subdomain you've published tournaments to. NOTE: Until v2 of our API, the subdomain parameter is required to retrieve a list of your organization-hosted tournaments.
    }
}
