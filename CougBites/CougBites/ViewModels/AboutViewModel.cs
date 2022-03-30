using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;
using System.IO;

namespace CougBites.ViewModels
{
    public class AboutViewModel : BaseViewModel
    { 
        public AboutViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            Database database = new Database(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "MyDB.db3"));
            var forYou = database._database.Table<Models.Rating>().Where(v => v.UserId == 5 && v.RatingNum > 3.5);
            var forEveryone = database._database.Table<Models.Rating>().Where(v => v.UserId != 5 && v.RatingNum > 3.5);
            //
        }

        public ICommand OpenWebCommand { get; }
    }
}