using NarutoLife.views.pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro HokageMansion.xaml
    /// </summary>
    public partial class HokageMansion : Page
    {
        Button bz = new Button();
        List<Mission> missions;
        static Frame mainframe;
        DateTime datetime;
        Character naruto;
        public HokageMansion(DateTime Datetime, Character Naruto, Frame Mainframe)
        {
            InitializeComponent();
            naruto = Naruto;
            datetime = Datetime;
            mainframe = Mainframe;
            bz.VerticalAlignment = VerticalAlignment.Top;
            bz.HorizontalAlignment = HorizontalAlignment.Left;
            bz.Height = 20;
            bz.Width = 50;
            bz.Margin = new Thickness(10,10,0,0);
            bz.Click += GoBack;
            bz.Content = "Go back";
            missiongrid.Children.Add(bz);
            bz.Visibility = Visibility.Collapsed;           
            if (File.Exists(@"missions.json"))
            {
                missions = JsonConvert.DeserializeObject<List<Mission>>(File.ReadAllText(@"missions.json"));
            }
            else
            {
                missions = new List<Mission>();
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

                    Grid gr = new Grid();
                    TextBlock tb = new TextBlock();
                    tb.Text = b.Name + " hunt";
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    gr.Children.Add(tb);
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(@"../../img/button_scroll.png", UriKind.Relative));
                    img.Stretch = Stretch.Fill;
                    gr.Children.Add(img);
                    b.Content = gr;
                    b.Background = Brushes.Transparent;
                    b.Click += NavigateBattleground;
                    Mission mission = new Mission(b.Name + " hunt", missionType.Fight);
                    missions.Add(mission);
                    File.WriteAllText(@"../../missions.json", JsonConvert.SerializeObject(missions));
                    missionpanel.Children.Add(b);

                }
            }

        }

        private void NavigateBattleground(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            NavigationService.Navigate(new PreBattleground(b.Name));
        }

        private void GoVillage(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Village(datetime, naruto, mainframe));
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            missionson = false;
        }
    }
}
