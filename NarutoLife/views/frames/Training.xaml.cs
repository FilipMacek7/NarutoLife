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

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Training.xaml
    /// </summary>
    public partial class Training : Page
    {
        int num = 1;
        public Training()
        {
            InitializeComponent();
            Trainhours.Text = num.ToString();
            finishlabel.Content = "You will finish your training at: " + Village.datetime.AddHours(num).ToString("HH:mm");
        }
        
        private void Training_hnext(object sender,RoutedEventArgs e)
        {
            if (Village.naruto.energy - num * 10 > 10)
            {
                num++;
            }         
            Trainhours.Text = num.ToString();
            finishlabel.Content = "You will finish your training at: " + Village.datetime.AddHours(num).ToString("HH:mm");
        }
        private void Training_hprevious(object sender, RoutedEventArgs e)
        {
            if(num > 1)
            {
                num--;
            }
            Trainhours.Text = num.ToString();
            finishlabel.Content = "You will finish your training at: " + Village.datetime.AddHours(num).ToString("HH:mm");
        }
        private void Taijutsu_Button(object sender, RoutedEventArgs e)
        {
            Village.Taijutsu_Navigate(num);
        }
        private void Quickness_Button(object sender, RoutedEventArgs e)
        {
            Village.Quickness_Navigate(num);
        }

        private void Accuracy_button(object sender, RoutedEventArgs e)
        {
            Village.Accuracy_Navigate(num);
        }

        private void Chakra_Button(object sender, RoutedEventArgs e)
        {
            Village.Chakra_Navigate(num);
        }
        private void Training_close(object sender, RoutedEventArgs e)
        {
            Village.Training_close();
        }
    }
}
