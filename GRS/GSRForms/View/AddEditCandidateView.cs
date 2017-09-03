using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSRForms.Models;

namespace GSRForms.View
{
    public partial class AddEditCandidateView : Form, IAddEditCandidateView
    {

        private List<SkillViewModel> _selectedSkills;
        public Action<object> Ok { get; set; }


        public AddEditCandidateView()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (Ok != null)
            {
                Ok(sender);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Show(IEnumerable<SkillViewModel> allSkills, CandidateDetailViewModel candidatDetail)
        {
            textBoxFirstName.Text = candidatDetail.FirstName;
            textBoxLastName.Text = candidatDetail.LastName;
            comboBoxSkill.DataSource = allSkills;
            comboBoxSkill.DisplayMember = nameof(SkillViewModel.Name);

            _selectedSkills = candidatDetail.Skills.Select(x => new SkillViewModel() {
                Id = x,
                Name = allSkills.FirstOrDefault(y => y.Id == x).Name
            }).ToList();
            listBoxSkills.DataSource = _selectedSkills;
            listBoxSkills.DisplayMember = nameof(SkillViewModel.Name);

            
            this.ShowDialog();
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            SkillViewModel selectedSkill = (SkillViewModel)comboBoxSkill.SelectedItem;
            if (_selectedSkills.FirstOrDefault(x => x.Id == selectedSkill.Id) == null)
            {
                _selectedSkills.Add(selectedSkill);
            }
            listBoxSkills.DataSource = null;
            listBoxSkills.DataSource = _selectedSkills;
            listBoxSkills.DisplayMember = nameof(SkillViewModel.Name);
            
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            SkillViewModel selectedSkill = (SkillViewModel)listBoxSkills.SelectedItem;
            if (selectedSkill == null) { return; }
            _selectedSkills.Remove(selectedSkill);
            listBoxSkills.DataSource = null;
            listBoxSkills.DataSource = _selectedSkills;
            listBoxSkills.DisplayMember = nameof(SkillViewModel.Name);

        }

        public string GetFirstName()
        {
            return textBoxFirstName.Text;
        }

        public string GetLastName()
        {
            return textBoxLastName.Text;
        }

        public IEnumerable<long> GetSelectedSkills()
        {
            if (_selectedSkills == null) { return new List<long> { }; }
            return _selectedSkills.Select(x => x.Id);
        }
    }
}
