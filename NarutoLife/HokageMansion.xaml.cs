using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interakční logika pro HokageMansion.xaml
    /// </summary>
    public partial class HokageMansion : Page
    {
        Button bz = new Button();
        public HokageMansion(DateTime getdatetime, Character naruto)
        {
            InitializeComponent();

            bz.VerticalAlignment = VerticalAlignment.Top;
            bz.HorizontalAlignment = HorizontalAlignment.Left;
            bz.Height = 40;
            bz.Width = 50;
            bz.Margin = new Thickness(20);
            bz.Click += GoBack;
            bz.Content = "Go back";
            missiongrid.Children.Add(bz);
            bz.Visibility = Visibility.Collapsed;
        }

        List<Mission> missions = JsonConvert.DeserializeObject<List<Mission>>(File.ReadAllText(@"..\..\..\MissionCreator\bin\Debug\missions.json"));
      
        private void GoBack(object sender, RoutedEventArgs e)
        {
            bz.Visibility = Visibility.Collapsed;
            bc.Visibility = Visibility.Visible;
            bb.Visibility = Visibility.Visible;
            ba.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bz.Visibility = Visibility.Visible;
            bc.Visibility = Visibility.Collapsed;
            bb.Visibility = Visibility.Collapsed;
            ba.Visibility = Visibility.Collapsed;
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bz.Visibility = Visibility.Visible;
            bc.Visibility = Visibility.Collapsed;
            bb.Visibility = Visibility.Collapsed;
            ba.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bz.Visibility = Visibility.Visible;
            bc.Visibility = Visibility.Collapsed;
            bb.Visibility = Visibility.Collapsed;
            ba.Visibility = Visibility.Collapsed;
        }
    }
}
