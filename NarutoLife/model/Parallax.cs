using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace NarutoLife
{
    class Parallax
    {
        static DispatcherTimer dt = new DispatcherTimer();
        static List<Image> mobs;
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
        public static void BackgroundMove(Image a, Image b, Image c, Image d, Image f, Image a1, Image b1, Image c1, Image d1, Image f1, Rectangle jg, Image jg2, List<Image> Mobs, double speed)
        {
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
            dt.Tick += dt_Tick;
            dt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dt.Start();

            void dt_Tick(object sender, EventArgs e)
            {
                Canvas.SetLeft(a, Canvas.GetLeft(a) - speed / 16);
                Canvas.SetLeft(b, Canvas.GetLeft(b) - speed / 8);
                Canvas.SetLeft(c, Canvas.GetLeft(c) - speed / 4);
                Canvas.SetLeft(d, Canvas.GetLeft(d) - speed / 2);
                Canvas.SetLeft(f, Canvas.GetLeft(f) - speed);
                Canvas.SetLeft(a1, Canvas.GetLeft(a1) - speed / 16);
                Canvas.SetLeft(b1, Canvas.GetLeft(b1) - speed / 8);
                Canvas.SetLeft(c1, Canvas.GetLeft(c1) - speed / 4);
                Canvas.SetLeft(d1, Canvas.GetLeft(d1) - speed / 2);
                Canvas.SetLeft(f1, Canvas.GetLeft(f1) - speed);
                Canvas.SetLeft(jg2, Canvas.GetLeft(jg2) - speed);
                foreach(Image m in mobs)
                {
                    Canvas.SetLeft(m, Canvas.GetLeft(m) - speed);
                }

                if (Canvas.GetLeft(a) < -a.ActualWidth)
                {
                    Canvas.SetLeft(a, Canvas.GetLeft(a1) + a1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(b) < -b.ActualWidth)
                {
                    Canvas.SetLeft(b, Canvas.GetLeft(b1) + b1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(c) < -c.ActualWidth)
                {
                    Canvas.SetLeft(c, Canvas.GetLeft(c1) + c1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(d) < -d.ActualWidth)
                {
                    Canvas.SetLeft(d, Canvas.GetLeft(d1) + d1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(f) < -f.ActualWidth)
                {
                    Canvas.SetLeft(f, Canvas.GetLeft(f1) + f1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(a1) < -a1.ActualWidth)
                {
                    Canvas.SetLeft(a1, Canvas.GetLeft(a) + a.ActualWidth - 2);
                }
                if (Canvas.GetLeft(b1) < -b1.ActualWidth)
                {
                    Canvas.SetLeft(b1, Canvas.GetLeft(b) + b.ActualWidth - 2);
                }
                if (Canvas.GetLeft(c1) < -c1.ActualWidth)
                {
                    Canvas.SetLeft(c1, Canvas.GetLeft(c) + c.ActualWidth - 2);
                }
                if (Canvas.GetLeft(d1) < -d1.ActualWidth)
                {
                    Canvas.SetLeft(d1, Canvas.GetLeft(d) + d.ActualWidth - 2);
                }
                if (Canvas.GetLeft(f1) < -f1.ActualWidth)
                {
                    Canvas.SetLeft(f1, Canvas.GetLeft(f) + f.ActualWidth - 2);
                }
                if (Canvas.GetLeft(jg) < -jg.ActualWidth)
                {
                    Canvas.SetLeft(jg, Canvas.GetLeft(jg2) + jg2.ActualWidth - 2);
                }
                if (Canvas.GetLeft(jg2) < -jg2.ActualWidth)
                {
                    Canvas.SetLeft(jg2, Canvas.GetLeft(jg) + jg.ActualWidth - 2);
                }
            }

        }
        static DispatcherTimer dt2 = new DispatcherTimer();
        public static void turnAround()
        {
            dt.Stop();
            bool turnaroundstart = true;
            bool turnaroundend = false;
            while (turnaroundstart)
            {
                turnaroundstart = false;
                turnaroundend = true;
                Canvas.SetLeft(Jg, Canvas.GetLeft(Jg) - Speed);
            }
            while (turnaroundend)
            {
                dt2.Tick += dt2_Tick;
                dt2.Interval = new TimeSpan(0, 0, 0, 0, 10);
                dt2.Start();

                void dt2_Tick(object sender, EventArgs e)
                {
                    Canvas.SetLeft(A, Canvas.GetLeft(A) + Speed / 16);
                    Canvas.SetLeft(B, Canvas.GetLeft(B) + Speed / 8);
                    Canvas.SetLeft(C, Canvas.GetLeft(C) + Speed / 4);
                    Canvas.SetLeft(D, Canvas.GetLeft(D) + Speed / 2);
                    Canvas.SetLeft(F, Canvas.GetLeft(F) + Speed);
                    Canvas.SetLeft(A1, Canvas.GetLeft(A1) + Speed / 16);
                    Canvas.SetLeft(B1, Canvas.GetLeft(B1) + Speed / 8);
                    Canvas.SetLeft(C1, Canvas.GetLeft(C1) + Speed / 4);
                    Canvas.SetLeft(D1, Canvas.GetLeft(D1) + Speed / 2);
                    Canvas.SetLeft(F1, Canvas.GetLeft(F1) + Speed);
                    Canvas.SetLeft(Jg, Canvas.GetLeft(Jg) + Speed);
                    Canvas.SetLeft(Jg2, Canvas.GetLeft(Jg2) + Speed);
                    if(Canvas.GetLeft(Jg) == 400)
                    {
                        turnaroundend = false;
                        dt2.Stop();
                    }
                    foreach (Image m in mobs)
                    {
                        Canvas.SetLeft(m, Canvas.GetLeft(m) + Speed);
                    }

                    if (Canvas.GetLeft(A) < -A.ActualWidth)
                    {
                        Canvas.SetLeft(A, Canvas.GetLeft(A1) - A1.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(B) < -B.ActualWidth)
                    {
                        Canvas.SetLeft(B, Canvas.GetLeft(B1) - B1.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(C) < -C.ActualWidth)
                    {
                        Canvas.SetLeft(C, Canvas.GetLeft(C1) - C1.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(D) < -D.ActualWidth)
                    {
                        Canvas.SetLeft(D, Canvas.GetLeft(D1) - D1.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(F) < -F.ActualWidth)
                    {
                        Canvas.SetLeft(F, Canvas.GetLeft(F1) - F1.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(A1) < -A1.ActualWidth)
                    {
                        Canvas.SetLeft(A1, Canvas.GetLeft(A) - A.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(B1) < -B1.ActualWidth)
                    {
                        Canvas.SetLeft(B1, Canvas.GetLeft(B) - B.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(C1) < -C1.ActualWidth)
                    {
                        Canvas.SetLeft(C1, Canvas.GetLeft(C) - C.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(D1) < -D1.ActualWidth)
                    {
                        Canvas.SetLeft(D1, Canvas.GetLeft(D) - D.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(F1) < -F1.ActualWidth)
                    {
                        Canvas.SetLeft(F1, Canvas.GetLeft(F) - F.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(Jg) < -Jg.ActualWidth)
                    {
                        Canvas.SetLeft(Jg, Canvas.GetLeft(Jg2) - Jg2.ActualWidth + 2);
                    }
                    if (Canvas.GetLeft(Jg2) < -Jg2.ActualWidth)
                    {
                        Canvas.SetLeft(Jg2, Canvas.GetLeft(Jg) - Jg.ActualWidth + 2);
                    }
                }
            }
    }
        public static void parallaxStart()
        {
            dt.Start();
        }
        public static void parallaxStop()
        {
            dt.Stop();
        }
    }
}
