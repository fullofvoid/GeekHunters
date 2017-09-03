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
    public partial class SearchCandidateView : Form, ISearchCandidateView
    {
        public long SelectedSkillId
        {
            get{return ((SkillViewModel)comboBoxSkills.SelectedItem).Id;}
            
        }

        public long SelectedCandidateId
        {
            get
            {
                return (dataGridViewCandidates.SelectedRows.Count > 0) ?
                    ((CandidateViewModel)dataGridViewCandidates.SelectedRows[0].DataBoundItem).Id
                    : 0;
            }
        }

        public SearchCandidateView()
        {
            InitializeComponent();
        }

        public Action<object> SkillFilterChanged { get; set; }
        public Action<object> Edit { get; set; }
        public Action<object> New { get; set; }
        public Action<object> Delete { get; set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SkillFilterChanged != null)
            {
                SkillFilterChanged(sender);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (New != null)
            {
                New(sender);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(sender);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(sender);
            }
        }
        public void ShowForm(GetCandidatesViewModel data)
        {
            this.comboBoxSkills.DataSource = data.Skills;
            this.comboBoxSkills.DisplayMember = nameof(SkillViewModel.Name);

            ShowCandidates(data.Candidates);
            dataGridViewCandidates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (!this.Visible) { Application.Run(this); }
        }

        public void ShowCandidates(IEnumerable<CandidateViewModel> allCandidates)
        {
            this.dataGridViewCandidates.DataSource = allCandidates;
            this.dataGridViewCandidates.AutoGenerateColumns = true;
        }

    }
}
