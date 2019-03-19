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
        static public Frame st;
        static public Frame pr;
        static public Frame mainframe;
        static public Character naruto;
        public Village(DateTime getdatetime, Character Naruto, Frame Mainframe)
        {
            InitializeComponent();           
            timedate.Text = getdatetime.ToString("HH:mm");
            datetime = getdatetime;
            naruto = Naruto;           
            st = settings;
            pr = profile;
            mainframe = Mainframe;
            setInfo();
            profilebar.Navigate(new ProfileBar(naruto,"Village"));
        }
        private void setInfo()
        {
            naruto.health = naruto.LimitToRange(naruto.health, 0, naruto.maxhealth);
            naruto.chakra = naruto.LimitToRange(naruto.chakra, 0, naruto.maxchakra);
            naruto.happiness = naruto.LimitToRange(naruto.happiness, 0, naruto.maxhappiness);
            naruto.energy = naruto.LimitToRange(naruto.energy, 0, naruto.maxenergy);
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
        private void Training_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training(datetime, naruto, mainframe));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Home(datetime, naruto, mainframe));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HokageMansion(datetime, naruto));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            settings.Content = new Settings();
        }
        public static void Exit_menu()
        {
            st.Navigate(null);
            mainframe.Navigate(new Menu());
        }
        public static void Profile_on()
        {
            pr.Navigate(new ProfilePanel("Village"));
        }
        public static void Profile_off()
        {
            pr.Navigate(null);
        }
    }
}
