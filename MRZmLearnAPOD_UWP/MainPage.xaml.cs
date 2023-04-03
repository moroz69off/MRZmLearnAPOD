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
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MRZmLearnAPOD_UWP
{
    public sealed partial class MainPage : Page
    {
        DateTime launchDate = new DateTime(2014, 02, 01);

        const string EndpointURL = "https://api.nasa.gov/planetary/apod";

        float dim, lat, lon;

        private bool IsSupportedFormat(string photoURL)
        {
            // Extract the extension and force to lower case for comparison purposes.
            string ext = Path.GetExtension(photoURL).ToLower();

            // Check the extension against supported UWP formats.
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" ||
                   ext == ".tif" || ext == ".bmp"  || ext == ".ico" || ext == ".svg";
        }

        private void LatTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lat = float.Parse(LatTB.Text);
        }

        private void LonTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lon = float.Parse(LonTB.Text);
        }

        private async void LaunchButton_Click(object sender, RoutedEventArgs e)
        {

            MonthCalendar.MinDate = launchDate;

            await RetrievePhoto();

            //LatTB.Text = lat.ToString();
            //LonTB.Text = lon.ToString();
        }

        public MainPage()
        {
            this.InitializeComponent();

            dim = 0.025F;
            lat = 47.2070208F;
            lon = 39.6867104F;

            //lat = 47.20F;
            //lon = 39.68F;

            MonthCalendar.MinDate = launchDate;
            MonthCalendar.MaxDate = DateTime.Today;

        }

        private async Task RetrievePhoto()
        {
            var client = new HttpClient();
            JObject jResult = null;
            string responseContent = null;
            string photoUrl = null;


            // Build the date parameter string for the date selected, or the last date if a range is specified.
            DateTimeOffset dt = (DateTimeOffset)MonthCalendar.Date;

            string dateSelected = $"{dt.Year.ToString()}-{dt.Month.ToString("00")}-{dt.Day.ToString("00")}";

            string URLParams = $"?date={dateSelected}&api_key=DEMO_KEY";

            // Populate the HTTP client appropriately.
            client.BaseAddress = new Uri(EndpointURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // The critical call: send a GET request with the appropriate parameters.
            HttpResponseMessage response = client.GetAsync(URLParams).Result;

            if (response.IsSuccessStatusCode)
            {
                // Be ready to catch any data or server errors.
                try
                {
                    // Parse the response by using the Newtonsoft APIs.
                    responseContent = await response.Content.ReadAsStringAsync();

                    // Parse the response string for the details we need.
                    jResult = JObject.Parse(responseContent);

                    // Now get the image.
                    photoUrl = (string)jResult["url"];
                    var photoURI = new Uri(photoUrl);
                    var bmi = new BitmapImage(photoURI);

                    ImagePicture.Source = bmi;

                    if (IsSupportedFormat(photoUrl))
                    {

                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {

            }
        }
    }
}
