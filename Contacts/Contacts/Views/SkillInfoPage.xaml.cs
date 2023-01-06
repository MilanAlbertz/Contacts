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
using static Xamarin.Essentials.Permissions;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillInfoPage : ContentPage
    {
        Skill skill = new Skill();
        public SkillInfoPage(Skill selectedSkill)
        {
            InitializeComponent();
            SkillNameLabel.Text = selectedSkill.Name;
            SkillDescriptionLabel.Text = selectedSkill.Description;
            skill = selectedSkill;
            FillingUserPicker();
        }

        public async void FillingUserPicker()
        {
            UserPicker.ItemsSource = await App.MyDatabase.GetAllContacts(); 
        }
        public void AddSkillButton_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Contact>();
            string selectedContact = string.Empty;

            selectedContact = UserPicker.Items[UserPicker.SelectedIndex];
            foreach (var contact in sQLiteConnection.Table<Contact>()
                .Where(d => d.Name == selectedContact))
            {
                foreach (var skill in sQLiteConnection.Table<Skill>()
                    .Where(d => d.Id.ToString() == IdLabel.Text))
                {
                    contact.LearnedSkillsBlobbed = JsonConvert.SerializeObject(skill);
                }
            }
        }
    }
}