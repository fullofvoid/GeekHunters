using GSRForms.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSRForms.Models;

namespace GSRForms.Presenter
{
    public class AddEditCandidatePresenter: IAddEditCandidatePresenter
    {
        long? _candidateId;
        public IAddEditCandidateView View { get; private set; }

        public AddEditCandidatePresenter(IAddEditCandidateView view)
        {
            this.View = view;
        }

        public void Show(IEnumerable<SkillViewModel> allSkills)
        {
            if (allSkills == null) { return; }
            _candidateId = null;
            var candidateDetail = new CandidateDetailViewModel() {
                Id=0,
                FirstName = string.Empty,
                LastName = string.Empty,
                Skills = new List<long>()
            };

            View.Ok = View_Ok;
            View.Show(allSkills, candidateDetail);
        }
        public void Show(IEnumerable<SkillViewModel> allSkills, long candidateId)
        {
            if (allSkills == null ) { return; }
            _candidateId = candidateId;
            HttpClientHelper clientHelper = new HttpClientHelper();
            var candidateDetail = clientHelper.Get<CandidateDetailViewModel>($"/Candidate/{candidateId}");

            View.Ok = View_Ok;
            View.Show(allSkills, candidateDetail);
        }

        private void View_Ok(object sender)
        {
            var candidateDetail = new CandidateDetailViewModel()
            {
                FirstName = View.GetFirstName(),
                LastName = View.GetLastName(),
                Skills = View.GetSelectedSkills()
            };
            if (_candidateId.HasValue)
            {
                candidateDetail.Id = _candidateId.Value;
                HttpClientHelper clientHelper = new HttpClientHelper();
                clientHelper.Post($"/Candidate", candidateDetail);
            }
            else
            {
                HttpClientHelper clientHelper = new HttpClientHelper();
                clientHelper.Put($"/Candidate", candidateDetail);
            }
            View.Close();
        }
    }
}
