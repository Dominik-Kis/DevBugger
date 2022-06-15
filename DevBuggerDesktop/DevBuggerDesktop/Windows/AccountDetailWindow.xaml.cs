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

        public AccountDetailWindow(Account account)
        {
            InitializeComponent();
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
            frameDashboard.Content = new GamesPage(account);
        }

        private void btnBugReports_Click(object sender, RoutedEventArgs e)
        {
            frameDashboard.Content = new BugReportsPage(account);
        }

        private void btnComments_Click(object sender, RoutedEventArgs e)
        {
            frameDashboard.Content = new CommentsPage(account);
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

                if (accountsViewModel != null)
                {
                    accountsViewModel.Update(account);
                }
                else
                {
                    RepoFactory.getAccountRepo().UpdateAccount(account);
                }

                this.Close();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (accountsViewModel != null)
            {
                accountsViewModel.Accounts.Remove(account);
            }
            else
            {
                RepoFactory.getAccountRepo().DeleteAccount(account);
            }

            this.Close();
        }

        private void btnReplaceWithDummy_Click(object sender, RoutedEventArgs e)
        {
            account.IDAccount = int.Parse(TbIDAccount.Text.Trim());
            account.AccountLevelID = int.Parse(TbAccountLevelID.Text.Trim());
            account.Email = TbEmail.Text.Trim();
            account.Username = "[Deleted_account]".Trim();
            account.Password = "go342mjkojsdpkijgmkiWEENMGKwnghare".Trim();
            account.FirstName = "Deleted".Trim();
            account.LastName = "Account".Trim();

            if (accountsViewModel != null)
            {
                accountsViewModel.Update(account);
            }
            else
            {
                RepoFactory.getAccountRepo().UpdateToDummy(account);
            }

            this.Close();
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // YesButton Clicked! Let's hide our InputBox and handle the input text.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Use PasswordHashUtils to hash the password and save it to the text box
            String password = InputTextBox.Text;
            String hashedPassword = PasswordHashUtils.HashPassword(password);
            TbPassword.Text = hashedPassword;

            // Clear InputBox.
            InputTextBox.Text = String.Empty;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            // NoButton Clicked! Let's hide our InputBox.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Clear InputBox.
            InputTextBox.Text = String.Empty;
        }
    }
}
