using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public General()
        {
            InitializeComponent();
            // Set the maximum date to today and the minimum date to the APOD launch date.
            MonthCalendar.MaxDate = DateTime.Today;
            MonthCalendar.MinDate = launchDate;
        }
    }
}
