using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.Authentication;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.WEBAPP.Models;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    //[Authorize]
    public class AuthenticationController : ApiController
    {

        private  IAuthenticationManager authenticationManager;
        public AuthenticationController(IAuthenticationManager manager)
        {
            authenticationManager = manager;
        }
        public AuthenticationController()
        { }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Login")]
        public IHttpActionResult GetLoggedInUser()
        {
          
            var user = authenticationManager.GetLoggedInUser("a","aa");
            return Ok(user);
        }

        [HttpPost]
        [ActionName("GetUserRolesByUserId")]
        public IHttpActionResult GetUserRolesByUserId(User user)
        {
            var result = authenticationManager.GetUserRolesByUserId(user);
            return Ok(result);
        }
    }
}
