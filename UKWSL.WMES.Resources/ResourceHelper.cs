using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UKWSL.WMES.Resources
{
   public class ResourceHelper
    {
        private ResourceManager ResourceManager { get; set; }
        /// <summary>
        ///     ResourceHelper
        /// </summary>
        /// <param name="resourceName">i.e. "Namespace.ResourceFileName"</param>
        /// <param name="assembly">i.e. GetType().Assembly if working on the local assembly</param>
        public ResourceHelper(string resourceName)
        {
            ResourceManager = new ResourceManager(string.Format("{0}.{1}", "UKWSL.WMES.Resources", resourceName), Assembly.GetExecutingAssembly());
        }

        public Dictionary<string, string> GetAll()
        {
            var dictionaryEntries = ResourceManager.GetResourceSet(Thread.CurrentThread.CurrentCulture, true, true).OfType<DictionaryEntry>();
            return dictionaryEntries.ToDictionary(d => d.Key.ToString(), d => d.Value.ToString());
        }
        public string GetValue(string name)
        {
            return ResourceManager.GetString(name);
        }
        public static string GetValidationMessage(string key)
        {
            var resourceHelper = new ResourceHelper("ValidationMessage");
            var value = resourceHelper.GetValue(key);
            return value;
        }
    }
}
