﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharp
{
    public class CreateParticipantOptions
    {

        public string tournament { get; set; }  // Tournament ID(e.g. 10230) or URL(e.g. 'single_elim' for challonge.com/single_elim). If assigned to a subdomain, URL format must be :subdomain-:tournament_url(e.g. 'test-mytourney' for test.challonge.com/mytourney)
        public string name { get; set; }  // The name displayed in the bracket/schedule - not required if email or challonge_username is provided.Must be unique per tournament.
        public string challonge_username { get; set; }  // Provide this if the participant has a Challonge account. He or she will be invited to the tournament.
        public string email { get; set; }  // Providing this will first search for a matching Challonge account. If one is found, this will have the same effect as the "challonge_username" attribute.If one is not found, the "new-user-email" attribute will be set, and the user will be invited via email to create an account. 
        public string seed { get; set; }  // integer - The participant's new seed. Must be between 1 and the current number of participants (including the new record). Overwriting an existing seed will automatically bump other participants as you would expect. 
        public string misc { get; set; }  // string - Max: 255 characters.Multi-purpose field that is only visible via the API and handy for site integration (e.g.key to your users table) 

    }
}
