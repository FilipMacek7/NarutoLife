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
        DateTime datetime;
        public static Character naruto;
        static Frame pr;
        static Frame st;
        static string framekey = "Home";
        static Frame mainframe;
        static Page pg;    
        public Home(DateTime Datetime, Character Naruto, Frame Mainframe)
        {
            InitializeComponent();
            pg = page;
            pr = profile;
            st = settings;
            mainframe = Mainframe;
            datetime = Datetime;           
            naruto = Naruto;
            profilebar.Navigate(new ProfileBar(naruto, framekey));
            time.Navigate(new Time(datetime, framekey));
        }
        DispatcherTimer dt = new DispatcherTimer();

        private void setInfo()
        {
            naruto.health = naruto.LimitToRange(naruto.health, 0, naruto.maxhealth);
            naruto.chakra = naruto.LimitToRange(naruto.chakra, 0, naruto.maxchakra);
            naruto.happiness = naruto.LimitToRange(naruto.happiness, 0, naruto.maxhappiness);
            naruto.energy = naruto.LimitToRange(naruto.energy, 0, naruto.maxenergy);
        }
        public static void Settings_Close()
        {
            st.Navigate(null);
        }
        private void Settings_On(object sender, RoutedEventArgs e)
        {
            settings.Navigate(new Settings(mainframe,framekey));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sleepinfo.Text = "You will wake up at: " + datetime.AddHours(sleephours).ToString("HH:mm");
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
            setInfo();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Village(Time.datetime,naruto,mainframe));
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
