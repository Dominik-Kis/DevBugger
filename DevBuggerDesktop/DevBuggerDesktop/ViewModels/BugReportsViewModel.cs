using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
using DevBuggerRest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevBuggerDesktop.ViewModels
{
    public class BugReportsViewModel
    {
        public ObservableCollection<BugReport> BugReports { get; set; }

        public BugReportsViewModel()
        {
            BugReports = new ObservableCollection<BugReport>(RepoFactory.getBugReportRepo().GetBugReports());
            BugReports.CollectionChanged += BugReports_CollectionChanged;
        }

        public BugReportsViewModel(Account account)
        {
            try
            {
                BugReports = new ObservableCollection<BugReport>(RepoFactory.getBugReportRepo().GetBugReportsByAccountID(account.IDAccount));
                BugReports.CollectionChanged += BugReports_CollectionChanged;
            }
            catch (Exception)
            {
                MessageBox.Show("No bug reports found");
            }
        }

        public BugReportsViewModel(GamePage game)
        {
            try
            {
                BugReports = new ObservableCollection<BugReport>(RepoFactory.getBugReportRepo().GetBugReportsByGamePageID(game.IDGamePage));
                BugReports.CollectionChanged += BugReports_CollectionChanged;
            }
            catch (Exception)
            {
                MessageBox.Show("No bug reports found");
            }
        }

        public BugReportsViewModel(BugCategory bugCategory)
        {
            try
            {
                BugReports = new ObservableCollection<BugReport>(RepoFactory.getBugReportRepo().GetBugReportsByBugCategoryID(bugCategory.IDCategory));
                BugReports.CollectionChanged += BugReports_CollectionChanged;
            }
            catch (Exception)
            {
                MessageBox.Show("No bug reports found");
            }
        }

        private void BugReports_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepoFactory.getBugReportRepo().AddBugBugReport(BugReports[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepoFactory.getBugReportRepo().DeleteBugReport(e.OldItems.OfType<BugReport>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepoFactory.getBugReportRepo().UpdateBugReport(e.NewItems.OfType<BugReport>().ToList()[0]);
                    break;
            }
        }

        internal void Update(BugReport bugReport) => BugReports[BugReports.IndexOf(bugReport)] = bugReport;
    }
}
