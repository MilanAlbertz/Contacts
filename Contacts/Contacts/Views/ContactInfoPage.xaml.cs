using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;
using Contacts.ViewModels;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactInfoPage : ContentPage
    {
        public ContactInfoPage(Contacts.Models.Contact selectedContact)
        {
            InitializeComponent();
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Contacts.Models.Contact>();
            var contacts = sQLiteConnection.Table<Contacts.Models.Contact>().ToList();
            var phonesO = new List<PhoneObject>();
            foreach (var phone in JsonConvert.DeserializeObject<List<string>>(selectedContact.PhoneNumbersBlobbed))
            {
                phonesO.Add(new PhoneObject { Phone = phone});
            }

            var emailO = new List<EmailObject>();
            foreach (var email in JsonConvert.DeserializeObject<List<string>>(selectedContact.EmailAdressesBlobbed))
            {
                emailO.Add(new EmailObject { Email = email });
            }
            IdLabel.Text = selectedContact.Id.ToString();
            NameLabel.Text = selectedContact.Name;
            SurnameLabel.Text = selectedContact.Surname;
            if (emailO.Count <= 0) 
            {
                EmailLabel.IsVisible= false;
                EmailListView.IsVisible = false;
            }
            else
            {
                EmailListView.ItemsSource = emailO;
            }

            if (phonesO.Count <= 0)
            {
                PhoneNumberLabel.IsVisible= false;
                PhoneNumberListView.IsVisible= false;
            }
            else
            {
                PhoneNumberListView.ItemsSource = phonesO;
            }
        }

        private void TextCell_Tapped(object sender, EventArgs e)
        {

        }

        private void EmailListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}