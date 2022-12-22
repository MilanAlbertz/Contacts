using Contacts.ViewModels;
using SQLite;
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
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Models.Contact>();
            var contacts = sQLiteConnection.Table<Models.Contact>().ToList();
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
                sQLiteConnection.Insert(admin);
                sQLiteConnection.Close();
            }
            if (String.IsNullOrEmpty(UsernameEntry.Text))
            {
                UsernameEntry.Placeholder = "This can't be empty!";
            }
            if (String.IsNullOrEmpty(PasswordEntry.Text))
            {
                PasswordEntry.Placeholder = "This can't be empty!";
            }
            foreach (var contact in contacts)
            {
                if(contact.Username == UsernameEntry.Text && contact.Password == PasswordEntry.Text)
                {
                    contact.IsAdmin = false;
                    Navigation.PushAsync(new HomePage(contact));
                }
            }
        }
    }
}