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
                    Console.WriteLine(m.name + " - " + m.description + " - " + m.level);
                }
                Console.WriteLine("");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Description: ");
                string description = Console.ReadLine();
                Console.WriteLine("Level: ");
                int num;
                while(!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Level has to be a number");
                }
                int level = num;
                Mission mission = new Mission(name, description, level);
                missions.Add(mission);
                File.WriteAllText(@"missions.json", JsonConvert.SerializeObject(missions));
                Console.Clear();
                Console.WriteLine("Mission " + mission.name + " has been saved succefuly to json.");
                
            }
            Console.ReadLine();
        }
    }
}
