using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using CsvHelper;
using Newtonsoft.Json;

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
            EncodeJsonObject();
            //Console.WriteLine("Json object encoded...");
            DecodeJsonObject();
            //Console.WriteLine("Json object decoded...");
            EncodeXmlObject();
            DecodeXmlObject();
            EncodeCsvList();
            DecodeCsvList();


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
            using (var writer =
                   new StreamWriter(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample01.xml"))
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
            using (var writer =
                   new StreamWriter(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample02.xml"))
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
                    Console.WriteLine(
                        $"Name: {member.Name}, Email: {member.Email}, Age: {member.Age}, Joining Date: {member.JoiningDate}, Is Gold Member: {member.IsGoldMember}");
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
                Console.WriteLine(
                    $"Name: {member.Name}, Email: {member.Email}, Age: {member.Age}, Joining Date: {member.JoiningDate}, Is Gold Member: {member.IsGoldMember}");
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
            var memberJson =
                File.ReadAllText(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample04.json");
            List<Member> memberList = JsonConvert.DeserializeObject<List<Member>>(memberJson);
            foreach (var member in memberList)
            {
                Console.WriteLine(
                    $"Name: {member.Name}, Email: {member.Email}, Age: {member.Age}, Joining Date: {member.JoiningDate}, Is Gold Member: {member.IsGoldMember}");
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
            using var writer =
                new StreamWriter(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample05.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(memberList);

        }


        private static void DeserializeCsvFileToList()
        {
            using var reader =
                new StreamReader(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample05.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Member>().ToList();
            foreach (var member in records)
            {
                Console.WriteLine(
                    $"Name: {member.Name}, Email: {member.Email}, Age: {member.Age}, Joining Date: {member.JoiningDate}, Is Gold Member: {member.IsGoldMember}");
            }
        }

        private static void EncodeJsonObject()
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

            Console.WriteLine("json object before encoding..");
            Console.WriteLine(json);

            byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
            string encodedJson = Convert.ToBase64String(encodedBytes);
            Console.WriteLine("encoded json object..");
            Console.WriteLine(encodedJson);

        }

        private static void DecodeJsonObject()
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
            byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
            string encodedJson = Convert.ToBase64String(encodedBytes);

            //string encodedJson = "eyJUaW1lIjoxNjI5MzYwNzEwMzY3LCJJc0dvbGRTZW5kIjpmYWxzZSwiTmFtZSI6Ikphc29uIiwiRW1haWwiOiJKYXlzb25AZ21haWwuY29tIiwiQWdlIjoyOH0=";
            byte[] decodedBytes = Convert.FromBase64String(encodedJson);
            string decodedJson = Encoding.UTF8.GetString(decodedBytes);
            Console.WriteLine("decoded json object..");
            Console.WriteLine(decodedJson);
        }

        private static void EncodeXmlObject()
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
            using (var writer =
                   new StreamWriter(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample06.xml"))
            {
                xmlSerializer.Serialize(writer, member);
            }

            string xml = File.ReadAllText(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample06.xml");
            Console.WriteLine("xml object before decoding...");
            Console.WriteLine(xml);
            byte[] encodedBytes = Encoding.UTF8.GetBytes(xml);
            string encodedXml = Convert.ToBase64String(encodedBytes);
            Console.WriteLine("xml object after decoding...");
            Console.WriteLine(encodedXml);


        }

        private static void DecodeXmlObject()
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
            using (var writer =
                   new StreamWriter(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample06.xml"))
            {
                xmlSerializer.Serialize(writer, member);
            }

            string xml = File.ReadAllText(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample06.xml");
            byte[] encodedBytes = Encoding.UTF8.GetBytes(xml);
            string encodedXml = Convert.ToBase64String(encodedBytes);

            byte[] decodedBytes = Convert.FromBase64String(encodedXml);
            string decodedXml = Encoding.UTF8.GetString(decodedBytes);
            Console.WriteLine("decoded xml object...");
            Console.WriteLine(decodedXml);
        }

        private static void EncodeCsvList()
        {
            string csvString = File.ReadAllText(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample05.csv");
            Console.WriteLine("csv object before encoding...");
            Console.WriteLine(csvString);
            byte[] encodedBytes = Encoding.UTF8.GetBytes(csvString);
            string encodedCsv = Convert.ToBase64String(encodedBytes);
            Console.WriteLine("csv object after encoding...");
            Console.WriteLine(encodedCsv);

            using var writer =
                new StreamWriter(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample08.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(encodedCsv);


        }

        private static void DecodeCsvList()
        {
            string csvString = File.ReadAllText(@"C:\Users\T580\source\repos\DataParsingServer\MemberFiles\sample08.csv");
            byte[] decodedBytes = Convert.FromBase64String(csvString);
            string decodedCsv = Encoding.UTF8.GetString(decodedBytes);
            Console.WriteLine("decoded csv object...");
            Console.WriteLine(decodedCsv);
        }
    }
}
