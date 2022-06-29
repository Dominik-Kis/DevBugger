using Caliburn.Micro;
using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevBuggerDesktop.ViewModels
{
    public class AccountsViewModel
    {
        public ObservableCollection<Account> Accounts { get; set; }
        public const string DELETED_ACCOUNT = "[Deleted_account]";

        public AccountsViewModel()
        {
            try
            {
                Accounts = new ObservableCollection<Account>(RepoFactory.getAccountRepo().GetAccounts());
                Accounts.CollectionChanged += Accounts_CollectionChanged;
            }
            catch (Exception)
            {
                MessageBox.Show("No accounts found");
            }

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
            if (account.Username.Equals(DELETED_ACCOUNT))
            {
                RepoFactory.getAccountRepo().UpdateToDummy(account);
            }
            else
            {
                RepoFactory.getAccountRepo().UpdateAccount(account);
            }

        }

        internal void Update(Account account) => Accounts[Accounts.IndexOf(account)] = account;
    }
}
