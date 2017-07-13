using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace XPlat_MovieDB.Models
{
    public class Movie : ObservableObject
    {
        private long _id;

        [PrimaryKey, AutoIncrement]
        [JsonProperty("id")]
        public long Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _voteCount;
        [JsonProperty("vote_count")]
        public int VoteCount
        {
            get { return _voteCount; }
            set { SetProperty(ref _voteCount, value); }
        }

        private double _voteAverage;
        [JsonProperty("vote_average")]
        public double VoteAverage
        {
            get { return _voteAverage; }
            set { SetProperty(ref _voteAverage, value); }
        }

        private string _title;
        [JsonProperty("title")]
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _posterPath;
        [JsonProperty("poster_path")]
        public string PosterPath
        {
            get { return $"http://image.tmdb.org/t/p/w300/{_posterPath}"; }
            set { SetProperty(ref _posterPath, value); }
        }

        private string _overview;
        [JsonProperty("overview")]
        public string Overview
        {
            get { return _overview; }
            set { SetProperty(ref _overview, value); }
        }

        private string _releaseDate;
        [JsonProperty("release_date")]
        public string ReleaseDate
        {
            get { return _releaseDate; }
            set { SetProperty(ref _releaseDate, value); }
        }

        private bool _isFavorite;
        [JsonProperty("is_favorite")]
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set { SetProperty(ref _isFavorite, value); }
        }
    }
}
