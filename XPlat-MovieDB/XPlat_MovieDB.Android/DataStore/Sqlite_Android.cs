using System;
using Android.OS;
using XPlat_MovieDB.Droid.DataStore;
using Xamarin.Forms;
using XPlat_MovieDB.DataStore;
using System.IO;

[assembly: Dependency(typeof(Sqlite_Android))]
namespace XPlat_MovieDB.Droid.DataStore
{
    class Sqlite_Android : ISqlite
    {
        public Sqlite_Android()
        {
        }

        #region ISQLite implementation

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "Movies.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }

        #endregion
    }
}