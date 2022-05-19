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
    /// Interaction logic for BugCategorysPage.xaml
    /// </summary>
    public partial class BugCategorysPage : Page
    {
        BugCategorysViewModel bugCategorysViewModel;
        public BugCategorysPage()
        {
            bugCategorysViewModel = new BugCategorysViewModel();
            InitializeComponent();
            LvAccounts.ItemsSource = bugCategorysViewModel.BugCategorys;
        }
    }
}
