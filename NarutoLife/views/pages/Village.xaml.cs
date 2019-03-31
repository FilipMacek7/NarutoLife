using NarutoLife.model;
using NarutoLife.views.frames;
using NarutoLife.views.pages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Game.xaml
    /// </summary>
    public partial class Village : Page
    {
        static public Frame st;
        static public Frame pr;
        static public Frame inv;
        static public Frame mainframe;
        static Frame tr;
        static string framekey = "Village";
        static public Character naruto;
        public static DateTime datetime;
        static ImageBrush ib;
        DispatcherTimer dt = new DispatcherTimer();
        public Village(DateTime getdatetime, Character Naruto, Frame Mainframe)
        {
            InitializeComponent();           
            datetime = getdatetime;
            naruto = Naruto;           
            st = settings;
            pr = profile;
            inv = inventory;
            mainframe = Mainframe;
            ib = background;
            tr = training;
            setInfo();
            NavigationCommands.BrowseBack.InputGestures.Clear();
            NavigationCommands.BrowseForward.InputGestures.Clear();
            listpanel.Navigate(new ListPanel("Village"));
        }
        public static void Inventory_On()
        {
            inv.Navigate(new Inventory("Village"));
        }
        public static void Settings_On()
        {
            st.Navigate(new Settings("Village"));
        }
        public static void Settings_Off()
        {
            st.Navigate(null);
        }
        private void setInfo()
        {
            profilebar.Navigate(new ProfileBar(framekey));
            time.Navigate(new Time(framekey));
            naruto.health = naruto.LimitToRange(naruto.health, 0, (int)naruto.maxhealth);
            naruto.chakra = naruto.LimitToRange(naruto.chakra, 0, (int)naruto.maxchakra);
            naruto.happiness = naruto.LimitToRange(naruto.happiness, 0, naruto.maxhappiness);
            naruto.energy = naruto.LimitToRange(naruto.energy, 0, naruto.maxenergy);
        }
        private void Training_Button(object sender, RoutedEventArgs e)
        {
            training.Navigate(new Training());
        }
        private void Home_Button(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Home());
        }

        private void HokageMansion_Button(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new HokageMansion());
        }
        public static void Exit_menu()
        {
            st.Navigate(null);
            mainframe.Navigate(new Menu());
        }
        public static void Profile_on()
        {
            pr.Navigate(new ProfilePanel(framekey));
        }
        public static void Profile_off()
        {
            pr.Navigate(null);
        }
        public static void Background_set(DateTime Datetime)
        {
            datetime = Datetime;
            if (datetime.Hour < 16 & datetime.Hour > 5)
            {
                ib.ImageSource = new BitmapImage(new Uri(@"img/konoha_afternoon.jpg", UriKind.Relative));
            }
            else if (datetime.Hour > 15 & datetime.Hour < 19)
            {
                ib.ImageSource = new BitmapImage(new Uri(@"img/konoha_colorfulevening.jpg", UriKind.Relative));
            }
            else if (datetime.Hour > 18 & datetime.Hour < 21)
            {
                ib.ImageSource = new BitmapImage(new Uri(@"img/konoha_evening.jpg", UriKind.Relative));
            }
            else if (datetime.Hour > 21 || datetime.Hour < 5)
            {
                ib.ImageSource = new BitmapImage(new Uri(@"img/konoha_night.jpg", UriKind.Relative));
            }
        }
        public static void Taijutsu_Navigate(int Num)
        {
            mainframe.Navigate(new Training_taijutsu(Num));
        }
        public static void Chakra_Navigate(int Num)
        {
            mainframe.Navigate(new Training_chakra(Num));
        }
        public static void Quickness_Navigate(int Num)
        {
            mainframe.Navigate(new Training_quickness(Num));
        }
        public static void Accuracy_Navigate(int Num)
        {
            mainframe.Navigate(new Training_accuracy(Num));
        }
        public static void Training_close()
        {
            tr.Navigate(null);
        }

        private void Shop_open(object sender, RoutedEventArgs e)
        {
            shopbar.Visibility = Visibility.Visible;
        }
        int itemcost;
        string itemname;
        bool itemconsumable;
        bool itemstackable;
        string tag;
        private void Buy_Button(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            tag = b.Tag.ToString();
            if (tag.Equals("healpotion"))
            {
                itemname = "Heal potion";
                itemcost = 50;
                itemconsumable = true;
                itemstackable = true;
            }
            else if (tag.Equals("sushi"))
            {
                itemname = "Sushi";
                itemcost = 60;
                itemconsumable = true;
                itemstackable = true;
            }
            else if (tag.Equals("kunai"))
            {
                itemname = "Kunai";
                itemcost = 30;
                itemconsumable = false;
                itemstackable = true;
            }
            else if (tag.Equals("shuriken"))
            {
                itemname = "Shuriken";
                itemcost = 20;
                itemconsumable = false;
                itemstackable = true;
            }
            buyconfirm.Visibility = Visibility.Visible;
            numberbuyst.Text = numberbuy.ToString() + " for " + numberbuy * itemcost + " yen";
        }
        int numberbuy = 1;
        private void Numberbuy_previous(object sender, RoutedEventArgs e)
        {
            if(numberbuy != 1)
            {
                numberbuy--;
            }
            numberbuyst.Text = numberbuy.ToString() + " for " + numberbuy * itemcost + " yen";
        }

        private void Numberbuy_next(object sender, RoutedEventArgs e)
        {
            numberbuy++;
            numberbuyst.Text = numberbuy.ToString() + " for " + numberbuy * itemcost + " yen";
        }
        int currentx = -1;
        int sety = 1;
        private void Confirm_buy(object sender, RoutedEventArgs e)
        {
            if(naruto.yen >= itemcost * numberbuy)
            {
                naruto.yen -= numberbuy * itemcost;
                ProfileBar.updateStats();     
                foreach(Item i in naruto.inventory)
                {
                    if (i.Xinv == 4 & i.Yinv == 1)
                    {
                        buyconfirm.Visibility = Visibility.Hidden;
                        buyinfo.Text = "You have full inventory.";
                        buyinfo.Foreground = Brushes.Red;
                    }
                    else
                    {
                        if (i.Xinv == 4)
                        {
                            currentx = 0;
                            sety = 1;
                        }
                        else if (i.Xinv > currentx)
                        {
                            currentx = i.Xinv;
                        }
                    }
                }
                Item item = new Item(itemname,tag, numberbuy, itemconsumable, itemstackable);
                item.Xinv = currentx + 1;
                item.Yinv = sety;
                naruto.inventory.Add(item);
                buyconfirm.Visibility = Visibility.Hidden;
                buyinfo.Text = "You have bought " + numberbuy.ToString() + "x " + itemname + " for " + (numberbuy * itemcost).ToString() + " yen succefuly.";
                buyinfo.Foreground = Brushes.Green;
            }
            else
            {
                buyconfirm.Visibility = Visibility.Hidden;
                buyinfo.Text = "You don't have enough money";
                buyinfo.Foreground = Brushes.Red;
            }
        }
        private void Buyconfirm_Close(object sender, RoutedEventArgs e)
        {
            buyconfirm.Visibility = Visibility.Hidden;
        }
        private void Shop_Close(object sender, RoutedEventArgs e)
        {
            shopbar.Visibility = Visibility.Hidden;
        }
        public static void Inventory_Close()
        {
            inv.Navigate(null);
        }
        private void GoHospital(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Hospital());
        }
    }
}
