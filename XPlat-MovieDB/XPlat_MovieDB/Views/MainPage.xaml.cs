using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XPlat_MovieDB.Models;
using XPlat_MovieDB.ViewModels;

namespace XPlat_MovieDB.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new MovieViewModel(this.Navigation);
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView lv = sender as ListView;
            MovieViewModel vm = BindingContext as MovieViewModel;

            vm.SelectedMovie = e.Item as Movie;

            await Navigation.PushModalAsync(new MovieDetailPage(vm), true);
            lv.SelectedItem = null;
        }
    }
}
