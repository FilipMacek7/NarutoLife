using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoLife.model
{
     public class Character: Mob
    {
        public List<Item> inventory = new List<Item>();
        double _num = 0;
        public double explevel
        {
            get
            {
                return _num;
            }
            set
            {
                if (value > maxexplevel)
                {
                    maxexplevel += 100;
                    level++;
                    return;
                }
                _num = value;
            }
        }
        public double maxexplevel = 100;
        public int happiness { get; set; }
        public int energy { get; set; }
        public int yen { get; set; }

        public int maxhappiness { get; set; }
        public int maxenergy { get; set; }
        //battle stats
        public int taijutsu { get; set; }
        //exp frames
        public double exptaijutsu
        {
            get
            {
                return _num;
            }
            set
            {
                if (value > 100)
                {
                    taijutsu++;
                    return;
                }
                _num = value;
            }
        }
        public double expquickness
        {
            get
            {
                return _num;
            }
            set
            {
                if (value > 100)
                {
                    quickness++;
                    return;
                }
                _num = value;
            }
        }
        public double expchakra
        {
            get
            {
                return _num;
            }
            set
            {
                if (value > 100)
                {
                    maxchakra = maxchakra + 20;
                    chakracontrol++;
                    return;
                }
                _num = value;
            }
        }
        public double expaccuracy
        {
            get
            {
                return _num;
            }
            set
            {
                if (value > 100)
                {
                    accuracy++;
                    return;
                }
                _num = value;
            }
        }
    }
}
