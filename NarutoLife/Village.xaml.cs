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
    public partial class Village : Page
    {
        Character naruto;
        public Village(DateTime getdatetime, Character Naruto)
        {
            InitializeComponent();           
            timedate.Text = getdatetime.ToString("HH:mm");
            datetime = getdatetime;
            naruto = Naruto;
            setInfo();          
        }
        DateTime datetime;
        DispatcherTimer dt = new DispatcherTimer();
        private void dtTicker(object sender, EventArgs e)
        {
            datetime = datetime.AddMinutes(1);
            timedate.Text = datetime.ToString("HH:mm");          
            
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }
        private void setInfo()
        {
            levellabel.Content = "Naruto Uzumaki LV. " + naruto.level;
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
            stats.Content = "\n Taijutsu: " + naruto.taijutsu.ToString() + "\n Quickness: " + naruto.quickness.ToString() + "\n Vitality: " + naruto.vitality.ToString() + "\n Accuracy: " + naruto.accuracy.ToString();


        }

        private void Training_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training(datetime, naruto));
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home(datetime, naruto));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HokageMansion(datetime, naruto));
        }
    }
}
