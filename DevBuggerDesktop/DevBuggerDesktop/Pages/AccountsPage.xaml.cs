using DevBuggerDesktop.Models;
using DevBuggerDesktop.ViewModels;
using DevBuggerDesktop.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AccountsPage.xaml
    /// </summary>
    public partial class AccountsPage : Page
    {
        AccountsViewModel accountsViewModel;
        public AccountsPage()
        {
            accountsViewModel = new AccountsViewModel();
            InitializeComponent();
            LvAccounts.ItemsSource = accountsViewModel.Accounts;
        }

        private void BtnDetail_Click(object sender, RoutedEventArgs e)
        {
            if (LvAccounts.SelectedItem != null)
            {
                new AccountDetailWindow(accountsViewModel, LvAccounts.SelectedItem as Account);
            }
        }

    }
}
