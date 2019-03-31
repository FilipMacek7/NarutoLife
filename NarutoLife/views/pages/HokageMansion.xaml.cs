using NarutoLife.model;
using NarutoLife.views.pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WpfAnimatedGif;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro HokageMansion.xaml
    /// </summary>
    public partial class HokageMansion : Page
    {
        Button bz = new Button();
        List<Mission> missions;
        public static Mission clickedmission;
        public HokageMansion()
        {
            InitializeComponent();
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
            if(Village.naruto.level < 10)
            {
                bb.IsEnabled = false;
                ba.IsEnabled = false;
            }
            else if(Village.naruto.level > 10)
            {
                bb.IsEnabled = true;
            }
            else if(Village.naruto.level > 20)
            {
                ba.IsEnabled = true;
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
        Random rnd = new Random();
        private void GenerateMissions()
        {
            bz.Visibility = Visibility.Visible;
            typepanel.Visibility = Visibility.Collapsed;
            missionpanel.Visibility = Visibility.Visible;
            int lastid = 0;
            if (missions.Any())
            {
                foreach (Mission m in missions)
                {
                    if (m.id > lastid)
                    {
                        lastid = m.id;
                    }
                }
            }
            if (!missionson)
            {
                missionson = true;
                List<int> currentids = new List<int>();
                for (int id = lastid; id < lastid + 4; id++)
                {
                    currentids.Add(id);
                }
                for (int i = missions.Count(); i < 4; i++)
                {
                    string mobname = "";
                    int number = rnd.Next(1, 4);
                    switch (number)
                    {
                        //wolf
                        case 1:
                            mobname = "wolf";
                            break;
                        //spider
                        case 2:
                            mobname = "spider";
                            break;
                        //snake
                        case 3:
                            mobname = "snake";
                            break;
                    }

                    Button b = new Button();
                    b.Margin = new Thickness(5);
                    b.Tag = currentids[i].ToString();
                    b.Background = Brushes.Transparent;
                    b.Click += missionInfoOn;

                    TextBlock tb = new TextBlock();
                    tb.Text = mobname + " hunt";
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.FontSize = 20;
                    tb.FontFamily = new FontFamily("Ninja Naruto");

                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(@"../../img/button_scroll.png", UriKind.Relative));
                    img.Stretch = Stretch.Fill;

                    Grid gr = new Grid();               
                    gr.Children.Add(img);
                    gr.Children.Add(tb);
                    gr.Height = 50;
                    b.Content = gr;
                    int enemyCount = rnd.Next(1, 4);
                    string description = "Defeat " + enemyCount.ToString() + "x " + mobname;
                    Mission mission = new Mission(currentids[i], mobname + " hunt", description, enemyCount,enemyCount*100, missionType.Fight);
                    
                    missions.Add(mission);

                    File.WriteAllText(@"../../missions.json", JsonConvert.SerializeObject(missions));
                    missionpanel.Children.Add(b);
                }
            }
        }

        private void missionInfoOn(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            foreach (Mission m in missions)
            {
                if (m.id == int.Parse(b.Tag.ToString()))
                {
                    clickedmission = m;
                }
            }
            mission_info.Visibility = Visibility.Visible;
            infoname.Text = clickedmission.name;
            //img
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"../../img/" + clickedmission.name.Substring(0, clickedmission.name.Length - 5) + "_stand.gif", UriKind.Relative);
            bitmap.EndInit();
            ImageBehavior.SetAnimatedSource(mobimg, bitmap);
            ImageBehavior.SetRepeatBehavior(mobimg, RepeatBehavior.Forever);
            //
            infodescription.Text = clickedmission.description;
            enterBattle.Click += EnterBattle_Click;
        }
        private void missionInfoOff(object sender, RoutedEventArgs e)
        {
            mission_info.Visibility = Visibility.Hidden;
        }
        private void EnterBattle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PreBattleground());
        }

        private void GoVillage(object sender, RoutedEventArgs e)
        {
            Village.mainframe.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            missionson = false;
        }
    }
}
