using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Utility
{
    public static class FieldValidation
    {

        public static decimal ToDecimal(object val)
        {
            if (val is DBNull ||
                val == null)
            {
                return 0;
            }
            if (val is string &&
                ((string)val).Length == 0)
            {
                return 0;
            }
            return Convert.ToDecimal(val);
        }

        public static int ToInteger(object val)
        {
            if (val is DBNull ||
                val == null)
            {
                return 0;
            }
            if (val is string &&
                ((string)val).Length == 0)
            {
                return 0;
            }
            return Convert.ToInt32(val);
        }

        public static string ValidateNullValue(string sStringValue)
        {
            if (string.IsNullOrEmpty(sStringValue))
            {
                return null;
            }
            else
            {
                return sStringValue;
            }
        }

        public static dynamic ValidateDBNullValue(string sStringValue)
        {
            if (string.IsNullOrEmpty(sStringValue))
            {
                return DBNull.Value;
            }
            else
            {
                return sStringValue;
            }
        }
    }
}
