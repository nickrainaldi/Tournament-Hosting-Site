using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Capstone.Web.Crypto;
using ChallongeCSharp;
using System.Configuration;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private string user_id = "user_id";
        private string loginModel = "loginModel";
        private string email = "email";
        private IUserDAL userDal;
        private const string UsernameKey = "UserName";

        public HomeController(IUserDAL userDal)
        {
            this.userDal = userDal;
        }

        //public ActionResult MakeTournament()
        //{
        //    Tournament tournament = new Tournament();
        //    return View("MakeTournament", tournament);
        //}



        // GET: Home
        public ActionResult Landing()
        {
            if (Session[loginModel] != null)
            {
                return RedirectToAction("UserDashboard", Session[user_id]);
            }
            return View("Landing");
        }

        [HttpGet]
        public ActionResult NewUser()
        {
            return View("NewUser");
        }

        [HttpPost]
        //[Route("users/new")]
        public ActionResult NewUser(RegisterViewModel model)
        {

            var currentUser = userDal.GetUser(model.Email, model.Password);

            if (currentUser != null)
            {

                return View("NewUser");
            }


            var hashProvider = new HashProvider();
            var hashedPassword = hashProvider.HashPassword(model.Password);
            var salt = hashProvider.SaltValue;

            var newUser = new User
            {
                email = model.Email,
                password = hashedPassword,
                name = model.Name,
                Salt = salt
            };

            // Add the user to the database
            newUser.user_id = userDal.CreateUser(newUser);

            //// Log the user in and redirect to the dashboard
            //base.LogUserIn(model.Username);
            //return RedirectToAction("Dashboard", "Messages", new { username = model.Username });



            LogUserIn(newUser);
            return RedirectToAction("UserDashboard", Session[user_id]);
        }


        [HttpGet]
        public ActionResult UserDashboard(string name)
        {
            TournamentHolder tournHolder = GetUserTournaments();
            return View("UserDashboard", tournHolder);

        }


        [HttpGet]
        public ActionResult TournamentDetail(int id)
        {
            ChallongeController challonge = new ChallongeController();
            GetTournamentOptions options = new GetTournamentOptions();
            options.tournament = id.ToString();
            ChallongeTournament tournament = challonge.GetTournament(options);
            return View("TournamentDetail", tournament);

        }

        [HttpGet]
        public ActionResult JoinTournament()
        {
            JoinTournament tournament = new JoinTournament
            {
                name = (string)(Session[email]),
            };
            return View("JoinTournament", tournament);
        }

        [HttpPost]
        public ActionResult JoinTournament(JoinTournament joinTournament)
        {
            ChallongeController challonge = new ChallongeController();
            CreateParticipantOptions options = new CreateParticipantOptions();
            options.tournament = joinTournament.url;
            options.name = joinTournament.name;
            ChallongeParticipant participant = challonge.CreateParticipant(options);

            if (participant.errors != null && participant.errors.Count > 0)
            {
                ViewBag.ErrorMessage = string.Join("\n", participant.errors);
            }

            // store this tournamentId and userId in table that maps userId to tournamentId (table is called UsersTournaments)
            UserTournamentDAL utd = new UserTournamentDAL(ConfigurationManager.ConnectionStrings["TournamentWebsite"].ConnectionString);

            // replace 1 with user_id
            utd.CreateUserTournament(Convert.ToInt32(Session[user_id]), participant.tournament_id, 0);

            return RedirectToAction("UserDashboard");
        }

        private TournamentHolder GetUserTournaments()
        {
            List<ChallongeTournament> ownerList = new List<ChallongeTournament>();
            List<ChallongeTournament> participantList = new List<ChallongeTournament>();
            UserTournamentDAL utd = new UserTournamentDAL(ConfigurationManager.ConnectionStrings["TournamentWebsite"].ConnectionString);
            var id = Session[user_id];



            List<int> ownedTournamentIDs = utd.GetUserTournaments(int.Parse(id.ToString()), 1);



            foreach (var ownedID in ownedTournamentIDs)
            {
                ChallongeController challonge = new ChallongeController();
                GetTournamentOptions options = new GetTournamentOptions();
                options.tournament = ownedID.ToString();
                ChallongeTournament tournament = challonge.GetTournament(options);

                ownerList.Add(tournament);
            }

            List<int> participantTournamentIDs = utd.GetUserTournaments(int.Parse(id.ToString()), 0);
            foreach (var participantID in participantTournamentIDs)
            {
                ChallongeController challonge = new ChallongeController();
                GetTournamentOptions options = new GetTournamentOptions();
                options.tournament = participantID.ToString();
                ChallongeTournament tournament = challonge.GetTournament(options);

                participantList.Add(tournament);
            }


            //System.IO.File.WriteAllText(@"C:\Users\James Colwill\Desktop\New Text Document.json", json);
            TournamentHolder tournHolder = new TournamentHolder();
            tournHolder.ownerList = ownerList;
            tournHolder.participantList = participantList;
            return tournHolder;



        }



        /// <summary>
        /// "Logs" the current user in
        /// </summary>
        public void LogUserIn(User model)
        {
            Session[user_id] = model.user_id;
            Session[loginModel] = model;
            Session[email] = model.email;
            Session[UsernameKey] = model.name;
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            var user = userDal.GetUser(model.Email);

            // No user found with these credentials
            if (user == null)
            {
                ViewBag.ErrorMessage = "The username or password provided is invalid";
                return View("NewUser");
            }

            var hashProvider = new HashProvider();
            if (!hashProvider.VerifyPasswordMatch(user.password, model.Password, user.Salt))
            {
                ViewBag.ErrorMessage = "The username or password provided is invalid";
                return (View("NewUser", model));
            }

            // Happy Path
            LogUserIn(user);
            return RedirectToAction("UserDashboard", Session[user_id]);


        }

        [HttpGet]
        //[Route("users/new")]
        public ActionResult MakeTournament()
        {

            NewTournament tournament = new NewTournament();
            tournament.url = GenerateURL();

            return View("MakeTournament", tournament);
        }

        [HttpPost]
        public ActionResult MakeTournament(NewTournament model)
        {

            ChallongeController challonge = new ChallongeController();
            CreateTournamentOptions options = new CreateTournamentOptions();
            options.name = model.name;
            options.url = model.url;
            options.tournament_type = model.tournament_type;
            options.signup_cap = model.signup_cap;

            DateTime dt = Convert.ToDateTime(model.start_at);
            options.start_at = dt;//model.start_at;
            options.description = model.description;
            ChallongeTournament tournamnet = challonge.CreateTournament(options);


            UserTournamentDAL utd = new UserTournamentDAL(ConfigurationManager.ConnectionStrings["TournamentWebsite"].ConnectionString);

            // replace 1 with user_id
            utd.CreateUserTournament(Convert.ToInt32(Session[user_id]), tournamnet.id, 1);

            return RedirectToAction("UserDashboard", Session[user_id]);
        }



        [HttpPost]
        public ActionResult CreateParticipants(string participants, string url, string full_challonge_url, int id)
        {

            ChallongeController challonge = new ChallongeController();
            ChallongeTournament tournament = new ChallongeTournament();
            tournament.full_challonge_url = full_challonge_url;
            tournament.url = url;
            tournament.id = id;
            string[] result = tournament.getArray(participants);
            challonge.CreateParticipants(url, result);

            return RedirectToAction("TournamentDetail", new { id = tournament.id });
            //return RedirectToAction("UserDashboard", Session[user_id]);

        }

        [HttpPost]
        public ActionResult InviteParticipants(string emails, int id)
        {
            MailService service = new MailService();
            string[] result = service.getArray(emails);

            for (int i = 0; i < result.Length; i++)
            {
                service.SendEmail(result[i], id.ToString());
            }


            return RedirectToAction("TournamentDetail", new { id = id });
            //return RedirectToAction("UserDashboard", Session[user_id]);
        }


        [HttpPost]
        public ActionResult StartTournament(int id)
        {

            ChallongeController challonge = new ChallongeController();

            challonge.StartTournament(id);

            return RedirectToAction("TournamentDetail", new { id = id });
            //return RedirectToAction("UserDashboard", Session[user_id]);

        }

        [HttpPost]
        public ActionResult ResetTournament(int id)
        {

            ChallongeController challonge = new ChallongeController();

            challonge.ResetTournament(id);

            return RedirectToAction("TournamentDetail", new { id = id });
            //return RedirectToAction("UserDashboard", Session[user_id]);

        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Landing", "Home");
        }
        public string GenerateURL()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[16];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
