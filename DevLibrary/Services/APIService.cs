using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLibrary.Services
{
    class Validation
    {
        [JsonProperty("object_or_array")]
        public string Object_or_array { get; set; }
        [JsonProperty("empty")]
        public bool Empty { get; set; }
        [JsonProperty("parse_time_nanoseconds")]
        public string ParseTime { get; set; }
        [JsonProperty("validate")]
        public bool Validate { get; set; }
        [JsonProperty("size")]
        public byte Size { get; set; }
    }
    public class Person
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
    }
    internal class APIService
    {
        public void WorkingWithSingleObjectAPI()
        {
            var person1 = new Person(Guid.NewGuid(), "John", 30);
            string json = JsonConvert.SerializeObject(person1);
            Console.WriteLine(json);
            var p = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(p.Id);
            
        }
        public void WorkingWithListOfObjectAPI()
        {
            List<Validation> validations = new List<Validation>();
            Validation vl = new Validation();
            Validation vl2 = new Validation();
            vl.Empty = false;
            vl.Object_or_array = "aa";
            vl.ParseTime = "12";
            vl.Validate = false;
            vl.Size = 1;

            vl2.Empty = false;
            vl2.Object_or_array = "aa";
            vl2.ParseTime = "12";
            vl2.Validate = false;
            vl2.Size = 1;
            validations.Add(vl);
            validations.Add(vl2);

            string json = JsonConvert.SerializeObject(validations, Formatting.Indented);
            List<Validation> validations2 = JsonConvert.DeserializeObject<List<Validation>>(json);
            foreach (var item in validations2)
            {
                Console.WriteLine("Object_or_array: " + item.Object_or_array);
                Console.WriteLine("Empty: " + item.Empty);
                Console.WriteLine("Parse_time_nanoseconds: " + item.ParseTime);
                Console.WriteLine("Validate: " + item.Validate);
                Console.WriteLine("Size: " + item.Size);
            }
        }
    }
}
