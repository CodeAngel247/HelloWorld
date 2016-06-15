using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porcupine.Plugin
{
    public class MainWindowViewModel
    {
        /*private string _companyName;
        private int _companyNumber;

        public MainWindowViewModel(string companyName, int companyNumber)
        {
            _companyName = companyName;
            _companyNumber = companyNumber;
        }
       */
        private string windowTitle;
        public string WindowTitle
        {
            get { return windowTitle; }
            private set { windowTitle = value; }
        }
        private ISplashScreen splash;
        protected void SplashScreen(ISplashScreen splash)
        {
            this.splash = splash;
            splash.SetProgressState(true);
            splash.Progress(15.0);
            splash.Progress(25.0);


        }
        public MainWindowViewModel(IEnvironmentSettings settings)
        {
            WindowTitle = settings.ApplicationName;
        }
    }
}
