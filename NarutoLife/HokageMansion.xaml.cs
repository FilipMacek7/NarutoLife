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
        List<Mission> missions = new List<Mission>();
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
            if (File.Exists(@"missions.json"))
            {
                missions = JsonConvert.DeserializeObject<List<Mission>>(File.ReadAllText(@"missions.json"));
            }
        }
    
      
        private void GoBack(object sender, RoutedEventArgs e)
        {
            bz.Visibility = Visibility.Collapsed;
            typepanel.Visibility = Visibility.Visible;
            missionpanel.Visibility = Visibility.Collapsed;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GenerateMissions();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GenerateMissions();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GenerateMissions();
        }
        bool missionson = false;
        private void GenerateMissions()
        {
            bz.Visibility = Visibility.Visible;
            typepanel.Visibility = Visibility.Collapsed;
            missionpanel.Visibility = Visibility.Visible;
            if (!missionson)
            {
                missionson = true;
                for (int i = 0; i < 4; i++)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(1, 4);
                    Button b = new Button();
                    b.Height = 50;
                    b.Margin = new Thickness(10);

                    switch (number)
                    {
                        //wolf
                        case 1:
                            b.Name = "Wolf";
                            break;
                        //spider
                        case 2:
                            b.Name = "Spider";
                            break;
                        //snake
                        case 3:
                            b.Name = "Snake";
                            break;
                    }
                    b.Content = b.Name + " hunt";
                    Mission mission = new Mission(b.Name + " hunt", missionType.Fight);
                    missions.Add(mission);
                    File.WriteAllText(@"missions.json", JsonConvert.SerializeObject(missions));
                    b.Click += NavigateBattleground;
                    missionpanel.Children.Add(b);

                }
            }

        }

        private void NavigateBattleground(object sender, RoutedEventArgs e)
        {
            Button b= (Button)sender;
            NavigationService.Navigate(new Battleground(b.Name));
        }
    }
}
