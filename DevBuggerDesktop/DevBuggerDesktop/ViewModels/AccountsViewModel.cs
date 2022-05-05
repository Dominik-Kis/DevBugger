using Caliburn.Micro;
using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerDesktop.ViewModels
{
    public class AccountsViewModel
    {
        public BindableCollection<Account> Accounts { get; set; }

        public AccountsViewModel()
        {
            Accounts = new BindableCollection<Account>(RepoFactory.getAccountRepo().GetAccounts());
        }
    }
}
