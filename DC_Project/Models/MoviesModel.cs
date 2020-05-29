using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;

namespace DC_Project.Models
{
    public class MoviesModel
    {
        public string MovieImage { get; set; }

        public string MovieName { get; set; }

        public MoviesModel(string movieID)
        {
            TMDbClient client = new TMDbClient("c807e25e9945dcb331636165896edb32");
            Movie movieItem = client.GetMovieAsync(movieID, MovieMethods.Credits | MovieMethods.Images).Result;

            MovieName = movieItem.Title;

            foreach(ImageData image in movieItem.Images.Posters)
            {
                MovieImage = "https://image.tmdb.org/t/p/original" + image.FilePath;
            }
        }
    }

}
