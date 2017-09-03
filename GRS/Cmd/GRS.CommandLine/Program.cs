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

            HttpClientHelper clientHelper = new HttpClientHelper();
            var candidateData = clientHelper.Get<GetCandidatesViewModel>("/Candidate");
            ShowAllSkill(candidateData);

            ShowAllCandidates(candidateData);

            DemoFiltering(clientHelper);

            Console.WriteLine("Press Any Key to exit.");
            Console.ReadLine();
        }

        private static void ShowAllSkill(GetCandidatesViewModel candidateData)
        {
            Console.WriteLine();
            Console.WriteLine("Available Skills");
            foreach (var skill in candidateData.Skills)
            {

                Console.WriteLine($"Id:{skill.Id}, Name:{skill.Name}");
            }
        }

        private static void ShowAllCandidates(GetCandidatesViewModel candidateData)
        {
            Console.WriteLine();
            Console.WriteLine("All the candidates..");
            foreach (var candidate in candidateData.Candidates)
            {
                Console.WriteLine($"Id:{candidate.Id}, First name:{candidate.FirstName}, Last Name:{candidate.LastName}");
            }
        }

        private static void DemoFiltering(HttpClientHelper clientHelper)
        {
            Console.WriteLine();
            Console.WriteLine("Please Enter a skill id to filter the candidates");
            string keysString = Console.ReadLine();
            long keyNumber;
            if (long.TryParse(keysString, out keyNumber))
            {
                var filterdCandidates = clientHelper.Get<GetCandidatesBySkillViewModel>($"/Candidate/GetBySkill/{keyNumber}");
                foreach (var candidate in filterdCandidates.Candidates)
                {
                    Console.WriteLine($"Id:{candidate.Id}, First name:{candidate.FirstName}, Last Name:{candidate.LastName}");
                }
            }
        }
    }
}
