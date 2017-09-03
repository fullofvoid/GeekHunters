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
        private ICandidateRepository _repository;

        public CandidateServices(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public GetCandidatesViewModel GetAll()
        {
            var skillViewModelList = _repository.GetAllSkills().Select(
                x=> new SkillViewModel() {Id = x.Id, Name = x.Name  });

            var candidateViewModelList = _repository.GetAllCandidates().Select(
                x => new CandidateViewModel() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName });

            return new GetCandidatesViewModel() {
                Skills = skillViewModelList,
                Candidates = candidateViewModelList
            };
        }
        
        public CandidateDetailViewModel GetDetail(int id)
        {
            var skills = _repository.GetCandidateSkills(id);
            var candidate = _repository.GetCandidate(id);
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
            _repository.Delete(id);

        }

        public void Insert(CandidateDetailViewModel value)
        {
            _repository.Insert(value.FirstName, value.LastName, value.Skills);
        }

        public void Update(CandidateDetailViewModel value)
        {
            _repository.UpdateCandidate(value.Id, value.FirstName, value.LastName, value.Skills);
        }

        public GetCandidatesBySkillViewModel GetBySkill(long skillId)
        {
            var candidateViewModelList = _repository.GetCandidateBySkill(skillId).Select(
                x => new CandidateViewModel() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName });

            return new GetCandidatesBySkillViewModel()
            {
                Candidates = candidateViewModelList
            };
        }
    }
}