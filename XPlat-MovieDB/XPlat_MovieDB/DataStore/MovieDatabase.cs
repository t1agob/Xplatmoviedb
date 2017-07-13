using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XPlat_MovieDB.Models;

namespace XPlat_MovieDB.DataStore
{
    public class MovieDatabase
    {
        private SQLiteConnection _connection;

        public MovieDatabase()
        {
            //_connection = DependencyService.Get<ISqlite>().GetConnection();
            //_connection.CreateTable<Movie>();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return (from m in _connection.Table<Movie>()
                    select m).ToList();
        }

        public Movie GetMovie(long id)
        {
            return _connection.Table<Movie>().FirstOrDefault(m => m.Id == id);
        }

        public void DeleteMovie(long id)
        {
            _connection.Delete<Movie>(id);
        }

        public void AddMovie(Movie movie)
        {
            _connection.Insert(movie);
        }
    }
}
