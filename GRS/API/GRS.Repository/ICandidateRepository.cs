using GRS.DataAccess.Models;
using System.Collections.Generic;

namespace GRS.Repository
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetAllCandidates();
        IEnumerable<Skill> GetAllSkills();
        Candidate GetCandidate(long id);
        IEnumerable<Candidate> GetCandidateBySkill(long skillId);
        IEnumerable<long> GetCandidateSkills(long candidateId);
        void UpdateCandidate(long id, string firstName, string lastName, IEnumerable<long> skills);
        void Insert(string firstName, string lastName, IEnumerable<long> skills);
        void Delete(int id);
    }
}