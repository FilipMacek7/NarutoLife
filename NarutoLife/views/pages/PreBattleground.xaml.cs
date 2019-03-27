using NarutoLife.model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;
using System.Windows;
using System.Linq;

namespace NarutoLife.views.pages
{
    /// <summary>
    /// Interakční logika pro PreBattleground.xaml
    /// </summary>
    public partial class PreBattleground : Page
    {
        static DispatcherTimer dt = new DispatcherTimer();
        static DateTime datetime;
        Mission mission;
        static Character naruto;
        static Frame mainframe;
        static List<Enemy> mobs = new List<Enemy>();
        List<Image> mobsimg = new List<Image>();
        List<Enemy> mobssorted = new List<Enemy>();
        static Image narutoimg;
        Enemy currentEnemy;

        public PreBattleground(DateTime Datetime, Character Naruto, Mission Mis, Frame Mainframe)
        {
            InitializeComponent();
            narutoimg = Narutoimg;
            datetime = Datetime;
            mainframe = Mainframe;
            mission = Mis;
            naruto = Naruto;
            generateMobs();
            Parallax p = new Parallax(Narutoimg,narutocursed, background1, background2, background3, background4, background5, background11, background21, background31, background41, background51,rect8,jg2,mobsimg, 3);
            dt.Interval = TimeSpan.FromMilliseconds(500);
            dt.Tick += dtTicker;
            dt.Start();
        }
        public static void navigateVillage()
        {
            stopMove();
            mainframe.Navigate(new Village(datetime, naruto, mainframe));
        }
        DispatcherTimer dt2 = new DispatcherTimer();
        private void dtTicker(object sender, EventArgs e)
        {
            //mob detect
            foreach(Image img in mobsimg)
            {
                if (Canvas.GetLeft(img) - Canvas.GetLeft(Narutoimg) < 300)
                {
                    int i = 0;
                    dt2.Interval = TimeSpan.FromSeconds(1);
                    dt2.Tick += dt2Ticker;
                    dt2.Start();
                    stopMove();
                    void dt2Ticker(object sender2, EventArgs e2)
                    {
                        i++; 
                        if(i == 2)
                        {
                            mainframe.Navigate(new Battleground(naruto, currentEnemy, mainframe));
                            dt2.Stop();
                        }
                    }
                }                        
            }
            
        }
        Random rnd = new Random();
        private void generateMobs()
        {
            for(int i = 0; i < rnd.Next(1,6); i++)
            {
                if(mission.name.Equals("Wolf hunt"))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@"/img/wolf_stand.gif", UriKind.Relative);
                    bitmap.EndInit();
                    Image img = new Image();
                    img.Height = 130;
                    img.Width = 130;
                    ImageBehavior.SetAnimatedSource(img, bitmap);
                    ImageBehavior.SetRepeatBehavior(img, RepeatBehavior.Forever);
                    img.Source = bitmap;
                    Background_Canvas.Children.Add(img);
                    Canvas.SetLeft(img, rnd.Next(250,1500));
                    Canvas.SetTop(img, 425);
                    mobsimg.Add(img);
                    Enemy wolf = new Enemy(i,"Wolf",naruto.level,Canvas.GetLeft(img),Canvas.GetTop(img));
                    wolf.LimitToRange(wolf.level, 1, 5);
                    mobs.Add(wolf);
                    mobssorted = mobs.OrderByDescending(o => o.positionx).ToList();
                    currentEnemy = mobssorted[0];
                }
            }
        }
        private void startMove(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            foreach (Enemy m in mobs)
            {
                if(m.id == int.Parse(b.Tag.ToString()))
                {
                    mobs.Remove(m);
                    break;
                }        
            }
            mobs.Add(currentEnemy);
            dt.Start();
            Parallax.parallaxStart();
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_run.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Narutoimg, image);
            ImageBehavior.SetRepeatBehavior(Narutoimg, RepeatBehavior.Forever);
        }
        private static void stopMove()
        {
            dt.Stop();
            Parallax.parallaxStop();
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_stand.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(narutoimg, image);
            ImageBehavior.SetRepeatBehavior(narutoimg, RepeatBehavior.Forever);
        }
    }
}
