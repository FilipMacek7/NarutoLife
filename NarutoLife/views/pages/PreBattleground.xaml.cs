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

namespace NarutoLife.views.pages
{
    /// <summary>
    /// Interakční logika pro PreBattleground.xaml
    /// </summary>
    public partial class PreBattleground : Page
    {
        DispatcherTimer dt = new DispatcherTimer();
        public PreBattleground(string name)
        {
            InitializeComponent();
            Parallax.BackgroundMove(background1, background2, background3, background4, background5, background11, background21, background31, background41, background51,rect8,jg2, 3);
            dt.Interval = TimeSpan.FromMilliseconds(500);
            dt.Tick += dtTicker;
            dt.Start();
        }
        int i = 0;//362,638
        private void dtTicker(object sender, EventArgs e)
        {
            if (Canvas.GetLeft(narutocursed) == 638)
            {
                dt.Stop();
                Parallax.parallaxStop();
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"/img/naruto_stand.gif", UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(Naruto, image);
                ImageBehavior.SetRepeatBehavior(Naruto, RepeatBehavior.Forever);
            }
            i++;
            Canvas.SetLeft(narutocursed, Canvas.GetLeft(narutocursed) + i);
        }
    }
}
