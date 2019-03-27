using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoLife.model
{
    public class Enemy : Mob
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maxdamage { get; set; }
        Random rnd = new Random();
        public double positionx { get; set; }
        public double positiony { get; set; }
        public Enemy(int ID,string Name, int playerlevel, double Positionx, double Positiony)
        {
            id = ID;
            name = Name;
            positionx = Positionx;
            positiony = Positiony;
            level = rnd.Next(playerlevel - 5, playerlevel + 3);
            if(level < 5)
            {
                maxhealth = rnd.Next(15,26);
                maxchakra = rnd.Next(5, 11);
                quickness = rnd.Next(1, 4);
                accuracy = rnd.Next(1, 6);
                maxdamage = 7;
            }
        }
    }
}
