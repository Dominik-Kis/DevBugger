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
        public BugCategoryDetailWindow(BugCategorysViewModel bugCategorysViewModel, BugCategory bugCategory)
        {
            InitializeComponent();
            this.bugCategorysViewModel = bugCategorysViewModel;
            this.bugCategory = bugCategory;
            DataContext = bugCategory;
        }

        private void BugReports_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
