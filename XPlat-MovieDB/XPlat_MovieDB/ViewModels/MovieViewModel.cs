using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XPlat_MovieDB.Models;
using XPlat_MovieDB.Views;

namespace XPlat_MovieDB.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        private readonly string apikey = "de4475464af5751733343331778542f7";
        private string locale = "pt-PT";
        private Movie _selectedMovie;
        private INavigation _navigation;

        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set { _selectedMovie = value; }
        }

        private ObservableRangeCollection<Movie> _favoriteMovies;
        public ObservableRangeCollection<Movie> FavoriteMovies
        {
            get { return _favoriteMovies; }
            set { SetProperty(ref _favoriteMovies, value); }
        }

        private ObservableRangeCollection<Movie> _nowPlayingMovies;
        public ObservableRangeCollection<Movie> NowPlayingMovies
        {
            get { return _nowPlayingMovies; }
            set { SetProperty(ref _nowPlayingMovies, value); }
        }

        private ObservableRangeCollection<Movie> _popularMovies;
        public ObservableRangeCollection<Movie> PopularMovies
        {
            get { return _popularMovies; }
            set { SetProperty(ref _popularMovies, value); }
        }

        private ObservableRangeCollection<Movie> _upcomingMovies;
        public ObservableRangeCollection<Movie> UpcomingMovies
        {
            get { return _upcomingMovies; }
            set { SetProperty(ref _upcomingMovies, value); }
        }

        public MovieViewModel()
        {
            //NavigateToDetail = new Command(async () => await NavigateToDetailAsync());

            Device.BeginInvokeOnMainThread(async () =>
            {
                IsBusy = true;

                await LoadNowPlayingMovies();
                await LoadPopularMovies();
                await LoadUpcomingMovies();
                //await LoadFavoriteMovies();

                IsBusy = false;
            });
        }

        //public MovieViewModel(INavigation navigation)
        //{
        //    _navigation = navigation;

        //    NavigateToDetail = new Command(async () => await NavigateToDetailAsync());

        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        IsBusy = true;

        //            await LoadNowPlayingMovies();
        //            await LoadPopularMovies();
        //            await LoadUpcomingMovies();
        //            await LoadFavoriteMovies();

        //            IsBusy = false;
        //    });            
        //}

        private async Task LoadUpcomingMovies()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri($"http://api.themoviedb.org/3/movie/upcoming?api_key={apikey}&language={locale}");
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<MovieResult>(content);
                
                UpcomingMovies = new ObservableRangeCollection<Movie>();
                foreach (var item in json.Results)
                {
                    UpcomingMovies.Add(item);
                }
            }
        }

        private async Task LoadPopularMovies()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri($"http://api.themoviedb.org/3/movie/popular?api_key={apikey}&language={locale}");
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<MovieResult>(content);

                PopularMovies = new ObservableRangeCollection<Movie>();
                foreach (var item in json.Results)
                {
                    PopularMovies.Add(item);
                }
            }
        }

        private async Task LoadFavoriteMovies()
        {
            await Task.Run(() => 
            {
                foreach (var item in App.database.GetMovies())
                {
                    FavoriteMovies.Add(item);
                }
            });            
        }

        private async Task LoadNowPlayingMovies()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri($"http://api.themoviedb.org/3/movie/now_playing?api_key={apikey}&language={locale}");
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<MovieResult>(content);

                NowPlayingMovies = new ObservableRangeCollection<Movie>();
                foreach (var item in json.Results)
                {
                    NowPlayingMovies.Add(item);
                }
            }
        }

        public ICommand NavigateToDetail { protected set; get; }        

        async Task NavigateToDetailAsync()
        {
            await _navigation.PushModalAsync(new MovieDetailPage(this));
        }
    }
}
