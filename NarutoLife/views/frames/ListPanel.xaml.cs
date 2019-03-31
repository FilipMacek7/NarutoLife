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

namespace NarutoLife.views.frames
{
    /// <summary>
    /// Interakční logika pro ListPanel.xaml
    /// </summary>
    public partial class ListPanel : Page
    {
        static string framekey;
        public ListPanel(string Framekey)
        {
            InitializeComponent();
            framekey = Framekey;
        }
        public static void Settings_Close()
        {
            if (framekey.Equals("Village"))
            {
                Village.Settings_Off();
            }
            else if (framekey.Equals("Battleground"))
            {
                Battleground.Settings_Close();
            }
        }
        private void Settings_On(object sender, RoutedEventArgs e)
        {
            if (framekey.Equals("Village"))
            {
                Village.Settings_On();
            }
            else if (framekey.Equals("Battleground"))
            {
                Battleground.Settings_On();
            }
        }
        private void Inventory_Open(object sender, RoutedEventArgs e)
        {
            if (framekey.Equals("Village"))
            {
                Village.Inventory_On();
            }
            else if (framekey.Equals("Battleground"))
            {
                Battleground.Inventory_On();
            }
        }
    }
}
