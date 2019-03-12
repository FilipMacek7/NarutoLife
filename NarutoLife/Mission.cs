using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoLife
{
    public class Mission
    {
        public string name { get; set; }
        public string description { get; set; }
        public int enemycount { get; set; }
        public missionType type { get; set; }

        public Mission(string Name, string Description,int Enemycount, missionType Type)
        {
            name = Name;
            description = Description;
            type = Type;
            enemycount = Enemycount;
        }
    }
    public enum missionType
    {
        Fight,
        Minigame,
        Story,
    }
}
