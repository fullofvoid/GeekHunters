namespace GRS.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class CandidateEntities : DbContext, ICandidateEntities
    {
        public CandidateEntities()
            : base("name=CandidateModel")
        {
        }

        public virtual IDbSet<Candidate> Candidates { get; set; }
        public virtual IDbSet<CandidateSkill> CandidateSkills { get; set; }
        public virtual IDbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
