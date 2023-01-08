using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using SQLite;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Contacts.Models
{
    public class ContactController
    {
        public List<Contact> LocalContacts { get; private set; }       
        public async Task GetAllContactsAsync()
        {
            var getPermission = await Xamarin.Essentials.Contacts.PickContactAsync();
            var contacts = await Xamarin.Essentials.Contacts.GetAllAsync();

            if (LocalContacts == null)
            {
                LocalContacts = new List<Contact>();
            }
            if (contacts == null)
                return;
            LearnedSkill skill = new LearnedSkill();
            skill.Name = "Installing Apps";
            skill.Description = "You we're able to install this app. Good job!";
            skill.Grasp = 10;

            LearnedSkill skill2 = new LearnedSkill();
            skill2.Name = "Being Awesome";
            skill2.Description = "You're looking good!";
            skill2.Grasp = 10;

            List<LearnedSkill> basicSkills = new List<LearnedSkill>();
            basicSkills.Add(skill);
            basicSkills.Add(skill2);
            foreach (var contact in contacts)
            {
                var localContact = new Contact();
                localContact.Name = contact.GivenName;
                localContact.Surname = contact.FamilyName;
                localContact.Username = null;
                foreach (var phoneNumber in contact.Phones)
                {
                    localContact.PhoneNumbers.Add(phoneNumber.ToString());
                }
                localContact.PhoneNumbersBlobbed = JsonConvert.SerializeObject(localContact.PhoneNumbers);
                localContact.EmailAdressesBlobbed = JsonConvert.SerializeObject(localContact.EmailAdresses);
                localContact.LearnedSkillsBlobbed = JsonConvert.SerializeObject(basicSkills);

                LocalContacts.Add(localContact);
                await App.MyDatabase.RegisterUser(localContact);
            }
        }
    }
    public class PhoneObject
    {
        public string Phone { get; set; }
    }
    public class EmailObject
    {
        public string Email { get; set; }
    }
    public class SkillObject
    {
        public string Name { get; set; }
        public LearnedSkill LearnedSkill { get; set; }
    }

}