using Contacts.Services;
using Contacts.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Xamarin.Forms.PlatformConfiguration;
using System.IO;

namespace Contacts
{
    public partial class App : Application
    {
        private static DataAccessLayer db;
        public static DataAccessLayer MyDatabase
        {
            get
            {
                if (db == null)
                {
                    db = new DataAccessLayer(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "contacts_db.sqlite"));
                }
                return db;
            }
        }
        public static string DatabaseLocation  { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
        public App(string databaseLocation) : this()
        {
            if (databaseLocation == null)
            {
                throw new ArgumentNullException(nameof(databaseLocation));
            }
            DatabaseLocation = databaseLocation;
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
