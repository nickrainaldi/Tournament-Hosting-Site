using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IUserDAL
    {
        User GetUser(string username, string password);
        User GetUser(string username);

        int CreateUser(User newUser);
    }
}
