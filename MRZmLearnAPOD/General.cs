using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MRZmLearnAPOD
{
    public partial class General : Form
    {
        // The objective of the NASA API portal is to make NASA data, including imagery, eminently accessible to application developers.
        const string EndpointURL = "https://api.nasa.gov/planetary/apod";

        // June 16, 1995: the APOD launch date.
        DateTime launchDate = new DateTime(1995, 6, 16);

        // A count of images downloaded today.
        int imageCountToday;

        // Init file name strings, used to preserve UI values between sessions.
        const string SettingDateToday = "date today";
        const string SettingShowOnStartup = "show on startup";
        const string SettingImageCountToday = "image count today";
        const string SettingLimitRange = "limit range";

        // The full path to the init file.
        string initFilePath;

        // A char used to separate the name from the value in the init file.
        const char SettingDivider = ':';

        public General()
        {
            InitializeComponent();

            // Set the maximum date to today and the minimum date to the APOD launch date.
            MonthCalendar.MaxDate = DateTime.Today;
            MonthCalendar.MinDate = launchDate;

            // The init file is stored in the same folder as the app.
            initFilePath = Path.Combine(Application.StartupPath, "init_apod.txt");

            // Read the init file and set UI fields.
            ReadInitFile();
        }

        private async Task RetrievePhoto()
        {
            var client = new HttpClient();
            JObject jResult = null;
            string responseContent = null;
            string description = null;
            string photoUrl = null;
            string copyright = null;

            // Set the UI elements to defaults.
            ImageCopyrightTextBox.Text = "NASA";
            textBoxDescription.Text = "";

            // Build the date parameter string for the date selected, or the last date if a range is specified.
            DateTime dt = MonthCalendar.SelectionEnd;
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
                    ImagePictureBox.ImageLocation = photoUrl;

                    if (IsSupportedFormat(photoUrl))
                    {
                        // Get the copyright message but fill with "NASA" if no name is provided.
                        copyright = (string)jResult["copyright"];
                        if (copyright != null && copyright.Length > 0)
                        {
                            ImageCopyrightTextBox.Text = copyright;
                        }

                        // Populate the description text box.
                        description = (string)jResult["explanation"];
                        textBoxDescription.Text = description;
                    }
                    else
                    {
                        textBoxDescription.Text = $"Image type is not supported. URL is {photoUrl}";
                    }
                }
                catch (Exception ex)
                {
                    textBoxDescription.Text = $"Image data is not supported. {ex.Message}";
                }

                // Keep track of our downloads in case we reach the limit.
                ++imageCountToday;
                ImagesTodayTextBox.Text = imageCountToday.ToString();
            }
            else
            {
                textBoxDescription.Text = "We were unable to retrieve the NASA picture for that day: " +
                    $"{response.StatusCode.ToString()} {response.ReasonPhrase}";
            }
        }

        private bool IsSupportedFormat(string photoURL)
        {
            // Extract the extension and force to lowercase for comparison purposes.
            string ext = Path.GetExtension(photoURL).ToLower();

            // Check the extension against supported Windows Forms formats.
            return (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" || ext == ".bmp" ||
                    ext == ".tif");

        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            // Make sure the full range of dates is available.
            // This statement might invoke a call to LimitRangeCheckBox_CheckedChanged.
            LimitRangeCheckBox.Checked = false;

            // This statement will not load the first APOD image. It just sets the calendar to the APOD launch date.
            MonthCalendar.SelectionEnd = launchDate;
        }

        private void LimitRangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LimitRangeCheckBox.Checked)
            {
                var thisYear = new DateTime(DateTime.Today.Year, 1, 1);
                MonthCalendar.MinDate = thisYear;
            }
            else
            {
                MonthCalendar.MinDate = launchDate;
            }
        }

        private async void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            await RetrievePhoto();
        }

        private void General_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteInitFile();
        }

        private void WriteInitFile()
        {
            using (var sw = new StreamWriter(initFilePath))
            {
                // Write out today's date, to keep track of the downloads per day.
                sw.WriteLine($"{SettingDateToday}{SettingDivider}{DateTime.Today.ToShortDateString()}");

                // Write out the number of images that we've downloaded today.
                sw.WriteLine($"{SettingImageCountToday}{SettingDivider}{imageCountToday}");

                // Write out the UI settings that we want to preserve for the next time.
                sw.WriteLine($"{SettingShowOnStartup}{SettingDivider}{ShowTodaysImageCheckBox.Checked}");
                sw.WriteLine($"{SettingLimitRange}{SettingDivider}{LimitRangeCheckBox.Checked}");
            }
        }

        private void ReadInitFile()
        {
            // Check that we have an init file.
            if (File.Exists(initFilePath))
            {
                String line = null;
                String[] part;
                bool isToday = false;

                using (var sr = new StreamReader(initFilePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Split the line into the part before the divider (the name) and the part after it (the value).
                        part = line.Split(SettingDivider);

                        // Switch on the "name" part and then process the "value" part.
                        switch (part[0])
                        {
                            // Read the date and, if it's today's date, read the number of images already downloaded today.
                            // If it's not today's date, set the number of downloads back to zero.
                            case SettingDateToday:
                                var dt = DateTime.Parse(part[1]);
                                if (dt.Equals(DateTime.Today))
                                {
                                    isToday = true;
                                }
                                break;

                            case SettingImageCountToday:

                                // If the last time the app was used was earlier today, the
                                // image count stored is valid against the 50-per-day maximum.
                                if (isToday)
                                {
                                    imageCountToday = int.Parse(part[1]);
                                }
                                else
                                {
                                    imageCountToday = 0;
                                }
                                break;

                            case SettingShowOnStartup:
                                ShowTodaysImageCheckBox.Checked = bool.Parse(part[1]);
                                break;

                            case SettingLimitRange:

                                // This statement might invoke a call to LimitRangeCheckBox_CheckedChanged.
                                LimitRangeCheckBox.Checked = bool.Parse(part[1]);
                                break;

                            // This line is for debugging purposes.
                            default:
                                throw new Exception($"Unknown init file entry: {line}");
                        }
                    }
                }
            }
            else
            {
                // No init file exists yet, so set defaults.
                imageCountToday = 0;
                ShowTodaysImageCheckBox.Checked = true;
                LimitRangeCheckBox.Checked = false;
            }

            ImagesTodayTextBox.Text = imageCountToday.ToString();

            // Make a call to retrieve a picture on startup, if required by the setting.
            if (ShowTodaysImageCheckBox.Checked)
            {
                MonthCalendar_DateSelected(null, null);
            }
        }
    }
}
