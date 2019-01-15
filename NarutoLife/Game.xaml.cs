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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        //main stats
        int health = 30;
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
        int taijutsu = 2;
        int quickness = 2;
        int vitality = 3;
        int accuracy = 1;

        //exp frames
        double btaijutsu = 0;
        double bquickness = 0;
        double bvitality = 0;
        double baccuracy = 0;

        DateTime datetime;
        public Game(double minusenergy,  DateTime getdatetime, double plustaijutsu, double plusquickness, double plusvitality, double plusaccuracy)
        {
            InitializeComponent();
            energy = energy - minusenergy * 0.1;
            timedate.Text = getdatetime.ToString("HH:mm:ss");
            datetime = getdatetime;
            setInfo();
            btaijutsu = btaijutsu + plustaijutsu;
            bquickness = bquickness + plusquickness;
            bvitality = bvitality + plusvitality;
            baccuracy = baccuracy + plusaccuracy;
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
        private void setInfo()
        {
            healthbar.Value = health / maxhealth * 100;
            chakrabar.Value = chakra / maxchakra * 100;
            happinessbar.Value = happiness / maxhappiness * 100;
            energybar.Value = Math.Round(energy / maxenergy * 100);

            healthtext.Text = health + "/" + maxhealth;
            chakratext.Text = chakra + "/" + maxchakra;
            happinesstext.Text = happiness + "/" + maxhappiness;
            energytext.Text = energy + "/" + maxenergy;

            if (happiness < 25 || energy < 10)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_sad.jpg", UriKind.Relative));
            }
            else if (happiness > 25 & happiness < 50 || energy < 20)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_notok.png", UriKind.Relative));
            }
            else if (happiness > 50 & happiness < 85 || energy < 30)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_ok.png", UriKind.Relative));
            }
            else if (happiness >= 85)
            {
                StatePic.Source = new BitmapImage(new Uri(@"/img/state_happy.png", UriKind.Relative));
            }

            ImageBrush myBrush = new ImageBrush();
            if (datetime.Hour < 16 & datetime.Hour > 5)
            {
                Background.ImageSource = new BitmapImage(new Uri(@"img/konoha_afternoon.jpg", UriKind.Relative));
            }
            else if (datetime.Hour > 15 & datetime.Hour < 19)
            {
                Background.ImageSource = new BitmapImage(new Uri(@"img/konoha_colorfulevening.jpg", UriKind.Relative));
            }
            else if (datetime.Hour > 18 & datetime.Hour < 21)
            {
                Background.ImageSource = new BitmapImage(new Uri(@"img/konoha_evening.jpg", UriKind.Relative));
            }
            else if (datetime.Hour > 21 || datetime.Hour < 5)
            {
                Background.ImageSource = new BitmapImage(new Uri(@"img/konoha_night.jpg", UriKind.Relative));
            }

            switch (profilebg)
            {
                case 0:
                    profile_bg.Source = new BitmapImage(new Uri(@"img/profilebg3.jpg", UriKind.Relative));
                    profilebg = 3;
                    break;
                case 1:
                    profile_bg.Source= new BitmapImage(new Uri(@"img/profilebg1.jpg", UriKind.Relative));
                    break;
                case 2:
                    profile_bg.Source = new BitmapImage(new Uri(@"img/profilebg2.jpg", UriKind.Relative));
                    break;
                case 3:
                    profile_bg.Source = new BitmapImage(new Uri(@"img/profilebg3.jpg", UriKind.Relative));
                    break;
                case 4:
                    profile_bg.Source = new BitmapImage(new Uri(@"img/profilebg1.jpg", UriKind.Relative));
                    profilebg = 1;
                    break;
            }
            stats.Content = "\n Taijutsu: " + taijutsu.ToString() + "\n Quickness: " + quickness.ToString() + "\n Vitality: " + vitality.ToString() + "\n Accuracy: " + accuracy.ToString();
        }

        private void Training_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training(datetime, btaijutsu, bquickness, bvitality,baccuracy));
        }
        private void Profile_Button(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Visible;
        }
        private void Profile_Close(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;
        }
        int profilebg = 1;
        private void Profile_Bgnext(object sender, RoutedEventArgs e)
        {
            profilebg++;
            setInfo();
        }
        private void Profile_Bgprevious(object sender, RoutedEventArgs e)
        {
            profilebg--;
            setInfo();
        }
        private void AnimationCompleted(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_stand.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Naruto, image);
            ImageBehavior.SetRepeatBehavior(Naruto, RepeatBehavior.Forever);
        }
    }
}
