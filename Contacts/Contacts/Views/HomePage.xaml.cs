using Contacts.ViewModels;
using Xamarin.Forms;
using System.ComponentModel;

namespace Contacts.Views
{
    public partial class HomePage : TabbedPage
    {
        public HomePage(Models.Contact contact)
        {
            if(contact.IsAdmin == true)
            {
                
            }
            InitializeComponent();
        }
    }
}