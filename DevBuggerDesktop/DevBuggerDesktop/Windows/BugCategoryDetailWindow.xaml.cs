using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Pages;
using DevBuggerDesktop.ViewModels;
using DevBuggerRest.Model;
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
    /// Interaction logic for BugCategoryDetailWindow.xaml
    /// </summary>
    public partial class BugCategoryDetailWindow : Window
    {
        private readonly BugCategory bugCategory;
        private BugCategorysViewModel bugCategorysViewModel;

        public BugCategoryDetailWindow(BugCategory bugCategory)
        {
            InitializeComponent();
            this.bugCategory = bugCategory;
            DataContext = bugCategory;
        }

        public BugCategoryDetailWindow(BugCategorysViewModel bugCategorysViewModel, BugCategory bugCategory)
        {
            InitializeComponent();
            this.bugCategorysViewModel = bugCategorysViewModel;
            this.bugCategory = bugCategory;
            DataContext = bugCategory;
        }

        private void BugReports_Click(object sender, RoutedEventArgs e)
        {
            frameDashboard.Content = new BugReportsPage(bugCategory);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                bugCategory.IDCategory = int.Parse(TbIDCategory.Text.Trim());
                bugCategory.Name = TbName.Text.Trim();
                bugCategory.Description = TbDescription.Text.Trim();

                if (bugCategorysViewModel != null)
                {
                    bugCategorysViewModel.Update(bugCategory);
                }
                else
                {
                    RepoFactory.getBugCategoryRepo().UpdateBugCategory(bugCategory);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (bugCategorysViewModel != null)
            {
                bugCategorysViewModel.BugCategorys.Remove(bugCategory);
            }
            else
            {
                RepoFactory.getBugCategoryRepo().DeleteBugCategory(bugCategory);
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
