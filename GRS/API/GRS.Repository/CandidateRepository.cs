using GRS.DataAccess;
using GRS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRS.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        public CandidateRepository() { }

        public IEnumerable<Candidate> GetAllCandidates()
        {
            using (var context = new CandidateEntities())
            {
                return context.Candidates.ToList();
            }
        }

        public IEnumerable<Candidate> GetCandidateBySkill(long skillId)
        {
            using (var context = new CandidateEntities())
            {
                var selectedCandidateSkills = context.CandidateSkills.Where(x => x.SkillId == skillId);
                var selectedCandidates = context.Candidates.Where(x => selectedCandidateSkills.Any(y => y.CandidateId == x.Id));
                return selectedCandidates.ToList();
            }
        }
        public void Delete(int id)
        {
            using (var context = new CandidateEntities())
            {
                var candidate = context.Candidates.First(x => x.Id == id);
                var candidateSkills = context.CandidateSkills.Where(x => x.CandidateId == id);

                RemoveOldSkills(context, candidateSkills, new long[0]);
                context.Candidates.Remove(candidate);
                context.SaveChanges();
            }
        }


        public void Insert(string firstName, string lastName, IEnumerable<long> skills)
        {
            using (var context = new CandidateEntities())
            {
                var candidate = new Candidate()
                {
                    FirstName = firstName,
                    LastName = lastName
                };
                context.Candidates.Add(candidate);
                context.SaveChanges();

                AddNewSkills(context, new List<CandidateSkill>(), candidate.Id, skills);
                context.SaveChanges();
            }
        }
        public void UpdateCandidate(long id, string firstName, string lastName, IEnumerable<long> skills)
        {
            using (var context = new CandidateEntities())
            {
                var candidate = context.Candidates.First(x => x.Id == id);
                candidate.FirstName = firstName;
                candidate.LastName = lastName;
                var candidateSkills = context.CandidateSkills.Where(x=> x.CandidateId == id);
                RemoveOldSkills(context, candidateSkills, skills);
                AddNewSkills(context, candidateSkills, id, skills);

                context.SaveChanges();
            }
            
        }

        private static void AddNewSkills(CandidateEntities context, IEnumerable<CandidateSkill> currentSkills, long candidateId, IEnumerable<long> newSkills)
        {
            foreach (var skillId in newSkills)
            {
                if (!currentSkills.Any(x => x.SkillId == skillId))
                {
                    context.CandidateSkills.Add(new CandidateSkill()
                    {
                        CandidateId = candidateId,
                        SkillId = skillId
                    });
                }
            }
        }

        private static void RemoveOldSkills(CandidateEntities context, IEnumerable<CandidateSkill> currentSkills, IEnumerable<long> newSkills)
        {
            foreach (var currentSkill in currentSkills)
            {
                if (!newSkills.Any(x => x == currentSkill.SkillId))
                {
                    context.CandidateSkills.Remove(currentSkill);
                }
            }
        }

        public IEnumerable<long> GetCandidateSkills(long candidateId)
        {
            using (var context = new CandidateEntities())
            {
                var candidateSkills = context.CandidateSkills.Where(x => x.CandidateId == candidateId).ToList();
                return candidateSkills.Select(x => x.SkillId);
            }
        }
        public Candidate GetCandidate(long id) {
            using (var context = new CandidateEntities())
            {
                var candidate = context.Candidates.FirstOrDefault(x => x.Id == id);
                return candidate;
            }
        }

    }
}
