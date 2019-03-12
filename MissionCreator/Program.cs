using System;
using System.Collections.Generic;
using System.IO;
using NarutoLife;
using Newtonsoft.Json;

namespace MissionCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MissionCreator for NarutoLife");
            bool semafor = true;
            List<Mission> missions = new List<Mission>();
            if (File.Exists(@"missions.json"))
            {
                missions = JsonConvert.DeserializeObject<List<Mission>>(File.ReadAllText(@"missions.json"));
            }               

            while (semafor)
            {
                foreach(Mission m in missions)
                {
                    Console.WriteLine(m.name + " - " + m.description + " - " + m.type);
                }
                Console.WriteLine("");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Description: ");
                string description = Console.ReadLine();
                Console.WriteLine("How many enemies: ");
                int enemycount;
                string num = Console.ReadLine();
                if (int.TryParse(num, out enemycount))
                {
                    Console.WriteLine("Type: ");
                    string type = Console.ReadLine();
                    missionType mtype;
                    if (Enum.TryParse(type, out mtype))
                    {
                        Mission mission = new Mission(name, description, enemycount, mtype);
                        missions.Add(mission);
                        File.WriteAllText(@"missions.json", JsonConvert.SerializeObject(missions));
                        Console.Clear();
                        Console.WriteLine("Mission " + mission.name + " has been saved succefuly to json.");
                    }
                }
                        
            }
            Console.ReadLine();
        }
    }
}
