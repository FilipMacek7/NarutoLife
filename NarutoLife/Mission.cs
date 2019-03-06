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
        public int level { get; set; }

        public Mission(string Name, string Description, int Level)
        {
            name = Name;
            description = Description;
            level = Level;
        }
    }
}
