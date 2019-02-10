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
        DateTime datetime;
        int i;
        int hours;
        Character naruto;
        int speed = 20;
        bool goUp;
        bool goDown = true;
        bool goLeft;
        bool goRight;
        public Training_accuracy(int Hours, DateTime getdatetime, Character Naruto)
        {
            InitializeComponent();
            InitializeComponent();
            datetime = getdatetime;
            hours = Hours;
            i = hours * 10;
            time.Content = "Time left: " + i.ToString();
            naruto = Naruto;
            
        }       
        private void Timer_Tick(object sender, EventArgs e)
        {
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
                table.Visibility = Visibility.Visible;
                endscore.Content = score.ToString();
                endexp.Content = naruto.expaccuracy.ToString() + " + " + (score / 4).ToString() + "%";
                naruto.expaccuracy = naruto.expaccuracy + score / 4;
                naruto.explevel = naruto.explevel + score / 100;
                naruto.energy = naruto.energy - score + (naruto.vitality / 2) * 10;
                naruto.happiness = naruto.happiness - hours * 10;
                datetime = datetime.AddHours(hours);
                dt.Stop();
            }

        }
        double score = 0;
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
            double plusscore;
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
                    
                    plusscore = 50 - gettop;
                    score = score + plusscore;
                    goDown = false;
                    goRight = true;
                    Canvas.SetTop(rec1, Application.Current.MainWindow.Height / 2 - rec1.Height);
                    Canvas.SetLeft(rec1, 0 - Application.Current.MainWindow.Width / 2);
                }
                else if(goRight){
                    double getleft = Canvas.GetLeft(rec1);
                    if (Canvas.GetLeft(rec1) < 0)
                    {
                        getleft = 0 - Canvas.GetLeft(rec1);
                    }
                    plusscore = 50 - getleft;
                    score = score + plusscore;
                    goRight = false;
                    goDown = true;
                    Canvas.SetTop(rec1, 0);
                    Canvas.SetLeft(rec1, 0);
                }
                Score.Content = "Score: " + score.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Village(datetime, naruto));
        }
    }
}
