using SQLite;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Models.Contact>();
            var user = sQLiteConnection.Table<Models.Contact>().Where(d => d.IsUser == true).FirstOrDefault();

            if (user == null)
            {
                Models.Contact contact = new Models.Contact();
                contact.IsUser = true;

                sQLiteConnection.Insert(contact);
            }
            else
            {
                //todo: Make the pfp saveable :)
                ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                ProfilePictureImage.Source = (ImageSource)imageSourceConverter.ConvertFromInvariantString(user.Image);
            }
            sQLiteConnection.Close();
        }

        private async void EditProfilePictureButtonClicked(object sender, EventArgs args)
        {
            var picture = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (picture != null)
            {
                SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
                sQLiteConnection.CreateTable<Models.Contact>();
                var user = sQLiteConnection.Table<Models.Contact>().Where(d => d.IsUser).FirstOrDefault();
                user.Image = picture.FullPath;
                ProfilePictureImage.Source = picture.FullPath;
                sQLiteConnection.Update(user);
                sQLiteConnection.Close();
            }
        }
    }
}