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

namespace NinjaLife
{
    /// <summary>
    /// Interakční logika pro Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        Sound menu = new Sound();
        public Menu()
        {
            InitializeComponent();
            menu.Play("menu.mp3");
            menu.SetVolume(25);
        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            int minusenergy = 0;
            DateTime date = new DateTime(2000, 10, 13, 7, 0, 0);
            NavigationService.Navigate(new Game(minusenergy, date));
            menu.Stop();
        }

        private void Button_Load(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {

        }
    }
}