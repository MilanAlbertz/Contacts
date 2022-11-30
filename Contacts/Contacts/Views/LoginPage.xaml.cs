using Contacts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isUsernameEmpty = String.IsNullOrEmpty(UsernameEntry.Text);
            bool isPasswordEmpty = String.IsNullOrEmpty(PasswordEntry.Text);

            if (isUsernameEmpty)
            {
                UsernameEntry.Placeholder = "This can't be empty!";
            }
            else if (isPasswordEmpty)
            {
                PasswordEntry.Placeholder = "This can't be empty!";
            }
            else if (UsernameEntry.Text == "a" && PasswordEntry.Text == "a")
            {
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                _ = DisplayAlert("Ai", "Wrong Username or Password", "Ok");
            }
        }
    }
}