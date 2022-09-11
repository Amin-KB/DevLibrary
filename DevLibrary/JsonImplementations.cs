using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevLibrary
{
    internal class JsonImplementations
    {
        public static string getRootPath(string rootFilename)
        {
            string _root;
            var rootDir = System.IO.Path.GetDirectoryName(
                      System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex matchThepath = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = matchThepath.Match(rootDir).Value;
            _root = Path.Combine(appRoot, rootFilename);

            return _root;
        }
        public static IConfiguration GetConfig(string appSettingsFile = "appSettings.json")
        {
            return new ConfigurationBuilder()
            .AddJsonFile(getRootPath(appSettingsFile))
            .Build();

        }


    }

    class Person
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alter")]
        public int Alter { get; set; }

        public Person(Guid id, string name, int alter)
        {
            Id = id;
            Name = name;
            Alter = alter;
        }

        public void SerializeDeserialize()
        {
            var person1 = new Person(Guid.NewGuid(), "John", 30);
            string json = JsonConvert.SerializeObject(person1);
            Console.WriteLine(json);
            var p = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(p.Id);
            Console.ReadLine();
        }

    }
}
