using IHome.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IHome
{
    public partial class App : Application
    {
        static AppDatabase appDatabase;

        public App()
        {
            InitializeComponent();
            MainPage = new Menu();
        }

        public static AppDatabase Database
        {
            get
            {
                if (appDatabase == null)
                {
                    appDatabase = new AppDatabase(Path.Combine
                        (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IHome.db"));
                }
                return appDatabase;
            }
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
