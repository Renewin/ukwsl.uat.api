using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UKWSL.WMES.WEBAPP.Validations
{
    public static class FieldValidator
    {

        public static bool NumberValidatorWithoutZero(string number)
        {
            bool result = false;
            if (string.IsNullOrEmpty(number))
            {
                result = true;
            }
            else
            {
                int n;
                bool isNumeric = int.TryParse(number, out n);
                if (isNumeric)
                {
                    result = n != 0 ? false : true;


                }
                else
                {
                    result = true;
                }
            }
            return result;
        }


        public static bool NumberValidatorWithZero(string number)
        {
            bool result = false;
            if (string.IsNullOrEmpty(number))
            {
                result = true;
            }
            else
            {
                int n;
                bool isNumeric = int.TryParse(number, out n);

                if (isNumeric)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool DecimalValidator(string decimals)
        {
            bool result = false;
            if (string.IsNullOrEmpty(decimals))
            {
                result = true;
            }
            else
            {
                decimal n;
                bool isNumeric = decimal.TryParse(decimals, out n);

                if (isNumeric)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;

        }
    }
}