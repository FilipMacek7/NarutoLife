using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Time.xaml
    /// </summary>
    public partial class Time : Page
    {
        DispatcherTimer dt = new DispatcherTimer();
        string framekey;
        public Time(string Framekey)
        {
            InitializeComponent();
            timedate.Text = Village.datetime.ToString("HH:mm");
            framekey = Framekey;
            Village_background();
        }
        private void Village_background()
        {
            if (framekey.Equals("Village"))
            {
                Village.Background_set(Village.datetime);
            }
        }
        private void dtTicker(object sender, EventArgs e)
        {
            Village.datetime = Village.datetime.AddMinutes(1);
            if(Village.datetime.Minute == 59)
            {
                Village.naruto.energy -= 3;
                ProfileBar.updateStats();
            }
            timedate.Text = Village.datetime.ToString("HH:mm");
            if (framekey.Equals("Home"))
            {
                Home.Opacity_on();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            dt.Stop();
        }
    }
}
