using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MoviePriceTracker.Models
{
    public class DataManager
    {
        String dataSourceURL = "http://webjetapitest.azurewebsites.net/api/";
        String APItoken = "sjd1HfkjU83ksdsm3802k";

        public MoviesModel GetSortedMoviesByPrice(string dataprovider)
        {
            MoviesModel AllMovies = GetAllMoviesRestSharp(dataprovider);
            if (AllMovies.Movies.Count > 0)
            {
                foreach (MovieInfo movieInfo in AllMovies.Movies)
                {
                    movieInfo.DetailedInfo = GetMovieRestSharp(dataprovider, movieInfo.ID);
                    if (movieInfo.DetailedInfo == null)
                    {
                        movieInfo.DetailedInfo = new MovieDetailedInfo();
                    }
                }
                //filter movies without price
                IEnumerable<MovieInfo> filteredMovies = AllMovies.Movies.AsEnumerable().Where(x => x.DetailedInfo.Price != -1);
                if (filteredMovies.Count() > 0)
                {
                    AllMovies.Movies = filteredMovies.ToList();
                }
                AllMovies.Movies = AllMovies.Movies.OrderBy(x => x.DetailedInfo.Price).Select(x => x).ToList();
            }
            return AllMovies;
        }

        public MoviesModel GetAllMoviesRestSharp(string location)
        {
            String APIDataString = null;
            String uri = dataSourceURL + location + "/movies";
            try
            {
                var client = new RestClient(uri);

                var request = new RestRequest(Method.GET);
                client.Timeout = 60000;
                //add HTTP Headers
                request.AddHeader("x-access-token", APItoken);

                // execute the request
                IRestResponse response = client.Execute(request);
                APIDataString = response.Content; // raw content as string
                MoviesModel DataModel = JsonConvert.DeserializeObject<MoviesModel>(APIDataString);
                DataModel.DataProvider = location;
                return DataModel;
            }
            catch (Exception ex)
            {
                return new MoviesModel();
            }

        }

        public MovieDetailedInfo GetMovieRestSharp(string location, string ID)
        {
            String APIDataString = null;
            String uri = dataSourceURL + location + "/movie/" + ID;
            try
            {
                var client = new RestClient(uri);

                var request = new RestRequest(Method.GET);
                client.Timeout = 60000;
                //add HTTP Headers
                request.AddHeader("x-access-token", APItoken);

                // execute the request
                IRestResponse response = client.Execute(request);
                APIDataString = response.Content; // raw content as string
                MovieDetailedInfo DataModel = JsonConvert.DeserializeObject<MovieDetailedInfo>(APIDataString);
                return DataModel;
            }
            catch (Exception ex)
            {
                MovieDetailedInfo movieInfo = new MovieDetailedInfo
                {
                    Price = -1
                };
                return movieInfo;
            }
        }

        //Basic HTTP methods
        public MoviesModel GetAllMovies(string location)
        {
            //API HIT
            String APIDataString = null;
            String uri = "http://webjetapitest.azurewebsites.net/api/" + location + "/movies";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.Headers.Add("x-access-token", "sjd1HfkjU83ksdsm3802k");
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    APIDataString = reader.ReadToEnd();
                }
                MoviesModel DataModel = JsonConvert.DeserializeObject<MoviesModel>(APIDataString);
                DataModel.DataProvider = location;
                return DataModel;
            }
            catch (Exception ex)
            {
                return new MoviesModel();
            }
        }

        public MovieDetailedInfo GetMovie(string location, string ID)
        {
            String APIDataString = null;
            String uri = "http://webjetapitest.azurewebsites.net/api/" + location + "/movie/" + ID;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.Headers.Add("x-access-token", "sjd1HfkjU83ksdsm3802k");
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    APIDataString = reader.ReadToEnd();
                }
                MovieDetailedInfo DataModel = JsonConvert.DeserializeObject<MovieDetailedInfo>(APIDataString);

                return DataModel;
            }
            catch (Exception ex)
            {
                MovieDetailedInfo movieInfo = new MovieDetailedInfo();
                movieInfo.Price = -1;
                return movieInfo;
            }
        }
    }
}