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
using WpfAnimatedGif;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro ProfilePanel.xaml
    /// </summary>
    public partial class ProfilePanel : Page
    {
        string mainframe;
        public ProfilePanel(string Mainframe)
        {
            InitializeComponent();
            mainframe = Mainframe;
            setInfo();
        }
        private void Profile_Close(object sender, RoutedEventArgs e)
        {
            if (mainframe.Equals("Village"))
            {
                Village.Profile_off();
            }
            else if (mainframe.Equals("Home"))
            {
                Home.Profile_off();
            }            
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
        private void setInfo()
        {
            levellabel.Content = "Naruto Uzumaki LV. " + Village.naruto.level;
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
            string taijutsu = "";
            string quickness = "";
            string vitality = "";
            string accuracy = "";
            switch (mainframe)
            {
                case "Village":
                    taijutsu = Village.naruto.taijutsu.ToString();
                    quickness = Village.naruto.quickness.ToString();
                    vitality = Village.naruto.vitality.ToString();
                    accuracy = Village.naruto.accuracy.ToString();
                    break;
                case "Home":
                    taijutsu = Home.naruto.taijutsu.ToString();
                    quickness = Home.naruto.quickness.ToString();
                    vitality = Home.naruto.vitality.ToString();
                    accuracy = Home.naruto.accuracy.ToString();
                    break;
            }
            stats.Content = "\n Taijutsu: " + taijutsu + "\n Quickness: " + quickness + "\n Vitality: " + vitality + "\n Accuracy: " + accuracy;
        }
    }
}
