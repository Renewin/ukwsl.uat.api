using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class User:Log
    {
        public int Id { get; set; }        

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string MobileNumber { get; set; }

        public string RoleName { get; set; }
        public string Roles { get; set; }
        public string EmailAddress { get; set; }

        public bool IsAuthenticated { get; set; }
        public int IsUserEmailExist { get; set; }

        public string DepartmentName { get; set; }
        public string FunctionName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string LandlineNo { get; set; }
        public int DepartmentId { get; set; }
        public int FunctionId { get; set; }
        public string JobTitle { get; set; }
        public string Ids { get; set; }
    }
}
