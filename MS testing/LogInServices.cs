using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax_Squad
{
    public class LogInServices
    {
        private List<User> _allTheUsers;

        public LogInServices(List<User> allTheUsers)
        {
            _allTheUsers = allTheUsers;
        }

        public string LogIn(string username, string password)
        {
            User userTryLogin = _allTheUsers.Find(x => x.Name == username && x.Password == password);

            if (userTryLogin != null)
            {
                return "\tLogin successful! press enter to continue to menu.";
            }
            else
            {
                return "\tIncorrect username or password.";
            }
        }
    }
}
