using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Contacts.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactInfoPage : ContentPage
    {
        public ContactInfoPage(Contact selectedContact)
        {
            InitializeComponent();
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
            var skillO = new List<SkillObject>();
            foreach (var skill in JsonConvert.DeserializeObject<List<Skill>>(selectedContact.LearnedSkillsBlobbed))
            {
                skillO.Add(new SkillObject { Skill = skill });
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
            if (skillO.Count <= 0)
            {
                SkillLabel.IsVisible = false;
                SkillsListView.IsVisible = false;
            }
            else
            {
                SkillsListView.ItemsSource = skillO;
            }
        }

        private void TextCell_Tapped(object sender, EventArgs e)
        {

        }

        private void EmailListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private async void InsultButton_Clicked(object sender, EventArgs e)
        {
            InsultController insultController = new InsultController();
            foreach(var contact in await App.MyDatabase.GetAllContacts())
            {
                if(contact.Id.ToString() == IdLabel.Text)
                {
                    var number = JsonConvert.DeserializeObject<List<string>>(contact.PhoneNumbersBlobbed).FirstOrDefault();
                    var name = contact.Name;
                    insultController.SendInsult(number, name);
                }
            }

        }
    }
}