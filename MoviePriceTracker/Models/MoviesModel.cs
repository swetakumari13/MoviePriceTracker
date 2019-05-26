using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviePriceTracker.Models
{
    public class MoviesModel
    {
        public MoviesModel()
        {
            Movies = new List<MovieInfo>();
        }
        public string DataProvider { get; set; }
        public List<MovieInfo> Movies { get; set; }
    }

    public class MovieInfo
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string ID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public MovieDetailedInfo DetailedInfo { get; set; }
    }

    public class MovieDetailedInfo
    {
        public MovieDetailedInfo()
        {
            Price = -1;
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public int Metascore { get; set; }
        public float Rating { get; set; }
        public string Votes { get; set; }
        public string ID { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
    }
}