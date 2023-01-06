using Contacts.ViewModels;
using Xamarin.Forms;
using System.ComponentModel;
using SQLite;
using Contacts.Models;
using System;

namespace Contacts.Views
{
    public partial class AddingSkillPage : ContentPage
    {
        public AddingSkillPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            SkillListView.ItemsSource = await App.MyDatabase.GetAllSkills();
        }
        private void SkillListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedSkill = SkillListView.SelectedItem as Skill;
            if (selectedSkill != null)
            {
                Navigation.PushAsync(new SkillInfoPage(selectedSkill));
            }
        }

    }
}