using NarutoLife;
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

namespace NinjaLife
{
    /// <summary>
    /// Interakční logika pro Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        //main stats
        double health = 25;
        double chakra = 20;
        double happiness = 70;
        double energy = 50;
        int yen = 300;

        //max main stats
        int maxhealth = 25;
        int maxchakra = 20;
        int maxhappiness = 100;
        int maxenergy = 50;

        //battle stats
        int strength = 0;
        int quickness = 0;
        int vitality = 0;



        DateTime date = new DateTime(2000, 10, 13, 7, 0, 0);

        Sound game = new Sound();
        public Game()
        {
            InitializeComponent();
            game.Play("morning.mp3");
            game.SetVolume(25);
            setInfo();
        }

        DispatcherTimer dt = new DispatcherTimer();
        int i = 1;
        private void dtTicker(object sender, EventArgs e)
        {
            timedate.Text = date.AddSeconds(i).ToString("HH:mm:ss");
            i++;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }
        private void setInfo()
        {
            healthbar.Value = health / maxhealth * 100;
            chakrabar.Value = chakra / maxchakra * 100;
            happinessbar.Value = happiness / maxhappiness * 100;
            energybar.Value = energy / maxenergy * 100;

            healthtext.Text = health + "/" + maxhealth;
            chakratext.Text = chakra + "/" + maxchakra;
            happinesstext.Text = happiness + "/" + maxhappiness;
            energytext.Text = energy + "/" + maxenergy;

            if (happiness < 25)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_sad.jpg", UriKind.Relative));
            }
            else if (happiness > 25 & happiness < 50)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_notok.png", UriKind.Relative));
            }
            else if (happiness > 50 & happiness < 85)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_ok.png", UriKind.Relative));
            }
            else if (happiness >= 85)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_happy.png", UriKind.Relative));
            }
        }

        private void Training_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training());
        }
    }
}
