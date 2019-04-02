using NarutoLife.model;
using NarutoLife.views.pages;
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
    /// Interakční logika pro ProfileBar.xaml
    /// </summary>
    public partial class ProfileBar : Page
    {
        static ProgressBar Healthbar;
        static ProgressBar Chakrabar;
        static ProgressBar Happinessbar;
        static ProgressBar Energybar;
        static TextBlock Healthtext;
        static TextBlock Chakratext;
        static TextBlock Happinesstext;
        static TextBlock Energytext;
        static Image statePic;
        static string framekey;
        static Label Yen;
        public ProfileBar(string Framekey)
        {
            InitializeComponent();
            framekey = Framekey;
            Healthbar = healthbar;
            Chakrabar = chakrabar;
            Happinessbar = happinessbar;
            Energybar = energybar;
            Healthtext = healthtext;
            Chakratext = chakratext;
            Happinesstext = happinesstext;
            Energytext = energytext;
            statePic = StatePic;
            Yen = yen;
            updateStats();         
        }
        public static void updateStats()
        {
            Yen.Content = "Yen: " + Village.naruto.yen.ToString();
            decimal decimalhealthbar = (decimal)Village.naruto.health / (decimal)Village.naruto.maxhealth * 100;
            Healthbar.Value = (int)decimalhealthbar;
            decimal decimalchakrabar = (decimal)Village.naruto.chakra / (decimal)Village.naruto.maxchakra * 100;
            Chakrabar.Value = (int)decimalchakrabar;
            Happinessbar.Value = Village.naruto.happiness;
            decimal decimalenergybar = (decimal)Village.naruto.energy / (decimal)Village.naruto.maxenergy * 100;
            Energybar.Value = (int)decimalenergybar;

            Healthtext.Text = (int)Village.naruto.health + "/" + (int)Village.naruto.maxhealth;
            Chakratext.Text = (int)Village.naruto.chakra + "/" + (int)Village.naruto.maxchakra;
            Happinesstext.Text = (int)Village.naruto.happiness + "/" + (int)Village.naruto.maxhappiness;
            Energytext.Text = (int)Village.naruto.energy + "/" + (int)Village.naruto.maxenergy;
            if (Village.naruto.happiness < 25 || Village.naruto.energy < 10)
            {
                statePic.Source = new BitmapImage(new Uri(@"/img/state_sad.jpg", UriKind.Relative));
            }
            else if (Village.naruto.happiness > 25 & Village.naruto.happiness < 50 || Village.naruto.energy < 20)
            {
                statePic.Source = new BitmapImage(new Uri(@"/img/state_notok.png", UriKind.Relative));
            }
            else if (Village.naruto.happiness > 50 & Village.naruto.happiness < 85 || Village.naruto.energy < 30)
            {
                statePic.Source = new BitmapImage(new Uri(@"/img/state_ok.png", UriKind.Relative));
            }
            else if (Village.naruto.happiness >= 85)
            {
                statePic.Source = new BitmapImage(new Uri(@"/img/state_happy.png", UriKind.Relative));
            }

        }
        private void Profile_Button(object sender, RoutedEventArgs e)
        {
            if(framekey == "Village")
            {
                Village.Profile_on();
            }
            else if (framekey == "Home")
            {
                Home.Profile_on();
            }
            else if (framekey == "Hospital")
            {
                Hospital.Profile_on();
            }
            else if (framekey == "IchirakuRamen")
            {
                IchirakuRamen.Profile_on();
            }
        }
    }
}
