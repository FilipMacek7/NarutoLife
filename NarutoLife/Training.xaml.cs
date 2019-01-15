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

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Training.xaml
    /// </summary>
    public partial class Training : Page
    {
        DateTime time;
        double _num = 1; 
        double num {
            get {
                return _num;
            }
            set {
                if(value < 1)
                {
                    return;
                }
                _num = value;
            }
        }
        double taijutsu;
        public Training(DateTime getdatetime, double btaijutsu, double bquickness, double bvitality, double baccuracy)
        {
            InitializeComponent();
            Trainhours.Text = num.ToString();
            time = getdatetime;
            taijutsu = btaijutsu;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training_taijutsu(num, time, taijutsu));     
        }
        private void Training_hnext(object sender,RoutedEventArgs e)
        {
            num++;
            Trainhours.Text = num.ToString();
        }
        private void Training_hprevious(object sender, RoutedEventArgs e)
        {
            num--;
            Trainhours.Text = num.ToString();
        }
    }
}
