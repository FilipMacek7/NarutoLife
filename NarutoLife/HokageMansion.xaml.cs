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
        public HokageMansion(DateTime getdatetime, Character naruto)
        {
            InitializeComponent();
        }

        List<Mission> missions = JsonConvert.DeserializeObject<List<Mission>>(File.ReadAllText(@"..\..\..\MissionCreator\bin\Debug\missions.json"));
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Header.Visibility = Visibility.Hidden;
           
            Button bz = new Button();
            bz.VerticalAlignment = VerticalAlignment.Top;
            bz.HorizontalAlignment = HorizontalAlignment.Left;
            bz.Height = 50;
            bz.Click += GoBack; 
            Label l = new Label();
            l.Content = "Type C";
            l.HorizontalAlignment = HorizontalAlignment.Center;
            l.VerticalAlignment = VerticalAlignment.Top;
            l.Height = 50;
            l.FontSize = 30;
            l.Name = "Header";
            missiongrid.Children.Add(l);
            foreach(Mission m in missions)
            {
                if (m.levelType.Equals("C")){
                    Button b = new Button();
                    b.Margin = new Thickness(10, 10, 10, 10);
                    b.Height = 25;
                    b.Content = m.name;
                    missionpanel.Children.Add(b);
                }
            }
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            missiongrid.Children.Clear();

            //missionpanel.Children.Add();
        }
    }
}
