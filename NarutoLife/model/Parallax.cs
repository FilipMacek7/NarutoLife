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
        public static void BackgroundMove(Image a, Image b, Image c, Image d, Image f, Image a1, Image b1, Image c1, Image d1, Image f1, Rectangle jg, Image jg2, List<Image> Mobs, double speed)
        {
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
                Canvas.SetLeft(jg, Canvas.GetLeft(jg) - speed);
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
