using GRS.WebApi.Models;
using GRS.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GRS.WebApi.Controllers
{
    public class CandidateController : ApiController
    {
        private ICandidateServices _candidateService;

        public CandidateController(ICandidateServices candidateService)
        {
            _candidateService = candidateService;
        }

        // GET: api/Candidate
        public GetCandidatesViewModel Get()
        {
            return _candidateService.GetAll();
        }

        public CandidateDetailViewModel Get(int id)
        {
            return _candidateService.GetDetail(id);
        }

        // GET: api/SkillSearch/5
        [Route("api/Candidate/GetBySkill/{skillId}")]
        public GetCandidatesBySkillViewModel GetBySkill(int skillId)
        {
            return _candidateService.GetBySkill(skillId);
        }
        // POST: api/Candidate
        public void Post([FromBody]CandidateDetailViewModel value)
        {
            _candidateService.Update(value);
        }

        // PUT: api/Candidate
        public void Put([FromBody]CandidateDetailViewModel value)
        {
            _candidateService.Insert(value);
        }

        // DELETE: api/Candidate/5
        public void Delete(int id)
        {
            _candidateService.DeleteCandidate(id);
        }
    }
}
