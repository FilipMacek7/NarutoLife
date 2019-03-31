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

namespace NarutoLife.views.pages
{
    /// <summary>
    /// Interakční logika pro Hospital.xaml
    /// </summary>
    public partial class Hospital : Page
    {
        public Hospital()
        {
            InitializeComponent();
            profilebar.Navigate(new ProfileBar("Hospital"));
            time.Navigate(new Time("Hospital"));
        }

        private void GoVillage(object sender, RoutedEventArgs e)
        {
            Village.mainframe.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
        }

        private void EnterHospital(object sender, RoutedEventArgs e)
        {
            Village.datetime = Village.datetime.AddHours(1);
            Village.naruto.yen -= 50;
            Village.naruto.health = (int)Village.naruto.maxhealth;
            ProfileBar.updateStats();
        }
    }
}
