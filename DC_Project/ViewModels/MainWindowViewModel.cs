using DC_Project.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.General;
using DC_Project.Models;

namespace DC_Project.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields

        private Window mWindow;

        #endregion

        #region Properties

        public string HeroName { get; set; }

        public string HeroDescription { get; set; }

        public string HeroImage { get; set; }

        public ObservableCollection<MoviesModel> MovieItems { get; set; } = new ObservableCollection<MoviesModel>();

        public MoviesModel Huh { get; set; }

        public List<Cast> HeroCast { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        public MainWindowViewModel(Window window)
        {
            mWindow = window;

            tmdbFunction();

            // Window Buttons Commands
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);

            MovieItems.Add(new MoviesModel("tt4154796"));
            MovieItems.Add(new MoviesModel("tt1477834"));
            MovieItems.Add(new MoviesModel("tt10985510"));
            MovieItems.Add(new MoviesModel("tt0448115"));
            MovieItems.Add(new MoviesModel("tt2494376"));
        }
        #endregion

        #region Methods

        public async void tmdbFunction()
        {
            //This is The Movie Database API Client
            TMDbClient client = new TMDbClient("c807e25e9945dcb331636165896edb32");
            Movie heroMovie = client.GetMovieAsync("tt2975590", MovieMethods.Credits | MovieMethods.Images).Result;

            //The name/titile of the movie
            HeroName = heroMovie.Title;

            //The movie's description
            HeroDescription = heroMovie.Overview;

            await Task.Run(() =>
            {
                foreach (ImageData image in heroMovie.Images.Posters)
                {
                    HeroImage = "https://image.tmdb.org/t/p/original" + image.FilePath; //This gets the movies image
                }
            });

            //Names of each cast member
            HeroCast = heroMovie.Credits.Cast;
        }

        #endregion

    }
}
