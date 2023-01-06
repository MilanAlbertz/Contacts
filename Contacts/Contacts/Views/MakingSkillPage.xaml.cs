using Contacts.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contacts.Models;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakingSkillPage : ContentPage
    {
        //TODO: Make password reveal button
        public MakingSkillPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void SkillButton_Clicked(object sender, EventArgs e)
        {
            Skill skill = new Skill();
            skill.Name = SkillNameEntry.Text;
            skill.Description = SkillDescriptionEntry.Text;
            App.MyDatabase.MakeSkill(skill);
            Navigation.PushAsync(new SkillPage());
        }
    }
}