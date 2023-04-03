using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MRZmLearnAPOD_UWP
{
    public sealed partial class MainPage : Page
    {
        DateTime launchDate = new DateTime(2014, 02, 01);

        const string EndpointURL = "https://api.nasa.gov/planetary/earth/imagery";
        const string GIBS = "Global Imagery Browse Service";
        const string exampleQuery = "https://api.nasa.gov/planetary/earth/imagery?lon=100.75&lat=1.5&date=2014-02-01&api_key=DEMO_KEY";

        float dim, lat, lon;

        private void LatTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LonTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            MonthCalendar.MinDate = launchDate;

            LatTB.Text = lat.ToString();
            LonTB.Text = lon.ToString();
        }

        public MainPage()
        {
            this.InitializeComponent();
            dim = 0.025F;
            lat = 47.2070208F;
            lon = 39.6867104F;

            MonthCalendar.MinDate = launchDate;
            MonthCalendar.MaxDate = DateTime.Today;

        }
    }
}
