using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharp
{
    public class GetMatchesOptions
    {
        public string tournament { get; set; }  // Tournament ID(e.g. 10230) or URL(e.g. 'single_elim' for challonge.com/single_elim). If assigned to a subdomain, URL format must be :subdomain-:tournament_url(e.g. 'test-mytourney' for test.challonge.com/mytourney)
        public string state { get; set; }  // all(default), pending, open, complete
        public string participant_id { get; set; }  // Only retrieve matches that include the specified participant.

    }
}
