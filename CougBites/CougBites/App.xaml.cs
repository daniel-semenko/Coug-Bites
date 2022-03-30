using CougBites.Services;
using CougBites.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using CsvHelper;

namespace CougBites
{
    public partial class App : Application
    {
        public static Database database;

        public static Database Database
        {
            get
            {
                database = new Database(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "MyDB.db3"));

                return database;
            }
        }

        public App()
        {
            database = new Database(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "MyDB.db3"));
            Datatest();
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        public async void Datatest()
        {
            string filename = "CougBites.food.csv";
            database._database.CreateTableAsync<Models.FoodItem>();
            database._database.CreateTableAsync<Models.Location>();
            database._database.CreateTableAsync<Models.Profile>();
            database._database.CreateTableAsync<Models.Rating>();
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(filename))
            //using (var stream = File.OpenRead(filename))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {                              //1    2       3       4    5      6     7     8     9   10     11
                //var trash = reader.ReadLine(); //id  name   locID   desc  sat    sun   mon   tue   b/l   s     d
                //var foodItems = new List<(int, string, int, string, int, int, int, int, int, int, int)>();
                if (reader != null)
                {
                    csv.Read();
                    while (csv.Read())
                    {
                        database.SaveFoodAsync(new Models.FoodItem
                        {
                            ID = csv.GetField<int>(0),
                            Name = csv.GetField<string>(1),
                            LocationID = csv.GetField<int>(2),
                            Description = csv.GetField<string>(3),
                            DaysAvailable = new List<int> { csv.GetField<int>(4), csv.GetField<int>(5), csv.GetField<int>(6), csv.GetField<int>(7) },
                            TimesAvailable = new List<int> { csv.GetField<int>(8), csv.GetField<int>(9), csv.GetField<int>(10) },
                            Picture = csv.GetField<string>(11)
                        });
                    }
                }
            }

            database.SaveProfileAsync(new Models.Profile
            {
                ID = 1,
                Name = "Alice",

            });

            database.SaveProfileAsync(new Models.Profile
            {
                ID = 2,
                Name = "John",

            });

            database.SaveProfileAsync(new Models.Profile
            {
                ID = 3,
                Name = "Alex",

            });

            database.SaveProfileAsync(new Models.Profile
            {
                ID = 4,
                Name = "Conor",

            });

            database.SaveProfileAsync(new Models.Profile
            {
                ID = 5,
                Name = "Aiden",

            });

            database.SaveLocationAsync(new Models.Location
            {
                ID = 0,
                Name = "Southside Cafe",
                Picture = "southside.png",
                Description = "2580 NE Grimes Way, Pullman, WA 99163\n(509) 335-3372\n"

            });

            database.SaveLocationAsync(new Models.Location
            {
                ID = 1,
                Name = "Hillside Cafe",
                Picture = "hillside.png",
                Description = "Wilmer-Davis Hall, Pullman, WA 99163\n(509) 335-3050\n"

            });

            database.SaveLocationAsync(new Models.Location
            {
                ID = 2,
                Name = "Northside Cafe",
                Picture = "northside.png",
                Description = "Stearns Residence Hall Pullman,WA 99163\n"
            });

            database.SaveRatingAsync(new Models.Rating
            {
                UserId = 1,
                FoodId = 1,
                Description = "Eh.",
                RatingNum = 2.5
            });

            database.SaveRatingAsync(new Models.Rating
            {
                UserId = 1,
                FoodId = 6,
                Description = "Amazing!!",
                RatingNum = 5
            });

            database.SaveRatingAsync(new Models.Rating
            {
                UserId = 2,
                FoodId = 6,
                Description = "It was average.",
                RatingNum = 4
            });

            database.SaveRatingAsync(new Models.Rating
            {
                UserId = 2,
                FoodId = 1,
                Description = "Really good.",
                RatingNum = 4.5
            });

            database.SaveRatingAsync(new Models.Rating
            {
                UserId = 3,
                FoodId = 1,
                Description = "Could've been better",
                RatingNum = 3
            });

            database.SaveRatingAsync(new Models.Rating
            {
                UserId = 3,
                FoodId = 6,
                Description = "Terrible.",
                RatingNum = 1
            });

            database.SaveRatingAsync(new Models.Rating
            {
                UserId = 4,
                FoodId = 1,
                Description = "ugh",
                RatingNum = 2
            });

            database.SaveRatingAsync(new Models.Rating
            {
                UserId = 4,
                FoodId = 6,
                Description = "Coug'd it",
                RatingNum = 2
            });

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
