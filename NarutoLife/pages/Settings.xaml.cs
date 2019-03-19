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

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        string framekey;
        static Frame mainframe;
        public Settings(Frame Mainframe,string Framekey)
        {
            InitializeComponent();
            framekey = Framekey;
            mainframe = Mainframe;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Menu());
        }
        private void Settings_Close(object sender, RoutedEventArgs e)
        {
            if (framekey.Equals("Village"))
            {
                Village.Settings_Close();
            }
            else if (framekey.Equals("Home"))
            {
                Home.Settings_Close();
            }
            
        }
    }
}
