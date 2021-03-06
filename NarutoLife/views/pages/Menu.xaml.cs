﻿using NarutoLife.model;
using NarutoLife.views.pages;
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

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        Sound menu = new Sound();
        static Frame fr;
        public Menu()
        {
            InitializeComponent();
            //menu.Play("menu.mp3");
            menu.SetVolume(25);
        }
        public Menu(Frame Fr) : this()
        {
            fr = Fr;
        }
        private void Button_Start(object sender, RoutedEventArgs e)
        {
            Character naruto = new Character();
            naruto.yen = 300;

            naruto.taijutsu = 3;
            naruto.quickness = 3;
            naruto.vitality = 4;
            naruto.accuracy = 3;
            naruto.chakracontrol = 2;

            naruto.maxhealth = 30 + naruto.vitality + naruto.vitality / 1.5;
            naruto.maxchakra = 20 + naruto.chakracontrol + naruto.chakracontrol / 1.5;
            naruto.maxhappiness = 100;
            naruto.maxenergy = 50;

            naruto.health = (int)naruto.maxhealth;
            naruto.chakra = (int)naruto.maxchakra;
            naruto.happiness = 70;
            naruto.energy = 45;

            naruto.mindamage = 2;
            naruto.maxdamage = 5 + naruto.taijutsu;

            naruto.exptaijutsu = 0;
            naruto.expquickness = 0;
            naruto.expchakra = 0;
            naruto.expaccuracy = 0;
            naruto.explevel = 0;

            naruto.level = 1;
            naruto.maxcombat += naruto.level;
            DateTime date = new DateTime(2000, 10, 13, 6, 0, 0);
            NavigationService.Navigate(new Village(date, naruto, fr));
            menu.Stop();       
            //menu.Play("morning.mp3");
            menu.SetVolume(25);
        }

        private void Button_Load(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoadSaves(fr,"Menu"));
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {

        }
    }
}