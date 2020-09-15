using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Authentication
{
   public interface IAuthenticationRepository
    {
        User Login(string userName, string password);
        User GetUserdetails(string userName);
        UserInfo GetUserRolesByUserId(User user);
    }
}
