using GRS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GRS.DataAccess
{
    public interface ICandidateEntities: IDisposable
    {

        IDbSet<Candidate> Candidates { get; set; }
        IDbSet<CandidateSkill> CandidateSkills { get; set; }
        IDbSet<Skill> Skills { get; set; }

        int SaveChanges();
    }
}