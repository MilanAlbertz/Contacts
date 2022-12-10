using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace Contacts.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [TextBlob("LearnedSkillsBlobbed")]
        public List<Skill> LearnedSkills { get; set; }
        public string LearnedSkillsBlobbed { get; set; }
        [TextBlob("EmailAdressesBlobbed")]
        public List<string> EmailAdresses { get; set; }
        public string EmailAdressesBlobbed { get; set; }
        [TextBlob("PhoneNumbersBlobbed")]
        public List<string> PhoneNumbers { get; set; }
        public string PhoneNumbersBlobbed { get; set; }

        public Contact()
        {
            PhoneNumbers = new List<string>();
            EmailAdresses = new List<string>();
            LearnedSkills = new List<Skill>();
        }
    }
}