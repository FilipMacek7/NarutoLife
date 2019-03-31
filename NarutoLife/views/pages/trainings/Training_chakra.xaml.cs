using NarutoLife.model;
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
    /// Interakční logika pro Training_chakra.xaml
    /// </summary>
    public partial class Training_chakra : Page
    {
        int i;
        int hours;
        double score;
        int randomred;
        Random rnd = new Random();
        public Training_chakra(int Hours)
        {
            InitializeComponent();
            hours = Hours;
            i = hours * 10;
            randomred = rnd.Next(5, 96);
            redend.Offset = progressbar.Value / 100;
            bluestart.Offset = redend.Offset;
        }
        DispatcherTimer dt = new DispatcherTimer();
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += Page_PreviewKeyDown;
            this.Focusable = true;
            this.Focus();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
            if (Village.datetime.Hour > 4 & Village.datetime.Hour < 16)
            {
                Background.ImageSource = new BitmapImage(new Uri(@"img/training_chakra_morning.png", UriKind.Relative));
            }
            else if (Village.datetime.Hour > 15 & Village.datetime.Hour < 19)
            {
                Background.ImageSource = new BitmapImage(new Uri(@"img/training_chakra_afternoon.png", UriKind.Relative));
            }
            else if (Village.datetime.Hour > 18 & Village.datetime.Hour < 24 || Village.datetime.Hour == 1 || Village.datetime.Hour == 2 || Village.datetime.Hour == 3)
            {
                Background.ImageSource = new BitmapImage(new Uri(@"img/training_chakra_evening.png", UriKind.Relative));
            }
        }      
        private void dtTicker(object sender, EventArgs e)
        {
            i--;
            time.Content = "Time left: " + i.ToString();
            if (i == 0)
            {
                Village.naruto.expquickness = Village.naruto.expchakra + score / 4;
                Village.naruto.explevel = Village.naruto.explevel + score / 100;
                Village.naruto.energy = Village.naruto.energy - hours * 5 + Village.naruto.vitality / 2;
                Village.naruto.happiness = Village.naruto.happiness - hours * 10;
                Village.datetime = Village.datetime.AddHours(hours);
                trainingdone.Navigate(new Training_done("Chakra training", (int)score));
                dt.Stop();
            }

        }
        
        void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A & e.IsRepeat & i > 0 & progressbar.Value < randomred)
            {               
                progressbar.Value = progressbar.Value + 2;
                redend.Offset = progressbar.Value / 100;
                bluestart.Offset = redend.Offset;
                score = score + 0.5;
                Score.Content = "Score: " + score.ToString();
            }
            else if(e.Key == Key.D & e.IsRepeat & i > 0 & progressbar.Value >= randomred){
                bluestart.Color = Colors.Blue;
                blueend.Color = Colors.Blue;
                progressbar.Value = progressbar.Value + 2;
                score = score + 0.5;
                Score.Content = "Score: " + score.ToString();
            }
            if (progressbar.Value == 100)
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"/img/naruto_chakracharge.gif", UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(narutocharge, image);
                ImageBehavior.SetRepeatBehavior(narutocharge, new RepeatBehavior(7));
                progressbar.Value = 0;
                randomred = rnd.Next(5, 96);
                redend.Offset = progressbar.Value / 100;
                bluestart.Offset = redend.Offset;
                bluestart.Color = Colors.Transparent;
                blueend.Color = Colors.Transparent;
                score = score + 10;
                Score.Content = "Score: " + score.ToString();
            }
        }
        private void AnimationCompleted(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_chakracharge.png", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(narutocharge, image);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
        }
    }
}
