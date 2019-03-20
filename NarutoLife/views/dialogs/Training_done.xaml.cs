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
        DateTime datetime;
        Character naruto;
        Frame mainframe;
        public Training_done(DateTime Datetime, Character Naruto, Frame Mainframe,string Trainingname, int score)
        {
            InitializeComponent();
            datetime = Datetime;
            naruto = Naruto;
            mainframe = Mainframe;
            trainingname.Content = Trainingname;
            endscore.Content = "Score: " + score.ToString();
            endexp.Content = "Exp: " + naruto.expaccuracy.ToString() + " + " + (score / 4).ToString() + "%";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Village(datetime, naruto, mainframe));
        }
    }
}
