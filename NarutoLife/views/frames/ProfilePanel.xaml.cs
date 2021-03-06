﻿using NarutoLife.views.pages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro ProfilePanel.xaml
    /// </summary>
    public partial class ProfilePanel : Page
    {
        string framekey;
        public ProfilePanel(string Framekey)
        {
            InitializeComponent();
            framekey = Framekey;
            setInfo();
        }
        private void Profile_Close(object sender, RoutedEventArgs e)
        {
            if (framekey.Equals("Village"))
            {
                Village.Profile_off();
            }
            else if (framekey.Equals("Home"))
            {
                Home.Profile_off();
            }
            else if (framekey.Equals("Battleground"))
            {
                Battleground.Profile_Off();
            }
            else if (framekey.Equals("Hospital"))
            {
                Hospital.Profile_Off();
            }
            else if (framekey.Equals("IchirakuRamen"))
            {
                IchirakuRamen.Profile_Off();
            }
        }
        int profilebg = 1;
        private void Profile_Bgnext(object sender, RoutedEventArgs e)
        {
            profilebg++;
            setInfo();
        }
        private void Profile_Bgprevious(object sender, RoutedEventArgs e)
        {
            profilebg--;
            setInfo();
        }
        private void AnimationCompleted(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_stand.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Naruto, image);
            ImageBehavior.SetRepeatBehavior(Naruto, RepeatBehavior.Forever);
        }
        private void setInfo()
        {
            levellabel.Content = "Naruto Uzumaki LV. " + Village.naruto.level;
            switch (profilebg)
            {
                case 0:
                    profile_bg.Source = new BitmapImage(new Uri(@"../../img/profilebg3.jpg", UriKind.Relative));
                    profilebg = 3;
                    break;
                case 1:
                    profile_bg.Source = new BitmapImage(new Uri(@"../../img/profilebg1.jpg", UriKind.Relative));
                    break;
                case 2:
                    profile_bg.Source = new BitmapImage(new Uri(@"../../img/profilebg2.jpg", UriKind.Relative));
                    break;
                case 3:
                    profile_bg.Source = new BitmapImage(new Uri(@"../../img/profilebg3.jpg", UriKind.Relative));
                    break;
                case 4:
                    profile_bg.Source = new BitmapImage(new Uri(@"../../img/profilebg1.jpg", UriKind.Relative));
                    profilebg = 1;
                    break;
            }
            decimal decimalexpbar = (decimal)Village.naruto.explevel / (decimal)Village.naruto.maxexplevel * 100;
            explevelbar.Value = (int)decimalexpbar;
            string taijutsu = Village.naruto.taijutsu.ToString();
            string quickness = Village.naruto.quickness.ToString();
            string vitality = Village.naruto.vitality.ToString();
            string accuracy = Village.naruto.accuracy.ToString();
            string chakracontrol = Village.naruto.chakracontrol.ToString();
            stats.Content = "\n Taijutsu: " + taijutsu + "\n Quickness: " + quickness + "\n Chakra control: " + chakracontrol + "\n Accuracy: " + accuracy + "\n Vitality: " + vitality;
        }
    }
}
