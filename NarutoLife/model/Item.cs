using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoLife.model
{
    public class Item
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public int Number { get; set; }
        public bool Consumable { get; set; }
        bool stackable { get; set; }
        public int Xinv = 0;
        public int Yinv = 1;
        public Item(string name,string tag, int number, bool consumable, bool Stackable)
        {
            Name = name;
            Tag = tag;
            Number = number;
            Consumable = consumable;
            stackable = Stackable;
        }
    }
}
