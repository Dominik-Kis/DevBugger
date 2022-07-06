using DevBuggerDesktop.DAL;
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
    /// Interaction logic for BugCategoryAddWindow.xaml
    /// </summary>
    public partial class BugCategoryAddWindow : Window
    {
        private BugCategorysViewModel bugCategorysViewModel;
        public BugCategoryAddWindow(BugCategorysViewModel bugCategorysViewModel)
        {
            InitializeComponent();
            this.bugCategorysViewModel = bugCategorysViewModel;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                BugCategory bugCategory = new BugCategory();
                bugCategory.Name = TbName.Text.Trim();
                bugCategory.Description = TbDescription.Text.Trim();

                if (bugCategorysViewModel != null)
                {
                    bugCategorysViewModel.BugCategorys.Add(bugCategory);
                }
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
