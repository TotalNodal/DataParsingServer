using System;
using System.Xml.Serialization;

namespace DataParsingServer
{
    [Serializable]
    public class Member
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsGoldMember { get; set; }

    }
}
