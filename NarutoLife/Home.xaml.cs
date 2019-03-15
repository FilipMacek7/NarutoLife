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
    /// Interakční logika pro Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        DateTime datetime;
        Character naruto;
        bool timestop = false;
        static Frame mainframe;
        public Home(DateTime getdateTime, Character Naruto, Frame Mainframe)
        {
            InitializeComponent();
            mainframe = Mainframe;
            datetime = getdateTime;
            timedate.Text = datetime.ToString("HH:mm");
            naruto = Naruto;
            naruto.health = naruto.LimitToRange(naruto.health, 0, naruto.maxhealth);
            naruto.chakra = naruto.LimitToRange(naruto.chakra, 0, naruto.maxchakra);
            naruto.happiness = naruto.LimitToRange(naruto.happiness, 0, naruto.maxhappiness);
            naruto.energy= naruto.LimitToRange(naruto.energy, 0, naruto.maxenergy);
            setInfo();          
        }
        DispatcherTimer dt = new DispatcherTimer();
        private void dtTicker(object sender, EventArgs e)
        {
            if (!timestop)
            {
                datetime = datetime.AddMinutes(1);
                timedate.Text = datetime.ToString("HH:mm");
            }
            if(page.Opacity == 0)
            {
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(2));
                page.BeginAnimation(Page.OpacityProperty, animation);
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();        
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

            switch (profilebg)
            {
                case 0:
                    profile_bg.Source = new BitmapImage(new Uri(@"img/profilebg3.jpg", UriKind.Relative));
                    profilebg = 3;
                    break;
                case 1:
                    profile_bg.Source = new BitmapImage(new Uri(@"img/profilebg1.jpg", UriKind.Relative));
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sleepinfo.Text = "You will wake up at: " + datetime.AddHours(sleephours).ToString("HH:mm");
            sleeppanel.Visibility = Visibility.Visible;
            timestop = true;
            dt.Stop();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sleeppanel.Visibility = Visibility.Hidden;
            timestop = false;
            dt.Start();
        }
        int sleephours = 1;
        private void Profile_Button(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Visible;
        }
        private void Profile_Close(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;
        }

        private void Sleep_next(object sender, RoutedEventArgs e)
        {
            if (sleephours < 10)
            {
                sleephours++;
                sleephourslabel.Text = sleephours.ToString();
                sleepinfo.Text = "You will wake up at: " + datetime.AddHours(sleephours).ToString("HH:mm");
            }
        }
        private void Sleep_previous(object sender, RoutedEventArgs e)
        {
            if (sleephours > 1)
            {
                sleephours--;
                sleephourslabel.Text = sleephours.ToString();
                sleepinfo.Text = "You will wake up at: " + datetime.AddHours(sleephours).ToString("HH:mm");
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(2));
            page.BeginAnimation(Page.OpacityProperty, animation);
            datetime = datetime.AddHours(sleephours);
            naruto.energy = naruto.energy + sleephours * 20;
            naruto.chakra = naruto.maxchakra;
            naruto.health = naruto.health + sleephours * 10;
            if(naruto.energy < naruto.maxenergy / 4)
            {
                naruto.happiness = naruto.maxhappiness;
            }
            Button_Click_2(sender, e);
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Village(datetime,naruto, mainframe));
        }
    }
}
