using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.WEBAPP.Models
{
    public class UserViewModel
    {
        public  User Users { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}