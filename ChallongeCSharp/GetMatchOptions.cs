using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharp
{
    public class GetMatchOptions
    {
        public string tournament { get; set; }  // Tournament ID(e.g. 10230) or URL(e.g. 'single_elim' for challonge.com/single_elim). If assigned to a subdomain, URL format must be :subdomain-:tournament_url(e.g. 'test-mytourney' for test.challonge.com/mytourney)
        public string match_id { get; set; }  // The match's unique ID 
        public string include_attachments { get; set; }  // 0 or 1; include an array of associated attachment records

    }
}
