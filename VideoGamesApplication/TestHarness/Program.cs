using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDAL;
using VideoGamesDAL.Models;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            //    List<ESRB> esrb = ESRBManager.GetESRBList();
            //    foreach (ESRB c in esrb)
            //    {
            //        Console.WriteLine(c.Rating);
            //    }

            //}
            Console.Write("Enter a DeveloperID: ");
            string DeveloperID = Console.ReadLine();

            Developer c = DeveloperManager.GetDeveloper(int.Parse(DeveloperID));
            if (c != null)
            {
                Console.WriteLine(c.Name);
            }
            else
            {
                Console.WriteLine("Developer ID not Found");
            }

        }
    }
}

