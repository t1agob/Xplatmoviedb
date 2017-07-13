using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPlat_MovieDB.Models
{
    public class MovieResult: ObservableObject
    {
        private List<Movie> _results;
        [JsonProperty("results")]
        public List<Movie> Results
        {
            get
            {
                return _results;
            }

            set
            {
                SetProperty(ref _results, value);
            }
        }

        private int _totalPages;
        [JsonProperty("total_pages")]
        public int TotalPages
        {
            get
            {
                return _totalPages;
            }

            set
            {
                SetProperty(ref _totalPages, value);
            }
        }


    }
}
