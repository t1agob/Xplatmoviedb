using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using XPlat_MovieDB.DataStore;
using XPlat_MovieDB.UWP.DataStore;

[assembly: Dependency(typeof(Sqlite_UWP))]
namespace XPlat_MovieDB.UWP.DataStore
{
    public class Sqlite_UWP : ISqlite
    {
        public Sqlite_UWP()
        {

        }

        #region ISQLite implementation

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "Movies.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);

            var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }

        #endregion
    }
}
