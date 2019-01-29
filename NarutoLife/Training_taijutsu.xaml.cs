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
    /// Interakční logika pro Training_taijutsu.xaml
    /// </summary>
    public partial class Training_taijutsu : Page
    {
        DateTime datetime;  
        int i;
        int hours;
        Character naruto;
        public Training_taijutsu(int Hours, DateTime getdatetime, Character Naruto)
        {
            InitializeComponent();
            datetime = getdatetime;
            i = hours * 10;
            hours = Hours;
            time.Content = "Time left: " + i.ToString();
            naruto = Naruto;
        }
        DispatcherTimer dt = new DispatcherTimer();
        ///END 
        private void dtTicker(object sender, EventArgs e)
        {
            i--;
            time.Content = "Time left: " + i.ToString();
            if (i == 0)
            {
                table.Visibility = Visibility.Visible;
                endscore.Content = score.ToString();
                endexp.Content = naruto.exptaijutsu.ToString() +" + "+ (score / 4).ToString() + "%";
                naruto.exptaijutsu = naruto.exptaijutsu + score / 4;
                naruto.explevel = naruto.explevel + score / 100;
                naruto.energy = naruto.energy - score + (naruto.vitality / 2) * 10;
                naruto.happiness = naruto.happiness - hours * 10;
                datetime = datetime.AddHours(hours);
                dt.Stop();
            }
        }
        double score = 0;
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += Page_PreviewKeyDown;
            this.Focusable = true;
            this.Focus();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();   
        }
        Sound punch = new Sound();
        void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var image = new BitmapImage();
            if (e.Key == Key.Q & !e.IsRepeat & i > 0)
            {
                punch.Play("punch_trunk.mp3");
                punch.SetVolume(5);
                score++;
                Score.Content = "Punches: " + score.ToString();
                image.BeginInit();
                image.UriSource = new Uri(@"/img/naruto_fight.gif", UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(Naruto, image);
                ImageBehavior.SetRepeatBehavior(Naruto, new RepeatBehavior(1));
            }
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
        DispatcherTimer helpdt = new DispatcherTimer();
        double helpticker = 1;
        private void Help_Button(object sender, RoutedEventArgs e)
        {
            if(helpticker == 1)
            {
                helpdt.Interval = TimeSpan.FromMilliseconds(25);
                helpdt.Tick += helpTicker;
                helpdt.Start();
            }
        }
        private void helpTicker(object sender, EventArgs e)
        {
            helpticker = helpticker - 0.01;
            help.Opacity = helpticker;
            if(help.Opacity <= 0)
            {
                helpdt.Stop();
                helpticker = 1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                NavigationService.Navigate(new Village(datetime, naruto));
        }
    }
}
