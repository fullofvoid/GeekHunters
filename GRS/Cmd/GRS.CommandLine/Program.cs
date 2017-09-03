using GRS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRS.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Geek Registration System (GRS)");

            var rep = new CandidateRepository();
            //rep.AddNewCandidate("Luke", "Skywalker");
            //rep.AssignSkillsToCandidate(7, 1);
            foreach (var candidate in rep.SearchCandidateBySkill("SQL"))
            {
                Console.WriteLine($"Id:{candidate.Id}, First name:{candidate.FirstName}, Last Name:{candidate.LastName}");
            }

            Console.ReadLine();
        }
    }
}
