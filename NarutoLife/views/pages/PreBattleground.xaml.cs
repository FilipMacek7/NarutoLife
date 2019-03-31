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
using NarutoLife.views.frames;

namespace NarutoLife.views.pages
{
    /// <summary>
    /// Interakční logika pro PreBattleground.xaml
    /// </summary>
    public partial class PreBattleground : Page
    {
        static DispatcherTimer dt = new DispatcherTimer();
        static List<Enemy> mobs = new List<Enemy>();
        List<Image> mobsimg = new List<Image>();
        List<Enemy> mobssorted = new List<Enemy>();
        static Image narutoimg;
        public static Enemy currentEnemy;
        static Image currentEnemyimg;
        static Grid Missionfinish;
        static Label Missionfinishtext;
        static Parallax P;
        public PreBattleground()
        {
            InitializeComponent();
            narutoimg = Narutoimg;
            Missionfinish = missionfinish;
            Missionfinishtext = missionfinishtext;
            generateMobs();
            Parallax p = new Parallax(Narutoimg,narutocursed, background1, background2, background3, background4, background5, background11, background21, background31, background41, background51,rect8,jg2,mobsimg, 3);
            P = p;
            dt.Interval = TimeSpan.FromMilliseconds(500);
            dt.Tick += dtTicker;
            dt.Start();
        }
        static int levelreward = 0;
        public static void missionFinish()
        {
            stopMove();
            if (Village.naruto.level < 10)
            {
                levelreward = 50;
            }
            else if (Village.naruto.level > 10)
            {
                levelreward = 100;
            }
            else if (Village.naruto.level > 20)
            {
                levelreward = 200;
            }
            Missionfinishtext.Content = "Good job! You have finished " + HokageMansion.clickedmission.name + ".\n Here is your reward: \n Yen - " + Village.naruto.yen.ToString() + " + " + HokageMansion.clickedmission.reward + "\n Exp - " + Village.naruto.explevel.ToString() + " + " +levelreward.ToString();
            Missionfinish.Visibility = Visibility.Visible;        
        }
        public static int movescount;
        private void Navigate_Village(object sender, EventArgs e)
        {
            Village.datetime = Village.datetime.AddMinutes(movescount * 2 + 30);
            Village.naruto.yen += HokageMansion.clickedmission.reward;
            Village.naruto.explevel += levelreward;
            Village.naruto.energy -= (int)(((movescount * 2 + 30)/1080) * 100);
            Village.naruto.happiness -= 10;
            Village.mainframe.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
            mobs = new List<Enemy>();
            mobsimg = new List<Image>();
            mobssorted = new List<Enemy>();
        }
        DispatcherTimer dt2 = new DispatcherTimer();
        int mobid = 0;
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
                    currentEnemyimg = img;
                    currentEnemy = mobssorted[mobid];
                    void dt2Ticker(object sender2, EventArgs e2)
                    {
                        i++; 
                        if(i == 2)
                        {
                            Village.mainframe.Navigate(new Battleground());
                            Background_Canvas.Children.Remove(currentEnemyimg);
                            mobsimg.Remove(currentEnemyimg);
                            mobid++;
                            dt2.Stop();
                        }
                    }
                }                        
            }
            
        }
        Random rnd = new Random();
        private void generateMobs()
        {
            for(int i = 0; i < HokageMansion.clickedmission.numberOfEnemy; i++)
            {
                string enemyname = HokageMansion.clickedmission.name.Substring(0, HokageMansion.clickedmission.name.Length - 5);
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"/img/"+enemyname+"_stand.gif", UriKind.Relative);
                bitmap.EndInit();
                Image img = new Image();
                img.Height = 130;
                img.Width = 130;
                ImageBehavior.SetAnimatedSource(img, bitmap);
                ImageBehavior.SetRepeatBehavior(img, RepeatBehavior.Forever);
                img.Source = bitmap;
                Background_Canvas.Children.Add(img);
                Canvas.SetLeft(img, rnd.Next(500,1500));
                Canvas.SetTop(img, 425);
                mobsimg.Add(img);
                Enemy enemy = new Enemy(i,enemyname, Village.naruto.level,Canvas.GetLeft(img),Canvas.GetTop(img));
                enemy.LimitToRange(enemy.level, 1, 5);
                mobs.Add(enemy);
                mobssorted = mobs.OrderByDescending(o => o.positionx).ToList();
                currentEnemy = mobssorted[mobid];
            }
        }
        public static void startMove()
        {
            dt.Start();
            Parallax.parallaxStart();
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_run.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(narutoimg, image);
            ImageBehavior.SetRepeatBehavior(narutoimg, RepeatBehavior.Forever);
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
        public void Page_Unloaded(object sender, EventArgs e)
        {
            P = null;
        }
    }
}
