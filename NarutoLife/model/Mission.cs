using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoLife
{
    public class Mission
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int numberOfEnemy { get; set; }
        public missionType type { get; set; }
        public int reward { get; set; }

        public Mission(int ID,string Name,string Description,int NumberOfEnemy,int Reward, missionType Type)
        {
            id = ID;
            name = Name;
            description = Description;
            numberOfEnemy = NumberOfEnemy;
            type = Type;
            reward = Reward;
        }
    }
    public enum missionType
    {
        Fight,
        Minigame,
        Story,
    }
}
