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
        int health = 25;
        int chakra = 20;
        int happiness = 70;
        double energy = 50;
        int yen = 300;

        //max main stats
        int maxhealth = 25;
        int maxchakra = 20;
        int maxhappiness = 100;
        int maxenergy = 50;

        //battle stats
        int taijutsu = 0;
        int quickness = 0;
        int vitality = 0;


        DateTime datetime;
        public Game(double minusenergy,  DateTime getdatetime)
        {
            InitializeComponent();
            startMusic();        
            energy = energy - minusenergy * 0.1;
            timedate.Text = getdatetime.ToString("HH:mm:ss");
            datetime = getdatetime;
            setInfo();
        }
        DispatcherTimer dt = new DispatcherTimer();
        int i = 1;
        private void dtTicker(object sender, EventArgs e)
        {
            timedate.Text = datetime.AddSeconds(i).ToString("HH:mm:ss");
            i++;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }
        private void startMusic()
        {
            if (i==1)
            {
                Sound game = new Sound();
                game.Play("morning.mp3");
                game.SetVolume(25);
            }
        }
        private void setInfo()
        {
            healthbar.Value = health / maxhealth * 100;
            chakrabar.Value = chakra / maxchakra * 100;
            happinessbar.Value = happiness / maxhappiness * 100;
            energybar.Value = Math.Round(energy/ maxenergy * 100);

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
            NavigationService.Navigate(new Training(datetime));
        }
    }
}
