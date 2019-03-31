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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Training_accuracy.xaml
    /// </summary>
    public partial class Training_accuracy : Page
    {
        int i;
        int hours;
        int speed = 15;
        bool goUp;
        bool goDown = true;
        bool goLeft;
        bool goRight;
        public Training_accuracy(int Hours)
        {
            InitializeComponent();
            i = hours * 10;
            time.Content = "Time left: " + i.ToString();
            canvasx.Content = Canvas.GetLeft(rec1).ToString();
            canvasy.Content = Canvas.GetTop(rec1).ToString();
        }       
        private void Timer_Tick(object sender, EventArgs e)
        {
            canvasx.Content = "CanvasX: " + Canvas.GetLeft(rec1).ToString();
            canvasy.Content = "CanvasY: " + Canvas.GetTop(rec1).ToString();           
            if (goUp)
            {
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) - speed);
                if (Canvas.GetTop(rec1) == 0)
                {
                    goDown = true;
                    goUp = false;
                }
            }
            else if (goDown)
            {
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) + speed);
                if (Canvas.GetTop(rec1) > Application.Current.MainWindow.Height - rec1.Height * 2 )
                {
                    goDown = false;
                    goUp = true;
                }
            }
            if (goLeft )
            {
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) - speed);
                if(Canvas.GetLeft(rec1) == 0 - Application.Current.MainWindow.Width / 2)
                {
                    goLeft = false;
                    goRight = true;
                }
            }
            else if (goRight)
            {
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) + speed);
                if(Canvas.GetLeft(rec1) == Application.Current.MainWindow.Width / 2)
                {
                    goLeft = true;
                    goRight = false;
                }
            }
        }
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer dt = new DispatcherTimer();
        private void dtTicker(object sender, EventArgs e)
        {
            i--;
            time.Content = "Time left: " + i.ToString();
            if (i == 0)
            {
                goDown = false;
                goUp = false;
                goLeft = false;
                goRight = false;
                Village.naruto.expaccuracy = Village.naruto.expaccuracy + score / 4;
                Village.naruto.explevel = Village.naruto.explevel + score / 100;
                Village.naruto.energy = Village.naruto.energy - hours * 5 + Village.naruto.vitality / 2;
                Village.naruto.happiness = Village.naruto.happiness - hours * 10;
                Village.datetime = Village.datetime.AddHours(hours);
                trainingdone.Navigate(new Training_done("Accuracy training", score));
                dt.Stop();
            }

        }
        int score = 0;
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += Page_PreviewKeyDown;
            this.Focusable = true;
            this.Focus();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();

            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
            dispatcherTimer.Start();
        }
        void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Random rnd = new Random();
            string shuriken = "";
            int rndshuriken = rnd.Next(0, 5);       
            switch (rndshuriken)
            {
                case 0:
                    shuriken = "shuriken";
                    break;
                case 1:
                    shuriken = "shuriken1";
                    break;
                case 2:
                    shuriken = "shuriken2";
                    break;
                case 3:
                    shuriken = "shuriken3";
                    break;
                case 4:
                    shuriken = "shuriken4";
                    break;
            }
            BitmapImage bi = new BitmapImage();
            double plusscore = 0;
            if (e.Key == Key.Enter)
            {             
                bi.BeginInit();
                bi.UriSource = new Uri(@"/img/"+ shuriken +".png", UriKind.Relative);
                bi.EndInit();
                kunaipanel.Source = bi;
                kunaipanel.Height = 50;
                kunaipanel.Width = 50;
                Canvas.SetTop(kunaipanel, Canvas.GetTop(rec1));
                Canvas.SetLeft(kunaipanel, Canvas.GetLeft(rec1));
                kunaipanel.Source = bi;         
                if (goDown)
                {
                    double gettop = 0;
                    if(Canvas.GetTop(rec1) < Application.Current.MainWindow.Height / 2)
                    {
                        gettop = Application.Current.MainWindow.Height / 2 - Canvas.GetTop(rec1);
                    }
                    else if(Canvas.GetTop(rec1) > Application.Current.MainWindow.Height / 2)
                    {
                        gettop = Canvas.GetTop(rec1) - Application.Current.MainWindow.Height / 2;
                    }                
                    if (Canvas.GetTop(rec1) < 371 & Canvas.GetTop(rec1) > 169)
                    {
                        if(Canvas.GetTop(rec1) >= 270)
                        {
                            plusscore = ((370 - Canvas.GetTop(rec1))  / 100) * 100;
                        }
                        else
                        {
                            plusscore = (Canvas.GetTop(rec1) * 100) / 270;
                        }
                        plusscorelabel.Content = "+ " + Convert.ToInt32(plusscore / 8).ToString();
                        score = score + Convert.ToInt32(plusscore) / 8;
                    }
                    goDown = false;
                    goRight = true;
                    Canvas.SetTop(rec1, Application.Current.MainWindow.Height / 2 - rec1.Height);
                    Canvas.SetLeft(rec1, 0 - Application.Current.MainWindow.Width / 2);
                }
                //dodělat x
                else if(goRight){
                    double getleft = Canvas.GetLeft(rec1);
                    if (Canvas.GetLeft(rec1) < 0)
                    {
                        getleft = 0 - Canvas.GetLeft(rec1);
                    }
                    if (Canvas.GetLeft(rec1) < 101 & Canvas.GetLeft(rec1) > -101)
                    {
                        if (Canvas.GetLeft(rec1) > 0)
                        {
                            plusscore = 100 - Canvas.GetLeft(rec1);
                        }
                        else
                        {
                            plusscore = 100 + Canvas.GetLeft(rec1);
                        }
                        plusscorelabel.Content = "+ " + Convert.ToInt32(plusscore / 8).ToString();
                        score = score + Convert.ToInt32(plusscore) / 8;
                    }

                    goRight = false;
                    goDown = true;
                    Canvas.SetTop(rec1, 0);
                    Canvas.SetLeft(rec1, 0);
                }
                Score.Content = "Score: " + score.ToString();
            }
        }
    }
}
