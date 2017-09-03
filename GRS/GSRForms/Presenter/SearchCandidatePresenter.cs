using GSRForms.Models;
using GSRForms.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSRForms.Presenter
{
    public class SearchCandidatePresenter : ISearchCandidatePresenter
    {
        private IEnumerable<CandidateViewModel> _allCandidates;
        private IEnumerable<SkillViewModel> _allSkills;

        public ISearchCandidateView View { get; private set; }
        public IAddEditCandidatePresenter EditCandidatePresenter { get; private set; }

        public SearchCandidatePresenter(ISearchCandidateView view, IAddEditCandidatePresenter editPresenter)
        {
            this.View = view;
            this.EditCandidatePresenter = editPresenter;
            _allCandidates = null;
        }

        public void Show()
        {
            HttpClientHelper clientHelper = new HttpClientHelper();
            var skillsData = clientHelper.Get<GetCandidatesViewModel>("/Candidate");
            var skillList = skillsData.Skills.ToList();
            _allSkills = new List<SkillViewModel>(skillList);
            skillList.Insert(0, new SkillViewModel() { Id = 0, Name = "All" });
            skillsData.Skills = skillList;
            _allCandidates = skillsData.Candidates;

            View.SkillFilterChanged = View_SkillFilterChanged;
            View.Edit = View_Edit;
            View.New = View_New;
            View.Delete= View_Delete;

            View.ShowForm(skillsData);


        }

        private void View_New(object pram)
        {
            EditCandidatePresenter.Show(_allSkills);
            Show();
        }

        private void View_Edit(object pram)
        {
            EditCandidatePresenter.Show(_allSkills, View.SelectedCandidateId);
            Show();
        }
        private void View_Delete(object pram)
        {
            HttpClientHelper clientHelper = new HttpClientHelper();
            clientHelper.Delete($"/Candidate/{View.SelectedCandidateId}");
            Show();
        }
        private void View_SkillFilterChanged(object pram)
        {
            if (View.SelectedSkillId == 0)
            {
                View.ShowCandidates(_allCandidates);
            }
            else
            {
                HttpClientHelper clientHelper = new HttpClientHelper();
                var filterdCandidates = clientHelper.Get<GetCandidatesBySkillViewModel>($"/Candidate/GetBySkill/{View.SelectedSkillId}");
                View.ShowCandidates(filterdCandidates.Candidates);
            }
        }
    }
}
