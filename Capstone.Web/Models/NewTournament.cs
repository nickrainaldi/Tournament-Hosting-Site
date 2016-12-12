using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class NewTournament
    {
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Tournament Name must contain letters only")]
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tournament name must be between 3 and 20 characters")]
        public string name { get; set; }
        public string tournament_type { get; set; }
        public string url { get; set; }
        public string subdomain { get; set; }    // subdomain.challonge.com/url (Requires write access to the specified subdomain)
        public string description { get; set; }    // Description/instructions to be displayed above the bracket
        public string open_signup { get; set; }    // True or false. Have Challonge host a sign-up page(otherwise, you manually add all participants)
        public string hold_third_place_match { get; set; }    // True or false - Single Elimination only.Include a match between semifinal losers? (default: false)
        public string pts_for_match_win { get; set; }    // Decimal(to the nearest tenth) - Swiss only - default: 1.0
        public string pts_for_match_tie { get; set; }    // Decimal(to the nearest tenth) - Swiss only - default: 0.5
        public string pts_for_game_win { get; set; }    // Decimal(to the nearest tenth) - Swiss only - default: 0.0
        public string pts_for_game_tie { get; set; }    // Decimal(to the nearest tenth) - Swiss only - default: 0.0
        public string pts_for_bye { get; set; }    // Decimal(to the nearest tenth) - Swiss only - default: 1.0
        public string swiss_rounds { get; set; }    // Integer - Swiss only - We recommend limiting the number of rounds to less than two-thirds the number of players.Otherwise, an impossible pairing situation can be reached and your tournament may end before the desired number of rounds are played.
        public string ranked_by { get; set; }    // One of the following: 'match wins', 'game wins', 'points scored', 'points difference', 'custom'
        public string rr_pts_for_match_win { get; set; }    // Decimal (to the nearest tenth) - Round Robin "custom only" - default: 1.0
        public string rr_pts_for_match_tie { get; set; }    // Decimal(to the nearest tenth) - Round Robin "custom" only - default: 0.5
        public string rr_pts_for_game_win { get; set; }    // Decimal(to the nearest tenth) - Round Robin "custom" only - default: 0.0
        public string rr_pts_for_game_tie { get; set; }    // Decimal(to the nearest tenth) - Round Robin "custom" only - default: 0.0
        public string accept_attachments { get; set; }    // True or false - Allow match attachment uploads(default: false)
        public string hide_forum { get; set; }    // True or false - Hide the forum tab on your Challonge page(default: false)
        public string show_rounds { get; set; }    // True or false - Single &amp; Double Elimination only - Label each round above the bracket(default: false)
        public string @private { get; set; }    // True or false - Hide this tournament from the public browsable index and your profile(default: false)
        public string notify_users_when_matches_open { get; set; }    // True or false - Email registered Challonge participants when matches open up for them(default: false)
        public string notify_users_when_the_tournament_ends { get; set; }    // True or false - Email registered Challonge participants the results when this tournament ends (default: false)
        public string sequential_pairings { get; set; }    // True or false - Instead of traditional seeding rules, make pairings by going straight down the list of participants. First round matches are filled in top to bottom, then qualifying matches (if applicable). (default: false)
        [Required(ErrorMessage = "Please enter the number of participants")]
        [RegularExpression(@"^([2-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-6])$", ErrorMessage = "Number of Participants must be between 2 and 256")]
        public string signup_cap { get; set; }    // Integer - Maximum number of participants in the bracket. A waiting list (attribute on Participant) will capture participants once the cap is reached.
        public string start_at { get; set; }    // Datetime - the planned or anticipated start time for the tournament (Used with check_in_duration to determine participant check-in window). Timezone defaults to Eastern.
        public string check_in_duration { get; set; }    // Integer - Length of the participant check-in window in minutes.
        public string grand_finals_modifier { get; set; }    // String - This option only affects double elimination. null/blank (default) - give the winners bracket finalist two chances to beat the losers bracket finalist, 'single match' - create only one grand finals match, 'skip' - don't create a finals match between winners and losers bracket finalists
        
    }
}