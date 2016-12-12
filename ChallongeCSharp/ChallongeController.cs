using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Validation;
using System.Collections;

namespace ChallongeCSharp
{
    public class ChallongeController
    {

        string baseUrl = "https://api.challonge.com/v1/";
        string userName = "WildLlama";
        string password = "0aM5gUBRyHIAyPNCmkOPgw6IBqwj6mUecwP5sNtl";

        public ChallongeController()
        {

        }
        public ChallongeController(string BaseUrl, string UserName, string Password)
        {
            baseUrl = BaseUrl;
            userName = UserName;
            password = Password;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);

            var response = client.Execute<T>(request);
            
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var applicationException = new ApplicationException(message, response.ErrorException);
                throw applicationException;
            }
            return response.Data;
        }

        public ChallongeTournament GetTournament(GetTournamentOptions options)
        {
            Require.Argument("tournament", options.tournament);

            var request = new RestRequest(Method.GET);
            request.Resource = "tournaments/{tournament}.json";
            request.AddParameter("tournament", options.tournament, ParameterType.UrlSegment);
            request.RootElement = "tournament";

            if (options.include_matches != null) request.AddParameter("include_matches", options.include_matches);
            if (options.include_participants != null) request.AddParameter("include_participants", options.include_participants);

            return Execute<ChallongeTournament>(request);
        }

        public List<ChallongeTournament> GetTournaments(GetTournamentsOptions options)
        {

            var request = new RestRequest(Method.GET);
            request.Resource = "tournaments.json";
            request.RootElement = "tournament";

            if (options.created_after != null) request.AddParameter("created_after", options.created_after);
            if (options.created_before != null) request.AddParameter("created_before", options.created_before);
            if (options.state != null) request.AddParameter("state", options.state);
            if (options.subdomain != null) request.AddParameter("subdomain", options.subdomain);
            if (options.type != null) request.AddParameter("type", options.type);

            return Execute<List<ChallongeTournament>>(request);
        }


        public ChallongeTournament CreateTournament(CreateTournamentOptions options)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "tournaments.json";
            request.RootElement = "tournament";

            if (options.accept_attachments != null) request.AddParameter("tournament[accept_attachments]", options.accept_attachments);
            if (options.check_in_duration != null) request.AddParameter("tournament[check_in_duration]", options.check_in_duration);
            if (options.description != null) request.AddParameter("tournament[description]", options.description);
            if (options.grand_finals_modifier != null) request.AddParameter("tournament[grand_finals_modifier]", options.grand_finals_modifier);
            if (options.hide_forum != null) request.AddParameter("tournament[hide_forum]", options.hide_forum);
            if (options.hold_third_place_match != null) request.AddParameter("tournament[hold_third_place_match]", options.hold_third_place_match);
            if (options.name != null) request.AddParameter("tournament[name]", options.name);
            if (options.notify_users_when_matches_open != null) request.AddParameter("tournament[notify_users_when_matches_open]", options.notify_users_when_matches_open);
            if (options.notify_users_when_the_tournament_ends != null) request.AddParameter("tournament[notify_users_when_the_tournament_ends]", options.notify_users_when_the_tournament_ends);
            if (options.open_signup != null) request.AddParameter("tournament[open_signup]", options.open_signup);
            if (options.@private != null) request.AddParameter("tournament[private]", options.@private);
            if (options.pts_for_bye != null) request.AddParameter("tournament[pts_for_bye]", options.pts_for_bye);
            if (options.pts_for_game_tie != null) request.AddParameter("tournament[pts_for_game_tie]", options.pts_for_game_tie);
            if (options.pts_for_game_win != null) request.AddParameter("tournament[pts_for_game_win]", options.pts_for_game_win);
            if (options.pts_for_match_tie != null) request.AddParameter("tournament[pts_for_match_tie]", options.pts_for_match_tie);
            if (options.pts_for_match_win != null) request.AddParameter("tournament[pts_for_match_win]", options.pts_for_match_win);
            if (options.ranked_by != null) request.AddParameter("tournament[ranked_by]", options.ranked_by);
            if (options.rr_pts_for_game_tie != null) request.AddParameter("tournament[rr_pts_for_game_tie]", options.rr_pts_for_game_tie);
            if (options.rr_pts_for_game_win != null) request.AddParameter("tournament[rr_pts_for_game_win]", options.rr_pts_for_game_win);
            if (options.rr_pts_for_match_tie != null) request.AddParameter("tournament[rr_pts_for_match_tie]", options.rr_pts_for_match_tie);
            if (options.rr_pts_for_match_win != null) request.AddParameter("tournament[rr_pts_for_match_win]", options.rr_pts_for_match_win);
            if (options.sequential_pairings != null) request.AddParameter("tournament[sequential_pairings]", options.sequential_pairings);
            if (options.show_rounds != null) request.AddParameter("tournament[show_rounds]", options.show_rounds);
            if (options.signup_cap != null) request.AddParameter("tournament[signup_cap]", options.signup_cap);
            if (options.start_at != null) request.AddParameter("tournament[start_at]", options.start_at);
            if (options.subdomain != null) request.AddParameter("tournament[subdomain]", options.subdomain);
            if (options.swiss_rounds != null) request.AddParameter("tournament[swiss_rounds]", options.swiss_rounds);
            if (options.tournament_type != null) request.AddParameter("tournament[tournament_type]", options.tournament_type);
            if (options.url != null) request.AddParameter("tournament[url]", options.url);

            return Execute<ChallongeTournament>(request);
        }

        public List<ChallongeParticipant> GetParticipants(GetParticipantsOptions options)
        {
            Require.Argument("tournament", options.tournament);

            var request = new RestRequest(Method.GET);
            request.Resource = "tournaments/{tournament}/participants.json";
            request.AddParameter("tournament", options.tournament, ParameterType.UrlSegment);
            request.RootElement = "participant";

            return Execute<List<ChallongeParticipant>>(request);
        }

        public ChallongeParticipant GetParticipant(GetParticipantOptions options)
        {
            Require.Argument("tournament", options.tournament);
            Require.Argument("participant_id", options.participant_id);

            var request = new RestRequest(Method.GET);
            request.Resource = "tournaments/{tournament}/participants/{participant_id}.json";
            request.AddParameter("tournament", options.tournament, ParameterType.UrlSegment);
            request.AddParameter("participant_id", options.participant_id, ParameterType.UrlSegment);
            request.RootElement = "participant";

            if (options.include_matches != null) request.AddParameter("include_matches", options.include_matches);

            return Execute<ChallongeParticipant>(request);
        }

        public ChallongeParticipant CreateParticipant(CreateParticipantOptions options)
        {
            Require.Argument("tournament", options.tournament);

            var request = new RestRequest(Method.POST);
            request.Resource = "tournaments/{tournament}/participants.json";
            request.AddParameter("tournament", options.tournament, ParameterType.UrlSegment);
            request.RootElement = "participant";

            if (options.challonge_username != null) request.AddParameter("participant[challonge_username]", options.challonge_username);
            if (options.email != null) request.AddParameter("participant[email]", options.email);
            if (options.misc != null) request.AddParameter("participant[misc]", options.misc);
            if (options.name != null) request.AddParameter("participant[name]", options.name);
            if (options.seed != null) request.AddParameter("participant[seed]", options.seed);

            return Execute<ChallongeParticipant>(request);
        }

        public void CreateParticipants(string tournament, string[] names)
        {
            CreateParticipantOptions options = new CreateParticipantOptions();
            options.tournament = tournament;
            foreach (var name in names)
            {
                options.name = name;
                ChallongeParticipant particiant = CreateParticipant(options);
            }
        }

        public List<ChallongeMatch> GetMatches(GetMatchesOptions options)
        {
            Require.Argument("tournament", options.tournament);

            var request = new RestRequest(Method.GET);
            request.Resource = "tournaments/{tournament}/matches.json";
            request.AddParameter("tournament", options.tournament, ParameterType.UrlSegment);
            request.RootElement = "match";

            if (options.participant_id != null) request.AddParameter("participant_id", options.participant_id);
            if (options.state != null) request.AddParameter("state", options.state);

            return Execute<List<ChallongeMatch>>(request);
        }

        public ChallongeMatch GetMatch(GetMatchOptions options)
        {
            Require.Argument("tournament", options.tournament);
            Require.Argument("match_id", options.match_id);

            var request = new RestRequest(Method.GET);
            request.Resource = "tournaments/{tournament}/matches/{match_id}.json";
            request.AddParameter("tournament", options.tournament, ParameterType.UrlSegment);
            request.AddParameter("match_id", options.match_id, ParameterType.UrlSegment);
            request.RootElement = "match";

            if (options.include_attachments != null) request.AddParameter("include_attachments", options.include_attachments);

            return Execute<ChallongeMatch>(request);
        }

        public ChallongeMatch UpdateMatch(UpdateMatchOptions options)
        {
            Require.Argument("tournament", options.tournament);
            Require.Argument("match_id", options.match_id);

            var request = new RestRequest(Method.PUT);
            request.Resource = "tournaments/{tournament}/matches/{match_id}.json";
            request.AddParameter("tournament", options.tournament, ParameterType.UrlSegment);
            request.AddParameter("match_id", options.match_id, ParameterType.UrlSegment);
            request.RootElement = "match";

            if (options.player1_votes != null) request.AddParameter("match[player1_votes]", options.player1_votes);
            if (options.player2_votes != null) request.AddParameter("match[player2_votes]", options.player2_votes);
            if (options.scores_csv != null) request.AddParameter("match[scores_csv]", options.scores_csv);
            if (options.winner_id != null) request.AddParameter("match[winner_id]", options.winner_id);

            return Execute<ChallongeMatch>(request);
        }

        public ChallongeTournament StartTournament(int id)
        {
            Require.Argument("tournament", id);

            var request = new RestRequest(Method.POST);
            request.Resource = "tournaments/{tournament}/start.json";
            request.AddParameter("tournament", id, ParameterType.UrlSegment);

            return Execute<ChallongeTournament>(request);
        }

        public ChallongeTournament ResetTournament(int id)
        {
            Require.Argument("tournament", id);

            var request = new RestRequest(Method.POST);
            request.Resource = "tournaments/{tournament}/reset.json";
            request.AddParameter("tournament", id, ParameterType.UrlSegment);

            return Execute<ChallongeTournament>(request);
        }


    }
}
