﻿using NarutoLife.model;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Training_quickness.xaml
    /// </summary>
    public partial class Training_quickness : Page
    {
        int i;
        int hours;
        int score;
        List<string> codes = new List<string>();
        List<int> usedid = new List<int>();
        Random rnd = new Random();
        int rndid;
        string currentw;
        int currentind;
        int linecounter = 0;
        public Training_quickness(int Hours)
        {
            InitializeComponent();
            i = Hours * 10;
            hours = Hours;          
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"randomwords.txt");
            while ((line = file.ReadLine()) != null)
            {
                codes.Add(line);
                linecounter++;
            }
            rndid = rnd.Next(0, linecounter);
            usedid.Add(rndid);
            currentw = codes[rndid];
            currentind = 0;
            time.Content = "Time left: " + i.ToString();
            scorelabel.Content = "Score: " + score.ToString();
            codex.Text = currentw;
        }

        DispatcherTimer dt = new DispatcherTimer();
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += Page_PreviewKeyDown;
            this.Focusable = true;
            this.Focus();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }
        private void dtTicker(object sender, EventArgs e)
        {
            i--;
            time.Content = "Time left: " + i.ToString();
            if (i == 0)
            {
                Village.naruto.expquickness = Village.naruto.expquickness + score / 4;
                Village.naruto.explevel = Village.naruto.explevel + score / 100;
                Village.naruto.energy = Village.naruto.energy - hours * 5 + Village.naruto.vitality / 2 ;
                Village.naruto.happiness = Village.naruto.happiness - hours * 10;
                Village.datetime = Village.datetime.AddHours(hours);
                trainingdone.Navigate(new Training_done("Quickness training", score));
                dt.Stop();
            }
        }
        KeyConverter k = new KeyConverter();
        void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string str = k.ConvertToString(e.Key);
            if (str == currentw[currentind].ToString())
            {
                if(currentind + 1 == currentw.Length)
                {
                    currentind = 0;
                    score = score + currentw.Length;
                    rndid = rnd.Next(0, linecounter);
                    while (usedid.Contains(rndid))
                    {
                        rndid = rnd.Next(0, linecounter);
                    }
                    if (!usedid.Contains(rndid))
                    {
                        usedid.Add(rndid);
                    }
                    currentw = codes[rndid];
                    scorelabel.Content = "Score: " + score.ToString();
                    codex.Text = currentw;
                    codexpos.PositionStart = 0; 
                }
                else
                {                  
                    currentind++;                  
                    codex.Text = currentw;
                    codexpos.PositionStart++;
                }             
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
        }
    }
}
