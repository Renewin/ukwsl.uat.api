using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Repositories.DbContext
{
   public class ContexDetails
    {
        public static string HubConnectiondetails()
        {
            return ConfigurationManager.ConnectionStrings["Hub2Connection"].ConnectionString;
        }
    }
}
