using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSRForms.Models;

namespace GSRForms.View
{
    public interface ISearchCandidateView
    {
        long SelectedSkillId { get;}
        long SelectedCandidateId { get; }

        Action<object> SkillFilterChanged { get; set; }
        Action<object> Edit { get; set; }
        Action<object> New { get; set; }
        Action<object> Delete { get; set; }

        void ShowForm(GetCandidatesViewModel data);
        void ShowCandidates(IEnumerable<CandidateViewModel> allCandidates);
    }
}
