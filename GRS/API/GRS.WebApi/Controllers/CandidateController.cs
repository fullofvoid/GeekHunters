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
        // GET: api/Candidate
        public GetCandidatesViewModel Get()
        {
            return new CandidateServices().GetAll();
        }

        public CandidateDetailViewModel Get(int id)
        {
            return new CandidateServices().GetDetail(id);
        }

        // GET: api/SkillSearch/5
        [Route("api/Candidate/GetBySkill/{skillId}")]
        public GetCandidatesBySkillViewModel GetBySkill(int skillId)
        {
            return new CandidateServices().GetBySkill(skillId);
        }
        // POST: api/Candidate
        public void Post([FromBody]CandidateDetailViewModel value)
        {
            new CandidateServices().Save(value);
        }

        // PUT: api/Candidate
        public void Put([FromBody]CandidateDetailViewModel value)
        {
            new CandidateServices().New(value);
        }

        // DELETE: api/Candidate/5
        public void Delete(int id)
        {
            new CandidateServices().DeleteCandidate(id);
        }
    }
}
