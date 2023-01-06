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
            //todo: ProgressBar maken
            Skill skill = new Skill();
            skill.Name = "Installing Apps";
            skill.Description = "You we're able to install this app. Good job!";
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
                localContact.LearnedSkillsBlobbed = JsonConvert.SerializeObject(skill);

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
        public Skill Skill { get; set; }
    }

}