using GRS.DataAccess.Models;
using System;
using System.Data.Entity;

namespace GRS.DataAccess
{
    public interface ICandidateEntities: IDisposable
    {

        DbSet<Candidate> Candidates { get; set; }
        DbSet<CandidateSkill> CandidateSkills { get; set; }
        DbSet<Skill> Skills { get; set; }

        int SaveChanges();
    }
}