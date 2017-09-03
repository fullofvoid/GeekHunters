using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSRForms.Models;

namespace GSRForms.View
{
    public interface IAddEditCandidateView
    {
        void Show(IEnumerable<SkillViewModel> allSkills, CandidateDetailViewModel candidateDetail);
        Action<object> Ok { get; set; }

        string GetFirstName();
        string GetLastName();
        IEnumerable<long> GetSelectedSkills();
        void Close();
    }
}
