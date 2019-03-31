using NarutoLife.model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        static Frame pr;
        static Frame st;
        static string framekey = "Home";
        static Page pg;    
        public Home()
        {
            InitializeComponent();
            pg = page;
            pr = profile;
            st = settings;
            profilebar.Navigate(new ProfileBar(framekey));
            time.Navigate(new Time(framekey));
        }
        DispatcherTimer dt = new DispatcherTimer();

        private void setInfo()
        {
            Village.naruto.health = Village.naruto.LimitToRange(Village.naruto.health, 0, (int)Village.naruto.maxhealth);
            Village.naruto.chakra = Village.naruto.LimitToRange(Village.naruto.chakra, 0, (int)Village.naruto.maxchakra);
            Village.naruto.happiness = Village.naruto.LimitToRange(Village.naruto.happiness, 0, Village.naruto.maxhappiness);
            Village.naruto.energy = Village.naruto.LimitToRange(Village.naruto.energy, 0, Village.naruto.maxenergy);
        }
        public static void Settings_Close()
        {
            st.Navigate(null);
        }
        private void Settings_On(object sender, RoutedEventArgs e)
        {
            settings.Navigate(new Settings(framekey));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sleepinfo.Text = "You will wake up at: " + Village.datetime.AddHours(sleephours).ToString("HH:mm");
            sleeppanel.Visibility = Visibility.Visible;
            dt.Stop();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sleeppanel.Visibility = Visibility.Hidden;
            dt.Start();
        }
        int sleephours = 1;

        private void Sleep_next(object sender, RoutedEventArgs e)
        {
            if (sleephours < 10)
            {
                sleephours++;
                sleephourslabel.Text = sleephours.ToString();
                sleepinfo.Text = "You will wake up at: " + Village.datetime.AddHours(sleephours).ToString("HH:mm");
            }
        }
        private void Sleep_previous(object sender, RoutedEventArgs e)
        {
            if (sleephours > 1)
            {
                sleephours--;
                sleephourslabel.Text = sleephours.ToString();
                sleepinfo.Text = "You will wake up at: " + Village.datetime.AddHours(sleephours).ToString("HH:mm");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(2));
            page.BeginAnimation(Page.OpacityProperty, animation);
            Village.datetime = Village.datetime.AddHours(sleephours);
            Village.naruto.energy = Village.naruto.energy + sleephours * 20;
            Village.naruto.chakra = (int)Village.naruto.maxchakra;
            Village.naruto.health = Village.naruto.health + sleephours * 10;
            if(Village.naruto.energy < Village.naruto.maxenergy / 4)
            {
                Village.naruto.happiness = Village.naruto.maxhappiness;
            }
            Button_Click_2(sender, e);
            setInfo();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Village.mainframe.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
        }
        public static void Profile_on()
        {     
            pr.Navigate(new ProfilePanel(framekey));
        }
        public static void Profile_off()
        {
            pr.Navigate(null);
        }
        public static void Opacity_on()
        {
            if (pg.Opacity == 0)
            {
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(2));
                pg.BeginAnimation(Page.OpacityProperty, animation);
            }
        }
    }
}
