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

namespace NarutoLife.views.frames
{
    /// <summary>
    /// Interakční logika pro Iventory.xaml
    /// </summary>
    public partial class Inventory : Page
    {
        string framekey;
        static Grid GRid;
        public Inventory(string Framekey)
        {
            InitializeComponent();
            framekey = Framekey;
            GRid = grid;
            generateItems();
        }
        public static void generateItems()
        {
            GRid.Children.Clear();
            foreach (Item item in Village.naruto.inventory)
            {
                TextBlock t = new TextBlock();
                t.Text = item.Name + " " + item.Number.ToString() + "x";
                t.TextAlignment = TextAlignment.Center;
                t.FontSize = 10;
                Image i = new Image();
                StackPanel sp = new StackPanel();
                sp.Children.Add(t);
                t.Margin = new Thickness(5);
                i.Height = 40;
                i.Source = new BitmapImage(new Uri(@"../../img/" + item.Tag + ".png", UriKind.Relative));
                sp.Children.Add(i);
                sp.Background = Brushes.Gray;
                if (item.Consumable)
                {
                    Button b = new Button();
                    b.Click += ConsumeItem;
                    b.Content = "Use";
                    b.Height = 20;
                    b.Width = 40;
                    b.Tag = item.Tag;
                    b.Margin = new Thickness(5);
                    sp.Children.Add(b);
                }
                Grid.SetColumn(sp, item.Xinv);
                Grid.SetRow(sp, item.Yinv);
                GRid.Children.Add(sp);
            }
        }
        private static void ConsumeItem(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            foreach(Item i in Village.naruto.inventory)
            {
                if (i.Tag.Equals(b.Tag))
                {
                    i.Number--;
                    if (i.Number <= 0)
                    {
                        Village.naruto.inventory.Remove(i);
                        break;
                    }
                }
            }
            if (b.Tag.Equals("healthpotion"))
            {
                Village.naruto.health += 10;
                Battleground.updateStats();    
            }
            else if (b.Tag.Equals("sushi"))
            {
                Village.naruto.happiness += 20;
                ProfileBar.updateStats();
            }
            generateItems();
        }

        private void Inventory_Close(object sender, RoutedEventArgs e)
        {
            if (framekey.Equals("Village"))
            {
                Village.Inventory_Close();
            }
            if (framekey.Equals("Battleground"))
            {
                Battleground.Inventory_Close();
            }
        }
    }
}
