using DevBuggerDesktop.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevBuggerDesktop.Pages
{
    /// <summary>
    /// Interaction logic for BugReportsPage.xaml
    /// </summary>
    public partial class BugReportsPage : Page
    {
        BugReportsViewModel bugReportsViewModel;
        public BugReportsPage()
        {
            bugReportsViewModel = new BugReportsViewModel();
            InitializeComponent();
            LvBugReports.ItemsSource = bugReportsViewModel.BugReports;
        }
        public BugReportsPage(Account account)
        {
            bugReportsViewModel = new BugReportsViewModel(account);
            InitializeComponent();
            LvBugReports.ItemsSource = bugReportsViewModel.BugReports;
        }
        public BugReportsPage(GamePage game)
        {
            bugReportsViewModel = new BugReportsViewModel(game);
            InitializeComponent();
            LvBugReports.ItemsSource = bugReportsViewModel.BugReports;
        }
        private void BtnDetail_Click(object sender, RoutedEventArgs e)
        {
            if (LvBugReports.SelectedItem != null)
            {
                //new BugReportDetail(bugReportsViewModel, LvBugReports.SelectedItem as BugReport);
            }
        }

    }
}
