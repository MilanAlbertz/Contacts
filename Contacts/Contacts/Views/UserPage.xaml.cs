using Contacts.ViewModels;
using Xamarin.Forms;
using System.ComponentModel;
using SQLite;
using Contacts.Models;
using System.Collections.Generic;

namespace Contacts.Views
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
           List<Contact> users = await App.MyDatabase.GetAllUsers();
            UserListView.ItemsSource = users;
        }

    }
}