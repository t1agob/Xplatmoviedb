using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XPlat_MovieDB.DataStore;

namespace XPlat_MovieDB
{
    public partial class App : Application
    {
        public static MovieDatabase database;
        public App()
        {
            InitializeComponent();

            if (database == null)
            {
                database = new MovieDatabase();
            }

            MainPage = new Views.MainPage();
            //MainPage = new NavigationPage(new Views.MainPage());
        }        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
