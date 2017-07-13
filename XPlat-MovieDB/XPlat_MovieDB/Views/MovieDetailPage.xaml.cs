using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XPlat_MovieDB.DataStore;
using XPlat_MovieDB.Models;
using XPlat_MovieDB.ViewModels;

namespace XPlat_MovieDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        MovieViewModel vm;
        public MovieDetailPage()
        {
            InitializeComponent();
        }

        public MovieDetailPage(MovieViewModel mov)
        {
            InitializeComponent();
            vm = mov;
            BindingContext = vm.SelectedMovie;
        }

        private void AddToFavorites_Clicked(object sender, EventArgs e)
        {
            Movie mov = BindingContext as Movie;
            mov.IsFavorite = true;
            vm.FavoriteMovies.Add(mov);

            App.database.AddMovie(mov);
        }

        private void RemoveFromFavorites_Clicked(object sender, EventArgs e)
        {
            Movie mov = BindingContext as Movie;
            vm.FavoriteMovies.Remove(mov);
            mov.IsFavorite = false;

            App.database.DeleteMovie(mov.Id);
        }
    }
}