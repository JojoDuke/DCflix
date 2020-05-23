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

namespace DC_Project.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Window mWindow;
        #region Properties

        #endregion

        #region Commands

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }
        #endregion

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

            // On window being moved/dragged
        }
    }
}
