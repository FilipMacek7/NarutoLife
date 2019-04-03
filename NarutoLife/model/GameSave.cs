using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoLife.model
{
    public class GameSave
    {
        public int id;
        public string name;
        public Character naruto;
        public DateTime datetime;

        public GameSave(int ID,string Name,Character Naruto, DateTime Datetime)
        {
            id = ID;
            name = Name;
            naruto = Naruto;
            datetime = Datetime;
        }
    }
}
