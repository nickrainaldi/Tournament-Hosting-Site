using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Models.Tests
{
    [TestClass()]
    public class MailServiceTests
    {
        [TestMethod()]
        public void SendEmailTest()
        {
            
            MailService service = new MailService();
            service.SendEmail("colwill.james@gmail.com","1");
        }
    }
}