﻿using Contacts.ViewModels;
using Xamarin.Forms;
using System.ComponentModel;
using SQLite;
using Contacts.Models;
using System;

namespace Contacts.Views
{
    public partial class SkillPage : ContentPage
    {
        public SkillPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            SkillListView.ItemsSource = await App.MyDatabase.GetAllSkills();
        }

        private void NewSkillButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MakingSkillPage());
        }
    }
}