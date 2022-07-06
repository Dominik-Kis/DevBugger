using DevBuggerDesktop.ViewModels;
using DevBuggerDesktop.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevBuggerDesktop.Pages
{
    /// <summary>
    /// Interaction logic for BugCategorysPage.xaml
    /// </summary>
    public partial class BugCategorysPage : Page
    {
        BugCategorysViewModel bugCategorysViewModel;
        public BugCategorysPage()
        {
            bugCategorysViewModel = new BugCategorysViewModel();
            InitializeComponent();
            LvBugCategory.ItemsSource = bugCategorysViewModel.BugCategorys;
        }

        private void BtnDetail_Click(object sender, RoutedEventArgs e)
        {
            if (LvBugCategory.SelectedItem != null)
            {
                new BugCategoryDetailWindow(bugCategorysViewModel, LvBugCategory.SelectedItem as BugCategory);
            }
        }

        private void ListView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContextMenu cm = this.FindResource("cmClick") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            new BugCategoryAddWindow(bugCategorysViewModel);
        }
    }
}
