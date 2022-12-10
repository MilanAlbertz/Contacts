﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using SQLite;
using Newtonsoft.Json;

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
            var check = LocalContacts;
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Contact>();
            foreach (var contact in contacts)
            {
                var localContact = new Contact();
                localContact.Name = contact.GivenName;
                localContact.Surname = contact.FamilyName;
                foreach (var phoneNumber in contact.Phones)
                {
                    localContact.PhoneNumbers.Add(phoneNumber.ToString());
                }
                localContact.PhoneNumbersBlobbed = JsonConvert.SerializeObject(localContact.PhoneNumbers);
                localContact.EmailAdressesBlobbed = JsonConvert.SerializeObject(localContact.EmailAdresses);
                LocalContacts.Add(localContact);
                sQLiteConnection.Insert(localContact);
            }
            sQLiteConnection.Close();
            /*Place Breakpoint here to see all your local contacts. Will be used later to check
            localcontacts with database to see if people in your contacts use the app.*/
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

}