using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharp
{
    public class UpdateMatchOptions
    {
        public string tournament { get; set; }  // Tournament ID(e.g. 10230) or URL(e.g. 'single_elim' for challonge.com/single_elim). If assigned to a subdomain, URL format must be :subdomain-:tournament_url(e.g. 'test-mytourney' for test.challonge.com/mytourney)
        public string match_id { get; set; }  // The match's unique ID 
        public string scores_csv { get; set; }  // Comma separated set/game scores with player 1 score first(e.g. "1-3,3-0,3-2")
        public string winner_id { get; set; }  // The participant ID of the winner or "tie" if applicable(Round Robin and Swiss). NOTE: If you change the outcome of a completed match, all matches in the bracket that branch from the updated match will be reset.
        public string player1_votes { get; set; }  // Overwrites the number of votes for player 1
        public string player2_votes { get; set; }  // Overwrites the number of votes for player 2

    }
}
