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
        DateTime datetime;
        int num = 1;
        Character naruto;
        public Training(DateTime getdatetime, Character Naruto)
        {
            InitializeComponent();
            Trainhours.Text = num.ToString();
            datetime = getdatetime;
            naruto = Naruto;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training_taijutsu(num, datetime, naruto));     
        }
        private void Training_hnext(object sender,RoutedEventArgs e)
        {
            if (naruto.energy - num * 10 > 10)
            {
                num++;
            }         
            Trainhours.Text = num.ToString();
        }
        private void Training_hprevious(object sender, RoutedEventArgs e)
        {
            if(num > 1)
            {
                num--;
            }
            Trainhours.Text = num.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training_quickness(num, datetime, naruto));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training_accuracy(num, datetime, naruto));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training_chakra(num, datetime, naruto));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Village(datetime, naruto));
        }
    }
}
