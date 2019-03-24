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
        public PreBattleground(string name)
        {
            InitializeComponent();
            Parallax.BackgroundMove(background1, background2, background3, background4, background5, background11, background21, background31, background41, background51,rect8,jg2, 3);
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
