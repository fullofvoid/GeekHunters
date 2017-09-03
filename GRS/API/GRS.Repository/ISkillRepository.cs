using GRS.DataAccess.Models;
using System.Collections.Generic;

namespace GRS.Repository
{
    public interface ISkillRepository
    {
        IList<Skill> GetAllSkills();
    }
}