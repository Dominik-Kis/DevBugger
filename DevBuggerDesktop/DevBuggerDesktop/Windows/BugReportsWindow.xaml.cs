using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
using DevBuggerDesktop.Pages;
using DevBuggerDesktop.Util;
using DevBuggerDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DevBuggerDesktop.Windows
{
    /// <summary>
    /// Interaction logic for BugReportsWindow.xaml
    /// </summary>
    public partial class BugReportsWindow : Window
    {

        private readonly BugReport bugReport;
        private BugReportsViewModel bugReportsViewModel;
        public BugReportsWindow(BugReportsViewModel bugReportsViewModel, BugReport bugReport)
        {
            InitializeComponent();
            this.bugReportsViewModel = bugReportsViewModel;
            this.bugReport = bugReport;
            DataContext = bugReport;
        }
        public BugReportsWindow(BugReport bugReport)
        {
            InitializeComponent();
            this.bugReport = bugReport;
            DataContext = bugReport;
        }

        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            new AccountDetailWindow(RepoFactory.getAccountRepo().GetAccount(bugReport.AccountID));
        }

        private void btnOpenGame_Click(object sender, RoutedEventArgs e)
        {
            new GameDetailWindow(RepoFactory.getGamePageRepo().GetGamePage(bugReport.GamePageID));
        }

        private void btnOpenBugCategory_Click(object sender, RoutedEventArgs e)
        {
            new BugCategoryDetailWindow(RepoFactory.getBugCategoryRepo().GetBugCategory(bugReport.BugCategoryID));
        }

        private void btnComments_Click(object sender, RoutedEventArgs e)
        {
            frameDashboard.Content = new CommentsPage(bugReport);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                bugReport.IDBugReport = int.Parse(TbIDBugReport.Text.Trim());
                bugReport.BugCategoryID = int.Parse(TbBugCategoryID.Text.Trim());
                bugReport.GamePageID = int.Parse(TbGamePageID.Text.Trim());
                bugReport.AccountID = int.Parse(TbAccountID.Text.Trim());
                bugReport.Title = TbTitle.Text.Trim();
                bugReport.Description = TbDescription.Text.Trim();
                //bugReport.Created = new DateTime(int.Parse(TbCreated.Text.Trim()));

                if (bugReportsViewModel != null)
                {
                    bugReportsViewModel.Update(bugReport);
                }
                else
                {
                    RepoFactory.getBugReportRepo().UpdateBugReport(bugReport);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (bugReportsViewModel != null)
            {
                bugReportsViewModel.BugReports.Remove(bugReport);
            }
            else
            {
                RepoFactory.getBugReportRepo().DeleteBugReport(bugReport);
            }

            this.Close();
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age)))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            return valid;
        }

    }
}
