using NarutoLife.views.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace NarutoLife
{
    class Parallax
    {
        static DispatcherTimer dt = new DispatcherTimer();
        static List<Image> mobs;
        static Image naruto;
        static Rectangle narutocursed;
        static Image A;
        static Image B;
        static Image C;
        static Image D;
        static Image F;
        static Image A1;
        static Image B1;
        static Image C1;
        static Image D1;
        static Image F1;
        static Rectangle Jg;
        static Image Jg2;
        static double Speed;
        //362,638
        static DispatcherTimer bar = new DispatcherTimer();

        public Parallax(Image Naruto, Rectangle Narutocursed, Image a, Image b, Image c, Image d, Image f, Image a1, Image b1, Image c1, Image d1, Image f1,Rectangle jg, Image jg2, List<Image> Mobs, double speed)
        {
            naruto = Naruto;
            narutocursed = Narutocursed;
            A = a;
            B = b;
            C = c;
            D = d;
            F = f;
            A1 = a1;
            B1 = b1;
            C1 = c1;
            D1 = d1;
            F1 = f1;
            Jg = jg;
            Jg2 = jg2;
            Speed = speed;
            mobs = Mobs;
            BackgroundMove();
        }
        public void BackgroundMove()
        {
            bar.Tick += bar_Tick;
            bar.Interval = TimeSpan.FromMilliseconds(100);//100
            bar.Start();
            void bar_Tick(object sender3, EventArgs e3)
            {
                if (Canvas.GetLeft(narutocursed) > 638)
                {
                    PreBattleground.navigateVillage();
                }
                Canvas.SetLeft(narutocursed, Canvas.GetLeft(narutocursed) + Speed);
            }
            dt.Tick += dt_Tick;
            dt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dt.Start();

            void dt_Tick(object sender, EventArgs e)
            {
                Canvas.SetLeft(A, Canvas.GetLeft(A) - Speed / 16);
                Canvas.SetLeft(B, Canvas.GetLeft(B) - Speed / 8);
                Canvas.SetLeft(C, Canvas.GetLeft(C) - Speed / 4);
                Canvas.SetLeft(D, Canvas.GetLeft(D) - Speed / 2);
                Canvas.SetLeft(F, Canvas.GetLeft(F) - Speed);
                Canvas.SetLeft(A1, Canvas.GetLeft(A1) - Speed / 16);
                Canvas.SetLeft(B1, Canvas.GetLeft(B1) - Speed / 8);
                Canvas.SetLeft(C1, Canvas.GetLeft(C1) - Speed / 4);
                Canvas.SetLeft(D1, Canvas.GetLeft(D1) - Speed / 2);
                Canvas.SetLeft(F1, Canvas.GetLeft(F1) - Speed);
                Canvas.SetLeft(Jg, Canvas.GetLeft(Jg) - Speed);
                Canvas.SetLeft(Jg2, Canvas.GetLeft(Jg2) - Speed);
                foreach (Image m in mobs)
                {
                    Canvas.SetLeft(m, Canvas.GetLeft(m) - Speed);
                }

                if (Canvas.GetLeft(A) < -A.ActualWidth)
                {
                    Canvas.SetLeft(A, Canvas.GetLeft(A1) + A1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(B) < -B.ActualWidth)
                {
                    Canvas.SetLeft(B, Canvas.GetLeft(B1) + B1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(C) < -C.ActualWidth)
                {
                    Canvas.SetLeft(C, Canvas.GetLeft(C1) + C1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(D) < -D.ActualWidth)
                {
                    Canvas.SetLeft(D, Canvas.GetLeft(D1) + D1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(F) < -F.ActualWidth)
                {
                    Canvas.SetLeft(F, Canvas.GetLeft(F1) + F1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(A1) < -A1.ActualWidth)
                {
                    Canvas.SetLeft(A1, Canvas.GetLeft(A) + A.ActualWidth - 2);
                }
                if (Canvas.GetLeft(B1) < -B1.ActualWidth)
                {
                    Canvas.SetLeft(B1, Canvas.GetLeft(B) + B.ActualWidth - 2);
                }
                if (Canvas.GetLeft(C1) < -C1.ActualWidth)
                {
                    Canvas.SetLeft(C1, Canvas.GetLeft(C) + C.ActualWidth - 2);
                }
                if (Canvas.GetLeft(D1) < -D1.ActualWidth)
                {
                    Canvas.SetLeft(D1, Canvas.GetLeft(D) + D.ActualWidth - 2);
                }
                if (Canvas.GetLeft(F1) < -F1.ActualWidth)
                {
                    Canvas.SetLeft(F1, Canvas.GetLeft(F) + F.ActualWidth - 2);
                }
                if (Canvas.GetLeft(Jg) < -Jg.ActualWidth)
                {
                    Canvas.SetLeft(Jg, Canvas.GetLeft(Jg2) + Jg2.ActualWidth - 2);
                }
                if (Canvas.GetLeft(Jg2) < -Jg2.ActualWidth)
                {
                    Canvas.SetLeft(Jg2, Canvas.GetLeft(Jg) + Jg.ActualWidth - 2);
                }
            }

        }
        public static void parallaxStart()
        {
            dt.Start();
            bar.Start();        
        }
        public static void parallaxStop()
        {
            dt.Stop();
            bar.Stop();
        }
    }
}
