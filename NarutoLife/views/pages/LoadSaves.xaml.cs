using NarutoLife.model;
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

namespace NarutoLife.views.pages
{
    /// <summary>
    /// Interakční logika pro LoadSaves.xaml
    /// </summary>
    public partial class LoadSaves : Page
    {
        public static List<GameSave> gameSaves = new List<GameSave>();
        Frame mainframe;
        string keyframe;
        public LoadSaves(Frame Mainframe, string Keyframe)
        {
            InitializeComponent();
            saveinfo.Visibility = Visibility.Hidden;
            mainframe = Mainframe;
            keyframe = Keyframe;
            if (File.Exists(@"gamesaves.json"))
            {
                gameSaves = JsonConvert.DeserializeObject<List<GameSave>>(File.ReadAllText(@"gamesaves.json"));
            }
            else
            {
                gameSaves = new List<GameSave>();
            }
            generateButtons();

        }

        private void generateButtons()
        {
            stackpanel.Children.Clear();
            foreach(GameSave gs in gameSaves)
            {
                StackPanel sp = new StackPanel();
                sp.Height = 100;
                sp.Width = 500;
                sp.Orientation = Orientation.Horizontal;
                if (keyframe.Equals("Settings"))
                {
                    Button br = new Button();
                    br.Width = 80;
                    br.Height = 40;
                    br.Tag = gs.id;
                    br.Content = "Resave";
                    br.Click += ResaveGame;
                    br.Margin = new Thickness(5);
                    sp.Children.Add(br);
                }
                Button bre = new Button();
                bre.Width = 80;
                bre.Height = 40;
                bre.Tag = gs.id;
                bre.Content = "Rename";
                bre.Click += Rename;
                bre.Margin = new Thickness(5);
                Button b = new Button();
                b.Width = 80;
                b.Height = 40;
                b.Tag = gs.id;
                b.Content = "Load";
                b.Click += LoadGame;
                b.Margin = new Thickness(5);
                Button bd = new Button();
                bd.Width = 80;
                bd.Height = 40;
                bd.Tag = gs.id;
                bd.Content = "Delete";
                bd.Click += DeleteSave;
                bd.Margin = new Thickness(5);
                TextBlock info = new TextBlock();
                info.Text = gs.name + "\n" + "Level: " + gs.naruto.level.ToString() + " - " + "Time: " + gs.datetime.ToString("HH:mm");
                sp.Children.Add(info);
                sp.Children.Add(bre);
                sp.Children.Add(b);
                sp.Children.Add(bd);          
                sp.Background = Brushes.White;
                stackpanel.Children.Add(sp);
            }
        }
        string renameid;
        private void Rename(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            renameid = b.Tag.ToString();
            newsaveconfirm.Visibility = Visibility.Visible;
        }
        private void Confirm_NewSave(object sender, RoutedEventArgs e)
        {
            foreach (GameSave gs in gameSaves)
            {
                if (gs.id.Equals(int.Parse(renameid)))
                {
                    gameSaves[gs.id - 1].name = newnameinput.Text;
                    generateButtons();
                    newsaveconfirm.Visibility = Visibility.Hidden;
                    saveinfo.Text = "New name has been set.";
                }
            }
        }
        private void LoadGame(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            foreach(GameSave gs in gameSaves)
            {
                if (gs.id.Equals(b.Tag))
                {
                    mainframe.Navigate(new Village(gs.datetime,gs.naruto, mainframe));
                }
            }
        }

        private void DeleteSave(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            foreach (GameSave gs in gameSaves)
            {
                if (gs.id.Equals(b.Tag))
                {
                    gameSaves.Remove(gs);
                    File.WriteAllText(@"gamesaves.json", JsonConvert.SerializeObject(gameSaves));
                    generateButtons();
                    break;
                }
            }
        }

        private void ResaveGame(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            foreach (GameSave gs in gameSaves)
            {
                if (gs.id.Equals(b.Tag))
                {
                    gameSaves[gs.id - 1] = new GameSave(gs.id - 1, gameSaves[gs.id - 1].name, Village.naruto, Village.datetime);
                    File.WriteAllText(@"gamesaves.json", JsonConvert.SerializeObject(gameSaves));
                    generateButtons();
                    break;
                }
            }
        }
        private void GoMenu(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Menu());
        }
        private void Confirm_Save(object sender, RoutedEventArgs e)
        {
            saveinfo.Visibility = Visibility.Visible;
            saveconfirm.Visibility = Visibility.Hidden;
            int lastid = 0;
            foreach (GameSave g in LoadSaves.gameSaves)
            {
                if (g.id > lastid)
                {
                    lastid = g.id;
                }
            }
            GameSave gs = new GameSave(lastid + 1, nameinput.Text, Village.naruto, Village.datetime);
            LoadSaves.gameSaves.Add(gs);
            File.WriteAllText(@"gamesaves.json", JsonConvert.SerializeObject(LoadSaves.gameSaves));
            generateButtons();
        }

        private void NewSave(object sender, RoutedEventArgs e)
        {
            if(Village.naruto != null)
            {
                if (LoadSaves.gameSaves != null)
                {
                    if (LoadSaves.gameSaves.Count() == 3)
                    {
                        saveinfo.Text = "You can have only 3 saves";
                    }
                    else
                    {
                        saveconfirm.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                saveinfo.Visibility = Visibility.Visible;
                saveinfo.Text = "Game has not been loaded yet.";
                saveinfo.Foreground = Brushes.Red;
            }
        }

        private void GoVillage(object sender, RoutedEventArgs e)
        {
            if(Village.naruto != null)
            {
                mainframe.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
            }
            else
            {
                saveinfo.Visibility = Visibility.Visible;
                saveinfo.Text = "Game has not been loaded yet.";
                saveinfo.Foreground = Brushes.Red;
            }
        }
    }
}
