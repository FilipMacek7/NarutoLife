using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace NarutoLife.pages
{
    /// <summary>
    /// Interakční logika pro Game.xaml
    /// </summary>
    public partial class Village : Page
    {
        static public Frame st;
        static public Frame pr;
        static public Frame mainframe;
        static string framekey = "Village";
        static public Character naruto;
        static DateTime datetime;
        static ImageBrush ib;
        public Village(DateTime getdatetime, Character Naruto, Frame Mainframe)
        {
            InitializeComponent();           
            datetime = getdatetime;
            naruto = Naruto;           
            st = settings;
            pr = profile;
            mainframe = Mainframe;
            ib = background;
            setInfo();         
        }
        private void setInfo()
        {
            profilebar.Navigate(new ProfileBar(naruto, framekey));
            time.Navigate(new Time(datetime, framekey));
            naruto.health = naruto.LimitToRange(naruto.health, 0, naruto.maxhealth);
            naruto.chakra = naruto.LimitToRange(naruto.chakra, 0, naruto.maxchakra);
            naruto.happiness = naruto.LimitToRange(naruto.happiness, 0, naruto.maxhappiness);
            naruto.energy = naruto.LimitToRange(naruto.energy, 0, naruto.maxenergy);
        }
        private void Training_Button(object sender, RoutedEventArgs e)
        {
            training.Navigate(new Training(Time.datetime, naruto, mainframe));
        }
        private void Home_Button(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Home(Time.datetime, naruto, mainframe));
        }

        private void HokageMansion_Button(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new HokageMansion(Time.datetime, naruto));
        }

        private void Settings_On(object sender, RoutedEventArgs e)
        {
            settings.Navigate(new Settings(mainframe, framekey));
        }
        public static void Exit_menu()
        {
            st.Navigate(null);
            mainframe.Navigate(new Menu());
        }
        public static void Profile_on()
        {
            pr.Navigate(new ProfilePanel(framekey));
        }
        public static void Profile_off()
        {
            pr.Navigate(null);
        }
        public static void Settings_Close()
        {
            st.Navigate(null);
        }
        public static void Background_set(DateTime Datetime)
        {
            datetime = Datetime;
            if (datetime.Hour < 16 & datetime.Hour > 5)
            {
                ib.ImageSource = new BitmapImage(new Uri(@"img/konoha_afternoon.jpg", UriKind.Relative));
            }
            else if (datetime.Hour > 15 & datetime.Hour < 19)
            {
                ib.ImageSource = new BitmapImage(new Uri(@"img/konoha_colorfulevening.jpg", UriKind.Relative));
            }
            else if (datetime.Hour > 18 & datetime.Hour < 21)
            {
                ib.ImageSource = new BitmapImage(new Uri(@"img/konoha_evening.jpg", UriKind.Relative));
            }
            else if (datetime.Hour > 21 || datetime.Hour < 5)
            {
                ib.ImageSource = new BitmapImage(new Uri(@"img/konoha_night.jpg", UriKind.Relative));
            }
        }
        public static void Taijutsu_Navigate(int Num)
        {
            mainframe.Navigate(new Training_taijutsu(Num, Time.datetime, naruto, mainframe));
        }
        public static void Chakra_Navigate(int Num)
        {
            mainframe.Navigate(new Training_chakra(Num, Time.datetime, naruto, mainframe));
        }
        public static void Quickness_Navigate(int Num)
        {
            mainframe.Navigate(new Training_quickness(Num, Time.datetime, naruto, mainframe));
        }
        public static void Accuracy_Navigate(int Num)
        {
            mainframe.Navigate(new Training_accuracy(Num, Time.datetime, naruto, mainframe));
        }
    }
}
