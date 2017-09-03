using GSRForms.Presenter;
using GSRForms.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSRForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ISearchCandidatePresenter searchPresenter = new SearchCandidatePresenter(
               new SearchCandidateView(), new AddEditCandidatePresenter(new AddEditCandidateView())
            );

            searchPresenter.Show();

            
        }
    }
}
