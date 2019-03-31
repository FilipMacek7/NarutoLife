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
        public Inventory(string Framekey)
        {
            InitializeComponent();
            framekey = Framekey;
            generateItems();
        }
        private void generateItems()
        {
            grid.Children.Clear();
            foreach (Item item in Village.naruto.inventory)
            {
                TextBlock t = new TextBlock();
                t.Text = item.Name + " " + item.Number.ToString() + "x";
                t.TextAlignment = TextAlignment.Center;
                Image i = new Image();
                StackPanel sp = new StackPanel();
                sp.Children.Add(t);
                i.Height = 55;
                i.Margin = new Thickness(5);
                i.Source = new BitmapImage(new Uri(@"../../img/" + item.Tag + ".png", UriKind.Relative));
                sp.Children.Add(i);
                if (item.Consumable)
                {
                    Button b = new Button();
                    b.Click += ConsumeItem;
                    b.Content = "Use";
                    b.Height = 35;
                    b.Width = 50;
                    b.Tag = item.Tag;
                    sp.Children.Add(b);
                }
                Grid.SetColumn(sp, item.Xinv);
                Grid.SetRow(sp, item.Yinv);
                grid.Children.Add(sp);
            }
        }
        private void ConsumeItem(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            foreach(Item i in Village.naruto.inventory)
            {
                if (i.Tag.Equals(b.Tag))
                {
                    i.Number--;
                    if (i.Number == 0)
                    {
                        Village.naruto.inventory.Remove(i);
                        break;
                    }
                }
            }
            if (b.Tag.Equals("healthpotion"))
            {
                Village.naruto.health += 20;
                Battleground.updateStats();    
            }
            else
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
