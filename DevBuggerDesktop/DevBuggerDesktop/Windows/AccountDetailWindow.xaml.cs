using DevBuggerDesktop.Models;
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
    /// Interaction logic for AccountDetailWindow.xaml
    /// </summary>
    public partial class AccountDetailWindow : Window
    {
        private readonly Account account;
        private AccountsViewModel accountsViewModel;
        public AccountDetailWindow(AccountsViewModel accountsViewModel, Account account)
        {
            InitializeComponent();
            this.accountsViewModel = accountsViewModel;
            this.account = account;
            DataContext = account;
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age))
                    || ("Email".Equals(e.Tag) && !ValidationUtils.isValidEmail(TbEmail.Text.Trim())))
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

        private void btnGames_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBugReports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnComments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                account.IDAccount = int.Parse(TbIDAccount.Text.Trim());
                account.AccountLevelID = int.Parse(TbAccountLevelID.Text.Trim());
                account.Email = TbEmail.Text.Trim();
                account.Username = TbUsername.Text.Trim();
                account.Password = TbPassword.Text.Trim();
                account.FirstName = TbFirstName.Text.Trim();
                account.LastName = TbLastName.Text.Trim();
                //account.Created = new DateTime(int.Parse(TbCreated.Text.Trim()));

                accountsViewModel.Update(account);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            accountsViewModel.Accounts.Remove(account);
        }

        private void btnReplaceWithDummy_Click(object sender, RoutedEventArgs e)
        {
            accountsViewModel.Update(account);
        }
    }
}
