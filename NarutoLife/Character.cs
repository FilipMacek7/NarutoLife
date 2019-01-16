using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoLife
{
    class Character
    {
        //main stats
        public int health { get; set; }
        public int chakra { get; set; }
        public int happiness { get; set; }
        public double energy { get; set; }
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
        public double btaijutsu { get; set; }
        public double bquickness { get; set; }
        public double bvitality { get; set; }
        public double baccuracy { get; set; }
    }
}
