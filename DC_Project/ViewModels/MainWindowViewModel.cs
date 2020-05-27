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

namespace DC_Project.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields

        private Window mWindow;

        #endregion

        #region Properties

        public string MovieName { get; set; }

        public string MovieDescription { get; set; }

        public string MovieCast { get; set; }

        public string MovieImage { get; set; }

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

            // Window Buttons Commands
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);

            //This is The Movie Database API Client
            TMDbClient client = new TMDbClient("c807e25e9945dcb331636165896edb32");
            Movie movie = client.GetMovieAsync("141052", MovieMethods.Credits | MovieMethods.Images).Result;

            MovieName = movie.Title;
            MovieDescription = movie.Overview;
            foreach (ImageData image in movie.Images.Backdrops)
            {
                MovieImage = "https://image.tmdb.org/t/p/original"+image.FilePath;
            }

            foreach (Cast cast in movie.Credits.Cast)
            {
                MovieCast = cast.Name;
            }

        }
        #endregion
    }
}
