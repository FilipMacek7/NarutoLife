using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoLife
{
    public class Character
    {
        //level stats
        public int LimitToRange(int value, int inclusiveMinimum, int inclusiveMaximum)
        {
            if (value < inclusiveMinimum) { return inclusiveMinimum; }
            if (value > inclusiveMaximum) { return inclusiveMaximum; }
            return value;
        }
        public int level { get; set; }
        double _num = 0;
        public double explevel
        {
            get
            {
                return _num;
            }
            set
            {
                if (value > 100)
                {
                    level++;
                    return;
                }
                _num = value;
            }
        }
        //main stats
        public int health
        {
            get
            {
                return maxhealth;
            }
            set
            {
                if (health > maxhealth)
                {
                    return;
                }
                maxhealth = value;
            }
        }
        public int chakra
        {
            get
            {
                return maxchakra;
            }
            set
            {
                if (health > maxchakra)
                {
                    return;
                }
                maxchakra = value;
            }
        }
        public int happiness
        {
            get
            {
                return maxhappiness;
            }
            set
            {
                if (happiness > maxhappiness)
                {
                    return;
                }
                maxhappiness = value;
            }
        }
        public double energy
        {
            get
            {
                return maxenergy;
            }
            set
            {
                if (energy > maxenergy)
                {
                    return;
                }
                maxenergy = value;
            }
        }
        public int yen { get; set; }

        //max main stats
        public int maxhealth { get; set; }
        public int maxchakra { get; set; }
        public int maxhappiness { get; set; }
        public double maxenergy { get; set; }

        //battle stats
        public int taijutsu { get; set; }
        public int quickness { get; set; }
        public int vitality { get; set; }
        public int accuracy { get; set; }

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
