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
        public Training(DateTime getdatetime)
        {
            InitializeComponent();
            Info.Text = "How long do you want to train?\n " +
                "1 hour = 10 seconds\n" +
                "0,5 hours = 5 seconds\n" +
                "(Recommended limit are 6 hours max)"  ;
            time = getdatetime;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num;
            if (double.TryParse(Hours.Text, out num) && num > 0)
            {
                NavigationService.Navigate(new Training_taijutsu(num,time));
            }
           
        }

    }
}
