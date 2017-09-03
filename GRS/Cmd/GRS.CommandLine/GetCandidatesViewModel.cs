using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRS.CommandLine
{
    public class GetCandidatesViewModel
    {
        public IEnumerable<SkillViewModel> Skills { get; set; }
        public IEnumerable<CandidateViewModel> Candidates { get; set; }
    }

    public class GetCandidatesBySkillViewModel
    {
        public IEnumerable<CandidateViewModel> Candidates { get; set; }
    }

    public class SkillViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class CandidateViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class CandidateDetailViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<long> Skills { get; set; }
    }
}
