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

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Training_quickness.xaml
    /// </summary>
    public partial class Training_quickness : Page
    {
        int i;
        Character naruto;
        int hours;
        DateTime datetime;
        int score;
        List<string> codes = new List<string>();
        List<int> usedid = new List<int>();
        Random rnd = new Random();
        int rndid;
        string currentw;
        int currentind;
        public Training_quickness(int Hours, DateTime getdatetime, Character Naruto)
        {
            InitializeComponent();
            i = Hours * 10;
            hours = Hours;
            naruto = Naruto;
            datetime = getdatetime;           
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"randomwords.txt");
            while ((line = file.ReadLine()) != null)
            {
                codes.Add(line);
            }

            rndid = rnd.Next(0, 101);
            currentw = codes[rndid];
            currentind = 0;
            rndid = rnd.Next(0, 101);
            while (usedid.Contains(rndid))
            {
                rndid = rnd.Next(0, 101);
            }

            currentw = codes[rndid];           
            scorelabel.Content = "Score: " + score.ToString();
        }

        DispatcherTimer dt = new DispatcherTimer();
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += Page_PreviewKeyDown;
            this.Focusable = true;
            this.Focus();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }
        private void dtTicker(object sender, EventArgs e)
        {
            i--;
            time.Content = "Time left: " + i.ToString();
            if (i == 0)
            {
                table.Visibility = Visibility.Visible;
                endscore.Content = score.ToString();
                endexp.Content = naruto.exptaijutsu.ToString() + " + " + (score / 4).ToString() + "%";
                naruto.exptaijutsu = naruto.exptaijutsu + score / 4;
                naruto.explevel = naruto.explevel + score / 100;
                naruto.energy = naruto.energy - score + (naruto.vitality / 2) * 10;
                naruto.happiness = naruto.happiness - hours * 10;
                datetime = datetime.AddHours(hours);
                dt.Stop();
            }
        }
        KeyConverter k = new KeyConverter();
        void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Key mykey = (Key)k.ConvertFromString(currentw[currentind].ToString());
            if (mykey == e.Key)
            {
                if(currentind + 1 == currentw.Length)
                {
                    currentw = codes[rndid];
                    score++;
                    codex.Content = currentw;
                    scorelabel.Content = "Score: " + score.ToString();
                }
                else
                {
                    currentw.Remove(0, 1);
                    currentind++;                  
                    codex.Content = currentw;
                }             
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Village(datetime, naruto));
        }
    }
}
