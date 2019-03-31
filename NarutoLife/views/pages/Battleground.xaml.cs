using NarutoLife.model;
using NarutoLife.views.frames;
using NarutoLife.views.pages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;
namespace NarutoLife
{
    /// <summary>
    /// Interakční logika pro Battleground.xaml
    /// </summary>
    /// 
    public partial class Battleground : Page
    {
        DispatcherTimer game = new DispatcherTimer();
        DispatcherTimer timer = new DispatcherTimer();
        bool playerturn = false;
        bool enemyturn = false;
        static Uri uri;
        Random rnd = new Random();
        int playerdodgepoint;
        static Frame Profile;
        static Frame inv;
        static Frame st;
        static ProgressBar Enemyhealthbar;
        static ProgressBar Enemychakrabar;
        static ProgressBar Enemycombatbar;
        static TextBlock Enemyhealthtext;
        static TextBlock Enemychakratext;
        static TextBlock Enemycombattext;
        static ProgressBar Healthbar;
        static ProgressBar Chakrabar;
        static ProgressBar Combatbar;
        static TextBlock Healthtext;
        static TextBlock Chakratext;
        static TextBlock Combattext;
        public Battleground()
        {
            InitializeComponent();
            Enemyhealthbar = enemyhealthbar;
            Enemychakrabar = enemychakrabar;
            Enemycombatbar = enemycombatbar;
            Enemyhealthtext = enemyhealthtext;
            Enemychakratext = enemychakratext;
            Enemycombattext = enemycombattext;
            Healthbar = healthbar;
            Chakrabar = chakrabar;
            Combatbar = combatbar;
            Healthtext = healthtext;
            Chakratext = chakratext;
            Combattext = combattext;
            enemyt.Source = new BitmapImage(new Uri(@"../../img/" + PreBattleground.currentEnemy.name + "_stand.gif", UriKind.Relative));
            st = settings;
            Profile = profile;
            game.Interval = TimeSpan.FromSeconds(1);
            game.Tick += gameTicker;
            game.Start();
            uri = new Uri(@"../../img/" + PreBattleground.currentEnemy.name+"_fightimg.png", UriKind.Relative);
            var image2 = new BitmapImage();
            image2.BeginInit();
            image2.UriSource = new Uri(@"/img/" + PreBattleground.currentEnemy.name + "_stand.gif", UriKind.Relative);
            image2.EndInit();
            ImageBehavior.SetAnimatedSource(enemyimg, image2);
            BitmapImage image = new BitmapImage(uri);
            enemyfightimg.Source = image;
            enemyinfotext.Text = PreBattleground.currentEnemy.name + " LV " + PreBattleground.currentEnemy.level + "\n Damage: "+ PreBattleground.currentEnemy.mindamage.ToString() + "-" + PreBattleground.currentEnemy.maxdamage.ToString() + "\n Quickness: " + PreBattleground.currentEnemy.quickness.ToString() + "\n Accuracy: " + PreBattleground.currentEnemy.accuracy.ToString() + "\n Vitality: " + PreBattleground.currentEnemy.vitality.ToString();
            playerdodgepoint = Village.naruto.quickness;
            updateStats();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += timerTicker;
            crouchtimer.Interval = TimeSpan.FromSeconds(1);
            crouchtimer.Tick += crouchTicker;
            Profile.Navigate(new ProfilePanel("Battleground"));
            inv = inventory;
            listpanel.Navigate(new ListPanel("Battleground"));
            st.Navigate(new Settings("Battleground"));
            inv.Navigate(new Inventory("Battleground"));
        }
        int y = 0;
        DispatcherTimer crouchtimer = new DispatcherTimer();
        void crouchTicker(object sender2, EventArgs e2)
        {
            y++;
            if (y == 1)
            {
                var image2 = new BitmapImage();
                image2.BeginInit();
                image2.UriSource = new Uri(@"../../img/naruto_stand.gif", UriKind.Relative);
                image2.EndInit();
                ImageBehavior.SetAnimatedSource(narutoimg, image2);
                crouchtimer.Stop();
                y = 0;
            }

        }
        void Page_Unloaded(object sender, EventArgs e)
        {
            game.Stop();
            timer.Stop();
        }
        int i = 0;
        void gameTicker(object sender, EventArgs e)
        {
            if(PreBattleground.currentEnemy.health <= 0)
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"../../img/"+ PreBattleground.currentEnemy.name+"_faint.gif", UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(enemyimg, image);
                ImageBehavior.SetRepeatBehavior(enemyimg, new RepeatBehavior(1));
                game.Stop();
                timer.Stop();
                PreBattleground.currentEnemy.health = 0;
                continuebutton.Visibility = Visibility.Visible;
            }
            else if(Village.naruto.health <= 0)
            {
                Village.naruto.happiness -= 30;
                Village.naruto.yen -= 100;
                Village.datetime = Village.datetime.AddMinutes(PreBattleground.movescount * 2 + 30);
                Village.naruto.energy -= (int)(((PreBattleground.movescount * 2 + 30) / 1080) * 100);
                Village.mainframe.Navigate(new Village(Village.datetime, Village.naruto, Village.mainframe));
                game.Stop();
                timer.Stop();
            }
            if (!playerturn & !enemyturn)
            {
                timer.Start();
            }

            if (playerturn == true & i == 0)
            {
                PreBattleground.movescount++;
                i++;
                Fightbuttons.Visibility = Visibility.Visible;
            }
            if (enemyturn == true & i == 0)
            {
                i++;
                PreBattleground.movescount++;
                if (playerdodge)
                {
                    Village.naruto.combat += 1;
                    plusminusplayer.Foreground = Brushes.Silver;
                    plusminusplayer.Content = "Dodge";
                    plusminusplayer.Visibility = Visibility.Visible;
                    Canvas.SetLeft(enemyimg, 150);
                    var image2 = new BitmapImage();
                    image2.BeginInit();
                    int rnddodge = rnd.Next(1, 3);
                    switch (rnddodge){
                        case 1:
                            image2.UriSource = new Uri(@"../../img/naruto_crouch.gif", UriKind.Relative);
                            crouchtimer.Start();                           
                            break;
                        case 2:
                            narutoimg.Height = 246;
                            Canvas.SetTop(narutoimg, -96);
                            image2.UriSource = new Uri(@"../../img/naruto_jump.gif", UriKind.Relative);
                            break;
                    }
                    image2.EndInit();
                    ImageBehavior.SetAnimatedSource(narutoimg, image2);
                    ImageBehavior.SetRepeatBehavior(narutoimg, new RepeatBehavior(1));
                }
                else
                {
                    int rnddmg = rnd.Next(PreBattleground.currentEnemy.mindamage, PreBattleground.currentEnemy.maxdamage + playercombatdamage);
                    Village.naruto.health -= rnddmg;
                    Village.naruto.combat += rnddmg/2;
                    playercombatdamage += rnddmg / 2;
                    if (PreBattleground.currentEnemy.combat == PreBattleground.currentEnemy.maxcombat)
                    {
                        PreBattleground.currentEnemy.combat = 0;
                        enemycombatdamage = 0;
                        updateStats();
                    }
                    updateStats();
                    plusminusplayer.Foreground = Brushes.Red;
                    plusminusplayer.Content = (-rnddmg).ToString();
                    plusminusplayer.Visibility = Visibility.Visible;
                    Canvas.SetLeft(enemyimg, 150);
                }
                enemyturn = false;
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"/img/" + PreBattleground.currentEnemy.name + "_attack.gif", UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(enemyimg, image);
                ImageBehavior.SetRepeatBehavior(enemyimg, new RepeatBehavior(2));
            }
        }
        int playercombatdamage;
        void timerTicker(object sender2, EventArgs e2)
        {
            i = 0;
            if (Canvas.GetLeft(narutot) >= 235)
            {
                timer.Stop();
                playerturn = true;
                enemyturn = false;
            }
            else if (Canvas.GetLeft(enemyt) >= 235)
            {
                timer.Stop();
                playerturn = false;
                enemyturn = true;
            }
            Canvas.SetLeft(narutot, Canvas.GetLeft(narutot) + Village.naruto.quickness + Village.naruto.combat);
            Canvas.SetLeft(enemyt, Canvas.GetLeft(enemyt) + PreBattleground.currentEnemy.quickness + PreBattleground.currentEnemy.combat);
        }
        public static void updateStats()
        {
            decimal edecimalhealthbar = (decimal)PreBattleground.currentEnemy.health / (decimal)PreBattleground.currentEnemy.maxhealth * 100;
            Enemyhealthbar.Value = (int)edecimalhealthbar;
            decimal edecimalchakrabar = (decimal)PreBattleground.currentEnemy.chakra / (decimal)PreBattleground.currentEnemy.maxchakra * 100;
            Enemychakrabar.Value = (int)edecimalchakrabar;
            decimal edecimalcombatbar = (decimal)PreBattleground.currentEnemy.combat / (decimal)PreBattleground.currentEnemy.maxcombat * 100;
            Enemycombatbar.Value = (int)edecimalcombatbar;
            PreBattleground.currentEnemy.health = PreBattleground.currentEnemy.LimitToRange(PreBattleground.currentEnemy.health, 0, (int)PreBattleground.currentEnemy.maxhealth);
            PreBattleground.currentEnemy.chakra = PreBattleground.currentEnemy.LimitToRange(PreBattleground.currentEnemy.chakra, 0,(int)PreBattleground.currentEnemy.maxchakra);
            PreBattleground.currentEnemy.combat = PreBattleground.currentEnemy.LimitToRange(PreBattleground.currentEnemy.combat, 0, PreBattleground.currentEnemy.maxcombat);
            Enemyhealthtext.Text = PreBattleground.currentEnemy.health + "/" + (int)PreBattleground.currentEnemy.maxhealth;
            Enemychakratext.Text = PreBattleground.currentEnemy.chakra + "/" + (int)PreBattleground.currentEnemy.maxchakra;
            Enemycombattext.Text = (int)PreBattleground.currentEnemy.combat + "/" + PreBattleground.currentEnemy.maxcombat;

            decimal decimalhealthbar = (decimal)Village.naruto.health / (decimal)Village.naruto.maxhealth * 100;
            Healthbar.Value = (int)decimalhealthbar;
            decimal decimalchakrabar = (decimal)Village.naruto.chakra / (decimal)Village.naruto.maxchakra * 100;
            Chakrabar.Value = (int)decimalchakrabar;
            decimal decimalcombatbar = (decimal)Village.naruto.combat / (decimal)Village.naruto.maxcombat * 100;
            Combatbar.Value = (int)decimalcombatbar;
            Village.naruto.health = Village.naruto.LimitToRange(Village.naruto.health, 0, (int)Village.naruto.maxhealth);
            Village.naruto.chakra = Village.naruto.LimitToRange(Village.naruto.chakra, 0, (int)Village.naruto.maxchakra);
            Village.naruto.combat = Village.naruto.LimitToRange(Village.naruto.combat, 0, Village.naruto.maxcombat);
            Healthtext.Text = (int)Village.naruto.health + "/" + (int)Village.naruto.maxhealth;
            Chakratext.Text = (int)Village.naruto.chakra + "/" + (int)Village.naruto.maxchakra;
            Combattext.Text = (int)Village.naruto.combat + "/" + (int)Village.naruto.maxcombat;
        }
        private void EnemyAnimationCompleted(object sender, RoutedEventArgs e)
        {
            if(PreBattleground.currentEnemy.health <= 0)
            {
                BitmapImage img = new BitmapImage(new Uri(@"/img/" + PreBattleground.currentEnemy.name + "_faintimg.png", UriKind.Relative));
                ImageBehavior.SetAnimatedSource(enemyimg, img);
            }
            else
            {
                plusminusplayer.Visibility = Visibility.Hidden;
                enemyturn = false;
                updateStats();
                Canvas.SetLeft(enemyt, 0);
                Canvas.SetLeft(enemyimg, 750);
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"/img/" + PreBattleground.currentEnemy.name + "_stand.gif", UriKind.Relative);
                image.EndInit();
                ImageBehavior.SetAnimatedSource(enemyimg, image);
                ImageBehavior.SetRepeatBehavior(enemyimg, RepeatBehavior.Forever);
            }
        }
        private void Naruto_AnimationCompleted(object sender, RoutedEventArgs e)
        {
            plusminusenemy.Visibility = Visibility.Hidden;
            Fightbuttons.Visibility = Visibility.Hidden;
            playerturn = false;
            updateStats();
            if (!playerdodge)
            {
                Canvas.SetLeft(narutot, -20);
            }
            playerdodge = false;
            Canvas.SetLeft(narutoimg, 70);
            Canvas.SetTop(narutoimg, 0);
            narutoimg.Height = 162;
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_stand.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(narutoimg, image);
            ImageBehavior.SetRepeatBehavior(narutoimg, RepeatBehavior.Forever);
        }
        int enemycombatdamage;
        private void Punch_Button(object sender, RoutedEventArgs e)
        {
            int rnddmg = rnd.Next(Village.naruto.mindamage, Village.naruto.taijutsu + Village.naruto.maxdamage +  playercombatdamage);
            PreBattleground.currentEnemy.health -= rnddmg;
            PreBattleground.currentEnemy.combat += rnddmg / 2;
            enemycombatdamage += rnddmg / 2;
            plusminusenemy.Foreground = Brushes.Red;
            plusminusenemy.Content = (-rnddmg).ToString();
            plusminusenemy.Visibility = Visibility.Visible;
            Fightbuttons.Visibility = Visibility.Hidden;
            if (Village.naruto.combat == Village.naruto.maxcombat)
            {
                Village.naruto.combat = 0;
                playercombatdamage = 0;
                updateStats();
            }
            Canvas.SetLeft(narutoimg, 650);
            updateStats();
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_punch.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(narutoimg, image);
            ImageBehavior.SetRepeatBehavior(narutoimg, new RepeatBehavior(3));
        }
        private void Chakra_Button(object sender, RoutedEventArgs e)
        {
            Fightbuttons.Visibility = Visibility.Hidden;
            playerturn = false;
            int rndpluschakra = rnd.Next(1, Village.naruto.chakracontrol + 2);
            Village.naruto.chakra += rndpluschakra;
            updateStats();
            plusminusplayer.Visibility = Visibility.Visible;
            plusminusplayer.Foreground = Brushes.LightBlue;
            plusminusplayer.Content = "+"+rndpluschakra;
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/img/naruto_chakracharge.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(narutoimg, image);
            ImageBehavior.SetRepeatBehavior(narutoimg, new RepeatBehavior(2));
        }

        private void Kunai_Button(object sender, RoutedEventArgs e)
        {
            Fightbuttons.Visibility = Visibility.Hidden;
            playerturn = false;

        }
        bool playerdodge = false;
        private void Dodge_Button(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(narutot, -20);
            Fightbuttons.Visibility = Visibility.Hidden;
            playerturn = false;
            if(Village.naruto.quickness + playerdodgepoint + Village.naruto.combat > PreBattleground.currentEnemy.quickness + PreBattleground.currentEnemy.accuracy / 2)
            {
                if(playerdodgepoint == 0)
                {
                    playerdodgepoint = Village.naruto.quickness;
                }
                playerdodgepoint--;
                playerdodge = true;
            }
            Canvas.SetLeft(narutot, -20);
        }

        private void Enemyprofile_Button(object sender, RoutedEventArgs e)
        {
            enemyinfo.Visibility = Visibility.Visible;
        }
        private void Enemyinfo_Close(object sender, RoutedEventArgs e)
        {
            enemyinfo.Visibility = Visibility.Hidden;
        }

        private void ContinueMission(object sender, RoutedEventArgs e)
        {
            Village.naruto.explevel += PreBattleground.currentEnemy.level * 10;
            PreBattleground.startMove();
            Village.mainframe.GoBack();
        }
        public static void Profile_On()
        {
            Profile.Visibility = Visibility.Visible;
        }
        public static void Profile_Off()
        {
            Profile.Visibility = Visibility.Hidden;
        }
        public static void Settings_Close()
        {
            st.Visibility = Visibility.Hidden;
        }
        public static void Settings_On()
        {
            st.Visibility = Visibility.Visible;
        }
        public static void Inventory_On()
        {
            inv.Visibility = Visibility.Visible;
        }
        public static void Inventory_Close()
        {
            inv.Visibility = Visibility.Hidden;
        }

        private void Profile_Button(object sender, RoutedEventArgs e)
        {
            Battleground.Profile_On();
        }
    }
}
