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
namespace NarutoLife.views.pages
{
    /// <summary>
    /// Interakční logika pro PreBattleground.xaml
    /// </summary>
    public partial class PreBattleground : Page
    {
        DispatcherTimer dt = new DispatcherTimer();
        Mission mission;
        Character naruto;
        Frame mainframe;
        List<Enemy> mobs = new List<Enemy>();
        List<Image> mobsimg = new List<Image>();
        Enemy currentEnemy;
        static Grid currentGrid;
        public PreBattleground(DateTime Datetime, Character Naruto, Mission Mis, Frame Mainframe)
        {
            InitializeComponent();
            mainframe = Mainframe;
            mission = Mis;
            naruto = Naruto;
            generateMobs();
            Parallax.BackgroundMove(background1, background2, background3, background4, background5, background11, background21, background31, background41, background51,rect8,jg2,mobsimg, 3);
            dt.Interval = TimeSpan.FromMilliseconds(500);
            dt.Tick += dtTicker;
            dt.Start();

            dt2.Interval = TimeSpan.FromTicks(1);
            dt2.Tick += dtTicker2;
            dt2.Start();
        }
        int i = 0;//362,638
        private void dtTicker(object sender, EventArgs e)
        {
            if(Canvas.GetLeft(Naruto) == 3000)
            {
                Parallax.turnAround();
            }
            //mob detect
            foreach (Enemy mob in mobs)
            {
                foreach(Image img in mobsimg)
                {
                    if (Canvas.GetLeft(img) - Canvas.GetLeft(Naruto) < 300 & !mob.pass)
                    {
                        stopMove();
                        TextBlock tb = new TextBlock();
                        tb.Text = mission.name.Substring(mission.name.Length - 5) + " LV:" + mob.level;
                        Button yes = new Button();
                        yes.Click += enterBattle;
                        yes.Height = 30;
                        yes.Width = 60;
                        yes.Content = "Battle";
                        yes.Margin = new Thickness(10);
                        yes.HorizontalAlignment = HorizontalAlignment.Left;
                        Button no = new Button();
                        no.Click += startMove;
                        no.Height = 30;
                        no.Width = 60;
                        no.Content = "Pass";
                        no.Tag = mob.id;
                        no.Margin = new Thickness(10);
                        no.HorizontalAlignment = HorizontalAlignment.Right;
                        Grid gr = new Grid();
                        gr.Background = Brushes.LightGray;
                        gr.Height = 100;
                        gr.Width = 150;
                        Canvas.SetLeft(gr, Canvas.GetLeft(img));
                        Canvas.SetTop(gr, Canvas.GetTop(img) - 100);
                        gr.Children.Add(tb);
                        gr.Children.Add(yes);
                        gr.Children.Add(no);
                        currentGrid = gr;
                        Background_Canvas.Children.Add(gr);
                        currentEnemy = mob;
                    }
                }

            }
            //end map
            if (Canvas.GetLeft(narutocursed) == 638)
            {
                stopMove();
            }
            i++;
            Canvas.SetLeft(narutocursed, Canvas.GetLeft(narutocursed) + i);
        }
        private void enterBattle(object sender, EventArgs e)
        {
            mainframe.Navigate(new Battleground(naruto, currentEnemy, mainframe));
        }
        Random rnd = new Random();
        private void generateMobs()
        {
            for(int i = 0; i < mission.numberOfEnemy; i++)
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
                    Canvas.SetLeft(img, rnd.Next(250,2500));
                    Canvas.SetTop(img, 425);
                    mobsimg.Add(img);
                    Enemy wolf = new Enemy(i,naruto.level,Canvas.GetLeft(img),Canvas.GetTop(img));
                    mobs.Add(wolf);
                }
            }
        }
        private void startMove(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            currentGrid.Visibility = Visibility.Hidden;
            foreach (Enemy m in mobs)
            {
                if(m.id == int.Parse(b.Tag.ToString()))
                {
                    mobs.Remove(m);
                    break;
                }
            }          
            currentEnemy.pass = true;
            mobs.Add(currentEnemy);
            mouseControl = true;
            dt.Start();
            Parallax.parallaxStart();
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_run.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Naruto, image);
            ImageBehavior.SetRepeatBehavior(Naruto, RepeatBehavior.Forever);
        }
        private void stopMove()
        {
            mouseControl = false;
            dt.Stop();
            Parallax.parallaxStop();
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_stand.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Naruto, image);
            ImageBehavior.SetRepeatBehavior(Naruto, RepeatBehavior.Forever);
        }
        public partial class NativeMethods
        {
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool SetCursorPos(int X, int Y);
        }
        bool mouseControl = true;
        DispatcherTimer dt2 = new DispatcherTimer();
        private void dtTicker2(object sender, EventArgs e)
        {
            if(mouseControl == true) NativeMethods.SetCursorPos(0,0);
        }

    }
}
