using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using System.Web.Security;

namespace SportsStore.Domain.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            //bool isValidate = FormsAuthentication.Authenticate(username, password);
            bool isValidate = username == "Raymond";
            if (isValidate) FormsAuthentication.SetAuthCookie(username, false);

            return isValidate;
        }
    }
}
