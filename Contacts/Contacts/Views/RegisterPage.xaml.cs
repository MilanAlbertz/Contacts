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

        public void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.Username = UsernameEntry.Text;
            contact.Password = PasswordEntry.Text;
            contact.IsAdmin = false;
            App.MyDatabase.RegisterUser(contact);
            Navigation.PushAsync(new LoginPage());
        }
    }
}