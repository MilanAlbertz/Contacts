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
    public partial class LoginPage : ContentPage
    {
        //TODO: Make password reveal button
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var contacts = await App.MyDatabase.GetAllContacts();
            bool isThereAnAdmin = false;

            foreach (var contact in contacts)
            {
                if (contact.IsAdmin == true)
                {
                    isThereAnAdmin = true;
                }
            }
            if (isThereAnAdmin == false)
            {
                Models.Contact admin = new Models.Contact();
                admin.Username = "1";
                admin.Password = "1";
                admin.IsAdmin= true;
                await App.MyDatabase.RegisterUser(admin);
            }
            if (String.IsNullOrEmpty(UsernameEntry.Text))
            {
                UsernameEntry.Placeholder = "This can't be empty!";
            }
            if (String.IsNullOrEmpty(PasswordEntry.Text))
            {
                PasswordEntry.Placeholder = "This can't be empty!";
            }
            else
            {
                bool checker = false;
                Contact activeUser = new Models.Contact();
                foreach (var contact in contacts)
                {
                    if (contact.Username == UsernameEntry.Text && contact.Password == PasswordEntry.Text)
                    {
                        checker = true;
                        activeUser = contact;
                    }
                }
                if (checker == true)
                {
                    if (activeUser.IsAdmin == true)
                    {
                        await Navigation.PushAsync(new AdminPage());
                    }
                    else
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                    activeUser = null;
                }
                else
                {
                    DisplayAlert("Error!", "Username or password incorrect!", "Ok");
                }
                checker = false;

            }
        }
        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}