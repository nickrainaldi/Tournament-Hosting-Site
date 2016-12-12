using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class MailService
    {
        
        public void SendEmail(string email, string tournamentId)
        {
            try 
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("tourntup@gmail.com", "GetTournt1234");
                MailMessage message = new MailMessage();
                message.To.Add(email);
                message.Subject = "You're Invited!";
                message.From = new MailAddress("tourntup@gmail.com");
                message.Body = string.Format("You've been invited to join a tournament. Please visit www.tourntup.com to make an account, and join the tournament. You're tournament ID is {0}.", tournamentId);

                client.Send(message);
            }
            catch(Exception e)
            {

            }
            
        }

        public string[] getArray(string names)
        {
            string[] result = names.Split(' ', ',');
            return result;

        }
    }
}