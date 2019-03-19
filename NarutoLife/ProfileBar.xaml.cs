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
        Character naruto;
        static string mainframe;
        public ProfileBar(Character Naruto, string Mainframe)
        {
            InitializeComponent();
            mainframe = Mainframe;
            naruto = Naruto;
            setInfo();         
        }
        private void setInfo()
        {
            healthbar.Value = naruto.health / naruto.maxhealth * 100;
            chakrabar.Value = naruto.chakra / naruto.maxchakra * 100;
            happinessbar.Value = naruto.happiness;
            energybar.Value = naruto.energy / naruto.maxenergy * 100;

            healthtext.Text = naruto.health + "/" + naruto.maxhealth;
            chakratext.Text = naruto.chakra + "/" + naruto.maxchakra;
            happinesstext.Text = naruto.happiness + "/" + naruto.maxhappiness;
            energytext.Text = naruto.energy + "/" + naruto.maxenergy;
            if (naruto.happiness < 25 || naruto.energy < 10)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_sad.jpg", UriKind.Relative));
            }
            else if (naruto.happiness > 25 & naruto.happiness < 50 || naruto.energy < 20)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_notok.png", UriKind.Relative));
            }
            else if (naruto.happiness > 50 & naruto.happiness < 85 || naruto.energy < 30)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_ok.png", UriKind.Relative));
            }
            else if (naruto.happiness >= 85)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_happy.png", UriKind.Relative));
            }

        }
        private void Profile_Button(object sender, RoutedEventArgs e)
        {
            if(mainframe == "Village")
            {

                Village.Profile_on();
            }
            else if (mainframe == "Home")
            {
                Home.Profile_on();
            }
        }
    }
}
