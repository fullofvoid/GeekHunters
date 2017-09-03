using GRS.DataAccess;
using GRS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRS.Repository
{
    public class SkillRepository : ISkillRepository
    {
        public SkillRepository() { }

        public IList<Skill> GetAllSkills()
        {
            using (var context = new CandidateEntities())
            {
                return context.Skills.ToList();
            }
        }
    }
}
