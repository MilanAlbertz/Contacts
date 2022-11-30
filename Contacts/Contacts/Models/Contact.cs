using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Contacts;

namespace Contacts.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string[] Emails { get; set; }
        public string[] PhoneNumbers { get; set; }

        public async Task GetAllContactsAsync()
        {
            ObservableCollection<Contact> contactsCollect = new ObservableCollection<Contact>();

            try
            {
                // cancellationToken parameter is optional
                var contacts = await Contacts.GetAllAsync();

                if (contacts == null)
                    return;

                foreach (var contact in contacts)
                    contactsCollect.Add(contact);
            }
            catch (Exception ex)
            {
                // Handle exception here.
            }
        }
    }

}