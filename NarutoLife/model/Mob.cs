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
            if (value < inclusiveMinimum) { return 0; }
            if (value > inclusiveMaximum) { return inclusiveMaximum; }
            return value;
        }

        public int quickness { get; set; }
        public int vitality { get; set; }
        public int accuracy { get; set; }

        public int level { get; set; }
        //main stats
        public int health { get; set; }
        public int chakra { get; set; }

        //max main stats
        public int maxhealth { get; set; }
        public int maxchakra { get; set; }
    }
}
