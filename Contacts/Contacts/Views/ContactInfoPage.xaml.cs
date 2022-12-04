using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;
using Contacts.ViewModels;
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
            IdLabel.Text = selectedContact.Id.ToString();
            NameEntry.Text = selectedContact.Name;
            SurnameEntry.Text = selectedContact.Surname;
            //EmailEntry.Text = 
            //PhoneNumbersEntry.Text = 
        }
    }
}