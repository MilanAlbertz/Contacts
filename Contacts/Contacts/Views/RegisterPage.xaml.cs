using Contacts.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contacts.Models;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        //TODO: Make password reveal button
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        public async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Contact>();

            List<Contact> contacts = await App.MyDatabase.GetAllContacts();
            bool checker = true;
            if(string.IsNullOrEmpty(UsernameEntry.Text)  
                || string.IsNullOrEmpty(PasswordEntry.Text)
                || string.IsNullOrEmpty(UsernameEntry.Text + PasswordEntry.Text))
            {
                await DisplayAlert("Error!", "Username and Password cannot be empty!", "Ok");
            }
            else
            {
                foreach (var loopContact in contacts)
                {
                    if (loopContact.Username == UsernameEntry.Text)
                    {
                        await DisplayAlert("Error!", "Username already taken", "Ok");
                        checker = false;
                    }
                }
                if (checker)
                {
                    Contact contact = new Contact();
                    contact.Username = UsernameEntry.Text;
                    contact.Password = PasswordEntry.Text;
                    contact.IsAdmin = false;

                    await App.MyDatabase.RegisterUser(contact);
                    await Navigation.PushAsync(new LoginPage());
                }
            }
        }
    }
}