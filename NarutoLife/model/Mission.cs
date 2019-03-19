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
        public missionType type { get; set; }

        public Mission(string Name, missionType Type)
        {
            name = Name;
            type = Type;
        }
    }
    public enum missionType
    {
        Fight,
        Minigame,
        Story,
    }
}
