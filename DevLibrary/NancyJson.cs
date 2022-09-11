using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLibrary
{
    internal class NancyJson
    {
        string path = "";
        public void SaveJSON()
        {
            List<object> objects = new List<object>();
            JavaScriptSerializer javascriptSerializer = new JavaScriptSerializer();
            var ourJSONData = javascriptSerializer.Serialize(objects);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(ourJSONData);
            }

        }
        public void LoadJSON()
        {
            List<object> objects = new List<object>();
            JavaScriptSerializer javascriptSerializer = new JavaScriptSerializer();
            string ourJSONData = null;

            using (StreamReader sw = new StreamReader(path))
            {
                ourJSONData = sw.ReadToEnd();
            }

            dynamic listOfObjects = javascriptSerializer.Deserialize<List<object>>(ourJSONData);
            objects = listOfObjects;

            
        }
    }
}
