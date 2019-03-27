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
        DispatcherTimer timer = new DispatcherTimer();
        bool playerturn = false;
        bool enemyturn = false;
        public Battleground(Character Naruto, Enemy enemy2, Frame mainframe)
        {
            InitializeComponent();
            playerbar.Navigate(new NarutoFightbar(Naruto));
            naruto = Naruto;
            enemy = enemy2;
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timerTicker;
            timer.Start();
            void timerTicker(object sender, EventArgs e)
            {
                if (Canvas.GetLeft(narutot) >= 330)
                {
                    timer.Stop();
                    Canvas.SetLeft(narutot, -20);
                    playerturn = true;
                    enemyturn = false;
                }
                if (Canvas.GetLeft(enemyt) >= 395)
                {
                    timer.Stop();
                    Canvas.SetLeft(enemyt, 45);
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
            image.UriSource = new Uri(@"/img/wolf_stand.gif", UriKind.Relative);
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
