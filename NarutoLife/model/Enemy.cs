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
        Random rnd = new Random();
        public double positionx { get; set; }
        public double positiony { get; set; }
        public Enemy(int ID,string Name, int playerlevel, double Positionx, double Positiony)
        {
            id = ID;
            name = Name;
            positionx = Positionx;
            positiony = Positiony;
            int randomlevel = rnd.Next(playerlevel - 3, playerlevel + 3);
            level = LimitToRange(randomlevel,1, playerlevel + 3);
            health = (int)maxhealth;
            chakra = (int)maxchakra;
            if (Name.Equals("wolf"))
            {
                vitality += 2;
                mindamage += 1;
                maxdamage += 2;
                quickness -= 1;
                accuracy -= 2;
            }
            else if (Name.Equals("spider"))
            {
                mindamage -= 2;
                maxdamage += 2;
                quickness += 2;
                accuracy += 1;
                vitality -= 1;
            }
            else if (Name.Equals("snake"))
            {
                maxdamage += 3;
                quickness += 1;
                accuracy += 1;
                mindamage -= 1;
                vitality -= 2;
            }
            maxhealth = rnd.Next(15,26) + vitality + (vitality / 1.5);
            health = (int)maxhealth;
            maxchakra = rnd.Next(5, 11 + chakracontrol + chakracontrol / 2);
            chakra = (int)maxchakra;
            mindamage = 1;
            maxdamage = 3;
            maxcombat += level;
            for (int i = 0; i < 10 + level * 4; i++)
            {
                int rndAddpoint = rnd.Next(1, 6);
                switch (rndAddpoint)
                {
                    case 1:
                        quickness++;
                        break;
                    case 2:
                        accuracy++;
                        break;
                    case 3:
                        mindamage++;
                        maxdamage++;
                        break;
                    case 4:
                        vitality++;
                        break;
                    case 5:
                        chakracontrol++;
                        break;
                }
            }
            quickness = LimitToRange(quickness, 1, quickness);
        }
    }
}
