using NarutoLife.model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Training_done.xaml
    /// </summary>
    public partial class Training_done : Page
    {
        public Training_done(string Trainingname, int score)
        {
            InitializeComponent();
            trainingname.Content = Trainingname;
            endscore.Content = "Score: " + score.ToString();
            endexp.Content = "Exp: " + Village.naruto.expaccuracy.ToString() + " + " + (score / 4).ToString() + "%";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Village.mainframe.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
        }
    }
}
