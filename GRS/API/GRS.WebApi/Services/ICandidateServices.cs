using GRS.WebApi.Models;

namespace GRS.WebApi.Services
{
    public interface ICandidateServices
    {
        GetCandidatesViewModel GetAll();
        CandidateDetailViewModel GetDetail(int id);
        void DeleteCandidate(int id);
        void Insert(CandidateDetailViewModel value);
        void Update(CandidateDetailViewModel value);
        GetCandidatesBySkillViewModel GetBySkill(long skillId);
    }
}