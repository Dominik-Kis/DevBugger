using Caliburn.Micro;
using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerDesktop.ViewModels
{
    public class AccountsViewModel
    {
        public ObservableCollection<Account> Accounts { get; set; }
        public const string DELETED_ACCOUNT = "[Deleted_account]";

        public AccountsViewModel()
        {
            Accounts = new ObservableCollection<Account>(RepoFactory.getAccountRepo().GetAccounts());
            Accounts.CollectionChanged += Accounts_CollectionChanged;
        }

        private void Accounts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepoFactory.getAccountRepo().AddAccount(Accounts[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepoFactory.getAccountRepo().DeleteAccount(e.OldItems.OfType<Account>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    HandleUpdate(e.NewItems.OfType<Account>().ToList()[0]);
                    break;
            }
        }

        private void HandleUpdate(Account account)
        {
            if (account.Username == DELETED_ACCOUNT)
            {
                RepoFactory.getAccountRepo().UpdateToDummy(account);
                return;
            }

            RepoFactory.getAccountRepo().UpdateAccount(account);
        }

        internal void Update(Account account) => Accounts[Accounts.IndexOf(account)] = account;
    }
}
