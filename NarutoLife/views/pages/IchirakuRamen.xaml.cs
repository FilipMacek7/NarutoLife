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
    /// Interakční logika pro IchirakuRamen.xaml
    /// </summary>
    public partial class IchirakuRamen : Page
    {
        static Frame pr;
        public IchirakuRamen()
        {
            InitializeComponent();
            profilebar.Navigate(new ProfileBar("IchirakuRamen"));
            time.Navigate(new Time("IchirakuRamen"));
            pr = profile;
        }
        private void GoVillage(object sender, RoutedEventArgs e)
        {
            Village.mainframe.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
        }
        private void EnterRamen(object sender, RoutedEventArgs e)
        {
            enterbutton.Visibility = Visibility.Hidden;
            Village.datetime = Village.datetime.AddHours(1);
            Village.naruto.yen -= 100;
            Village.naruto.happiness += 70;
            ProfileBar.updateStats();
            background.ImageSource = new BitmapImage(new Uri(@"../../img/eatramen.gif", UriKind.Relative));
        }
        public static void Profile_on()
        {
            pr.Navigate(new ProfilePanel("IchirakuRamen"));
        }
        public static void Profile_Off()
        {
            pr.Navigate(null);
        }
    }
}
