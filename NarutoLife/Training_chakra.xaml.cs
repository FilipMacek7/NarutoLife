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

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Training_chakra.xaml
    /// </summary>
    public partial class Training_chakra : Page
    {
        DateTime datetime;
        int i;
        int hours;
        Character naruto;
        double score;
        int randomred;
        Random rnd = new Random();
        public Training_chakra(int Hours, DateTime getdatetime, Character Naruto)
        {
            InitializeComponent();
            hours = Hours;
            i = hours * 10;
            naruto = Naruto;
            datetime = getdatetime;
            randomred = rnd.Next(5, 96);
            redend.Offset = progressbar.Value / 100;
            bluestart.Offset = redend.Offset;
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
                endexp.Content = naruto.expchakra.ToString() + " + " + (score / 4).ToString() + "%";
                naruto.expquickness = naruto.expchakra + score / 4;
                naruto.explevel = naruto.explevel + score / 100;
                naruto.energy = naruto.energy - score / 4 + (naruto.vitality / 2) * 10;
                naruto.happiness = naruto.happiness - hours * 10;
                datetime = datetime.AddHours(hours);
                dt.Stop();
            }

        }
        void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.A & e.IsRepeat & i > 0 & progressbar.Value < randomred)
            {
                progressbar.Value = progressbar.Value + 2;
                redend.Offset = progressbar.Value / 100;
                bluestart.Offset = redend.Offset;
            }
            else if(e.Key == Key.D & e.IsRepeat & i > 0 & progressbar.Value >= randomred){
                bluestart.Color = Colors.Blue;
                blueend.Color = Colors.Blue;
                progressbar.Value = progressbar.Value + 2;

            }
            if (progressbar.Value == 100)
            {
                progressbar.Value = 0;
                randomred = rnd.Next(5, 96);
                redend.Offset = progressbar.Value / 100;
                bluestart.Offset = redend.Offset;
                bluestart.Color = Colors.Transparent;
                blueend.Color = Colors.Transparent;
                score = score + 25;
                Score.Content = "Score: " + score.ToString();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Village(datetime, naruto));
        }
    }
}
