using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Repositories.Authentication;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Authentication
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private IAuthenticationRepository _authenticateRepository;
        public AuthenticationManager(IAuthenticationRepository authenticateRepository)
        {
            _authenticateRepository = authenticateRepository;
        }

        public AuthenticationManager()
        {
            _authenticateRepository = new AuthenticationRepository();
        }

        public User GetLoggedInUser(string userName, string password)
        {
            User objUser = new User();

            objUser = _authenticateRepository.Login(userName, password);
            return objUser;
        }

        public UserInfo GetUserRolesByUserId(User user)
        {
            return _authenticateRepository.GetUserRolesByUserId(user);
        }
    }
}
