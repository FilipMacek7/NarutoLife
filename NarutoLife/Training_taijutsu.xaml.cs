using NinjaLife;
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
    /// Interakční logika pro Training_taijutsu.xaml
    /// </summary>
    public partial class Training_taijutsu : Page
    {
        public Training_taijutsu()
        {
            InitializeComponent();
            
        }
        int score = 0;
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += Page_PreviewKeyDown;
            this.Focusable = true;
            this.Focus();
        }
        Sound punch = new Sound();       
        void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var image = new BitmapImage();
            if (e.Key == Key.Q & !e.IsRepeat)
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
    }
}
