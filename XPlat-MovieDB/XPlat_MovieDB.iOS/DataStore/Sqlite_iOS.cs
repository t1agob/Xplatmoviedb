using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using XPlat_MovieDB.iOS.DataStore;
using Xamarin.Forms;
using SQLite.Net;
using System.IO;
using XPlat_MovieDB.DataStore;

[assembly: Dependency(typeof(Sqlite_iOS))]
namespace XPlat_MovieDB.iOS.DataStore
{
    public class Sqlite_iOS : ISqlite
    {
        public Sqlite_iOS()
        {
        }

        #region ISQLite implementation

        public SQLiteConnection GetConnection()
        {
            var fileName = "Movies.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }

        #endregion
    }
}