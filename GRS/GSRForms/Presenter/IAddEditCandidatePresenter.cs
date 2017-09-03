using System.Collections.Generic;
using GSRForms.Models;

namespace GSRForms.Presenter
{
    public interface IAddEditCandidatePresenter
    {
        void Show(IEnumerable<SkillViewModel> _allSkills, long candidateId);
        void Show(IEnumerable<SkillViewModel> _allSkills);
    }
}