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
            if (value < inclusiveMinimum) { return 0; }
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
        public int health { get; set; }
        public int chakra { get; set; }
        public int happiness { get; set; }
        public int energy { get; set; }
        public int yen { get; set; }

        //max main stats
        public int maxhealth { get; set; }
        public int maxchakra { get; set; }
        public int maxhappiness { get; set; }
        public int maxenergy { get; set; }

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
