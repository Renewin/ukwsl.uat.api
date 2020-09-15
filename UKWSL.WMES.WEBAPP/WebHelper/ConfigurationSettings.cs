using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UKWSL.WMES.WEBAPP.WebHelper
{
    public static class ConfigurationSettings
    {

        private static string GetKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");
            var value = ConfigurationManager.AppSettings[key];
            return !string.IsNullOrEmpty("value") ? value.Trim() : string.Empty;

        }
    }
}