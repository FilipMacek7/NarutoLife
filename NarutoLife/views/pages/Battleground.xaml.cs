using NarutoLife.model;
using NarutoLife.views.frames;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;
namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Battleground.xaml
    /// </summary>
    /// 
    public partial class Battleground : Page
    {
        Character naruto;
        Enemy enemy;
        DispatcherTimer game = new DispatcherTimer();
        DispatcherTimer timer = new DispatcherTimer();
        bool playerturn = false;
        bool enemyturn = false;
        static Uri uri;
        public Battleground(Character Naruto, Enemy enemy2, Frame mainframe)
        {
            InitializeComponent();
            game.Interval = TimeSpan.FromSeconds(1);
            game.Tick += gameTicker;
            game.Start();
            if (enemy2.name == "wolf")
            {
                uri = new Uri(@"../../img/wolf_fightimg.png", UriKind.Relative);
            }
            BitmapImage image = new BitmapImage(uri);
            enemyfightimg.Source = image;
            playerbar.Navigate(new NarutoFightbar(Naruto));
            naruto = Naruto;
            enemy = enemy2;
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timerTicker;
            timer.Start();
            void gameTicker(object sender, EventArgs e)
            {
                if(playerturn == true)
                {

                }
                else if(enemyturn == true)
                {

                }
            }
            void timerTicker(object sender, EventArgs e)
            {
                if (Canvas.GetLeft(narutot) >= 230)
                {
                    timer.Stop();
                    Canvas.SetLeft(narutot, -20);
                    playerturn = true;
                    enemyturn = false;
                }
                if (Canvas.GetLeft(enemyt) >= 295)
                {
                    timer.Stop();
                    Canvas.SetLeft(enemyt, 40);
                    playerturn = false;
                    enemyturn = true;
                }
                Canvas.SetLeft(narutot, Canvas.GetLeft(narutot) + naruto.quickness);
                Canvas.SetLeft(enemyt, Canvas.GetLeft(enemyt) + enemy.quickness);
            }
        }
        private void AnimationCompleted(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/"+enemy.name+"_stand.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(enemyimg, image);
            ImageBehavior.SetRepeatBehavior(enemyimg, RepeatBehavior.Forever);
        }
        private void Naruto_AnimationCompleted(object sender, RoutedEventArgs e)
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
