using GRS.Repository;
using GRS.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRS.WebApi.Services
{
    public class CandidateServices
    {

        public GetCandidatesViewModel GetAll()
        {
            ISkillRepository repo = new SkillRepository();
            var skillViewModelList = repo.GetAllSkills().Select(
                x=> new SkillViewModel() {Id = x.Id, Name = x.Name  });

            ICandidateRepository repo2 = new CandidateRepository();
            var candidateViewModelList = repo2.GetAllCandidates().Select(
                x => new CandidateViewModel() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName });

            return new GetCandidatesViewModel() {
                Skills = skillViewModelList,
                Candidates = candidateViewModelList
            };
        }

        public CandidateDetailViewModel GetDetail(int id)
        {
            ICandidateRepository repo = new CandidateRepository();
            var skills = repo.GetCandidateSkills(id);
            var candidate = repo.GetCandidate(id);
            return new CandidateDetailViewModel()
            {
                Id = id,
                Skills = skills,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName
            };

        }

        public void DeleteCandidate(int id)
        {
            ICandidateRepository repository = new CandidateRepository();
            repository.Delete(id);
        }

        public void New(CandidateDetailViewModel value)
        {
            ICandidateRepository repository = new CandidateRepository();
            repository.Insert(value.FirstName, value.LastName, value.Skills);
        }

        public void Save(CandidateDetailViewModel value)
        {
            ICandidateRepository repository = new CandidateRepository();
            repository.UpdateCandidate(value.Id, value.FirstName, value.LastName, value.Skills);
        }

        public GetCandidatesBySkillViewModel GetBySkill(long skillId)
        {
            ICandidateRepository repository = new CandidateRepository();
            var candidateViewModelList = repository.GetCandidateBySkill(skillId).Select(
                x => new CandidateViewModel() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName });

            return new GetCandidatesBySkillViewModel()
            {
                Candidates = candidateViewModelList
            };
        }
    }
}