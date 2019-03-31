using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoLife
{
    public abstract class Mob
    {
        //level stats
        public int LimitToRange(int value, int inclusiveMinimum, int inclusiveMaximum)
        {
            if (value < inclusiveMinimum) { return inclusiveMinimum; }
            if (value > inclusiveMaximum) { return inclusiveMaximum; }
            return value;
        }

        public int quickness = 1;
        public int vitality = 1;
        public int accuracy = 1;
        public int chakracontrol = 1;
        public int combat = 0;
        public int level { get; set; }
        //main stats
        public int health { get; set; }
        public int chakra { get; set; }

        //max main stats
        public double maxhealth { get; set; } 
        public double maxchakra { get; set; }
        public int maxcombat = 5;
        public int mindamage { get; set; }
        public int maxdamage { get; set; }
    }
}
