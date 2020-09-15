using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public  string RoleDesc { get; set; }
        public string RoleCode { get; set; }
        public bool IsPrimary { get; set; }
        public int TotalUsers { get; set; }
    }    
}
