using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;
using Contacts.Views;
using Contacts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Contacts.Services;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ContactListView.ItemsSource = await App.MyDatabase.GetAllContacts();
        }


        //todo: navigeren naar individuele items uit de lijst door:
        //Navigation.PushAsync(new ContactInfoPage(contact));
        public async void ContactsButton_ClickedAsync(object sender, EventArgs e)
        {
            ContactController contactController= new ContactController();
            await contactController.GetAllContactsAsync();
        }
        private void ContactListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedContact = ContactListView.SelectedItem as Contact;
            if (selectedContact != null)
            {
                Navigation.PushAsync(new ContactInfoPage(selectedContact));
            }
        }
    }
}