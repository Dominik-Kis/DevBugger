using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
using DevBuggerDesktop.Util;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            account.Email = txtEmail.Text;
            //account.Password = txtPassword.Password;
            account.Password = "Ml6YBKF5pYsjltNcFC9oSNTrPdjPqrfHVu6TKu8rm+0=";
            Account acc = RepoFactory.getAccountRepo().LoginAccount(account);
            if (acc == null || acc.AccountLevelID != 1)
            {
                MessageBox.Show("Username or password is incorrect");
                return;
            }
            DashboardWindow dashboard = new DashboardWindow();
            dashboard.Show();
            this.Close();
        }
    }
}
