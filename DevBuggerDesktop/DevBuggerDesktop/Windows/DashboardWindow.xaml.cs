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
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            frameDashboard.Source = new Uri("/DevBuggerDesktop;component/Pages/AccountsPage.xaml", UriKind.Relative);
        }

        private void btnGames_Click(object sender, RoutedEventArgs e)
        {
            frameDashboard.Source = new Uri("/DevBuggerDesktop;component/Pages/GamesPage.xaml", UriKind.Relative);
        }
    }
}
