using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Xml.Serialization;
using CsvHelper;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace DataParsingServer
{
    public class Program
    {

        public static void Main(string[] args)
        {
            SerializeObjectToXmlString();
            SerializeObjectToXmlFile();
            Console.WriteLine("Xml file created...");
            SerializeListToXmlFile();
            Console.WriteLine("Xml list created...");
            DeserializeXmlFileToList();
            Console.WriteLine("List deserialized...");
            DeserializeXmlFileToObject();
            Console.WriteLine("Object deserialized...");
            SerializeObjectTJsonFile();
            Console.WriteLine("Json file created...");
            SerializeListToJsonFile();
            Console.WriteLine("Json list created...");
            DeserializeJsonFileToObject();
            Console.WriteLine("Json file deserialized...");
            SerializeListToCsvFile();
            Console.WriteLine("Csv list file created...");
            DeserializeCsvFileToList();
            Console.WriteLine("Csv list deserialized...");



            Console.ReadKey();

            

        }

        private static void SerializeObjectToXmlString()
        {
            var member = new Member
            {
                Name = "John Doe",
                Email = "John@gmail.com",
                Age = 25,
                JoiningDate = DateTime.Now,
                IsGoldMember = false
            };

            var xmlSerializer = new XmlSerializer(typeof(Member));
            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, member);
                var xmlContent = writer.ToString();
                Console.WriteLine(xmlContent);
                DeserializeXmlStringToObject(xmlContent);
            }
        }

        private static void SerializeObjectToXmlFile()
        {
            var member = new Member
            {
                Name = "John Doe",
                Email = "John@gmail.com",
                Age = 25,
                JoiningDate = DateTime.Now,
                IsGoldMember = false
            };

            var xmlSerializer = new XmlSerializer(typeof(Member));
            using (var writer = new StreamWriter(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample01.xml"))
            {
                xmlSerializer.Serialize(writer, member);
            }
        }

        private static void SerializeListToXmlFile()
        {
            var memberList = new List<Member>
            {
                new Member
                {
                    Name = "John Doe",
                    Email = "john@gmail.com",
                    Age = 25,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = false
                },
                new Member
                {
                    Name = "Bob Smith",
                    Email = "bob@gmail.com",
                    Age = 30,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = true
                },
                new Member
                {
                    Name = "Steve",
                    Email = "Steve@gmail.com",
                    Age = 28,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = true
                },
                new Member
                {
                    Name = "Andy",
                    Email = "Andy@gmail.com",
                    Age = 45,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = false
                }
            };

            var xmlSerializer = new XmlSerializer(typeof(List<Member>));
            using (var writer = new StreamWriter(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample02.xml"))
            {
                xmlSerializer.Serialize(writer, memberList);
            }
        }

        private static void DeserializeXmlStringToObject(string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(Member));
            using (var reader = new StringReader(xmlString))
            {
                var member = (Member)xmlSerializer.Deserialize(reader);
            }
        }

        private static void DeserializeXmlFileToList()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Member>));
            using (var reader =
                   new StreamReader(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample02.xml"))
            {
                var memberList = (List<Member>)xmlSerializer.Deserialize(reader);
                foreach (var member in memberList)
                {
                    Console.WriteLine($"Name: {member.Name}, Email: {member.Email}, Age: {member.Age}, Joining Date: {member.JoiningDate}, Is Gold Member: {member.IsGoldMember}");
                }
            }
        }

        private static void DeserializeXmlFileToObject()
        {
            var xmlSerializer = new XmlSerializer(typeof(Member));
            using (var reader =
                   new StreamReader(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample01.xml"))
            {
                var member = (Member)xmlSerializer.Deserialize(reader);
                Console.WriteLine($"Name: {member.Name}, Email: {member.Email}, Age: {member.Age}, Joining Date: {member.JoiningDate}, Is Gold Member: {member.IsGoldMember}");
            }
        }


        //seriializing to json
        private static void SerializeObjectTJsonFile()
        {
            var member = new Member()
            {
                Name = "Jason",
                Email = "Jayson@gmail.com",
                Age = 28,
                JoiningDate = DateTime.Now,
                IsGoldMember = true
            };

            string json = JsonConvert.SerializeObject(member, Newtonsoft.Json.Formatting.Indented);

            System.Console.WriteLine(json);
        }


        private static void SerializeListToJsonFile()
        {
            var memberList = new List<Member>
            {
                new Member
                {
                    Name = "John Doe",
                    Email = "john@gmail.com",
                    Age = 25,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = false
                },
                new Member
                {
                    Name = "Bob Smith",
                    Email = "bob@gmail.com",
                    Age = 30,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = true
                },
                new Member
                {
                    Name = "Steve",
                    Email = "Steve@gmail.com",
                    Age = 28,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = true
                },
                new Member
                {
                    Name = "Andy",
                    Email = "Andy@gmail.com",
                    Age = 45,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = false
                }
            };

            string json = JsonConvert.SerializeObject(memberList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample04.json", json);
            System.Console.WriteLine(json);


        }

        //deserializing from json
        private static void DeserializeJsonFileToObject()
        {
            var memberJson = File.ReadAllText(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample04.json");
            List<Member> memberList = JsonConvert.DeserializeObject<List<Member>>(memberJson);
            foreach (var member in memberList)
            {
                Console.WriteLine($"Name: {member.Name}, Email: {member.Email}, Age: {member.Age}, Joining Date: {member.JoiningDate}, Is Gold Member: {member.IsGoldMember}");
            }

        }
        

        //csv

        private static void SerializeListToCsvFile()
        {
            var memberList = new List<Member>
            {
                new Member
                {
                    Name = "John Doe",
                    Email = "john@gmail.com",
                    Age = 25,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = false
                },
                new Member
                {
                    Name = "Bob Smith",
                    Email = "bob@gmail.com",
                    Age = 30,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = true
                },
                new Member
                {
                    Name = "Steve",
                    Email = "Steve@gmail.com",
                    Age = 28,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = true
                },
                new Member
                {
                    Name = "Andy",
                    Email = "Andy@gmail.com",
                    Age = 45,
                    JoiningDate = DateTime.Now,
                    IsGoldMember = false
                }
            };
            using var writer = new StreamWriter(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample05.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(memberList);

        }


        private static void DeserializeCsvFileToList()
        {
            using var reader = new StreamReader(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample05.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Member>().ToList();
            foreach (var member in records)
            {
                Console.WriteLine($"Name: {member.Name}, Email: {member.Email}, Age: {member.Age}, Joining Date: {member.JoiningDate}, Is Gold Member: {member.IsGoldMember}");
            }
        }
    }

     
}
