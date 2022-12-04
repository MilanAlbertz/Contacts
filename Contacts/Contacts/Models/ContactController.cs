using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

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
            foreach (var contact in contacts)
            {
                var localContact = new Contact();
                localContact.Name = contact.GivenName;
                localContact.Surname = contact.FamilyName;
                foreach (var phoneNumber in contact.Phones)
                {
                    localContact.PhoneNumbers.Add(phoneNumber.ToString());
                }
                LocalContacts.Add(localContact);
            }
            /*Place Breakpoint here to see all your local contacts. Will be used later to check
            localcontacts with database to see if people in your contacts use the app.*/ 
            var check = LocalContacts;
        }
    }
}