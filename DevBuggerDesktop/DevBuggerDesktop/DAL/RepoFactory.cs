using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerDesktop.DAL
{
    public class RepoFactory
    {
        private static AccountRepository accountRepository { get; set; }
        public static AccountRepository getAccountRepo()
        {
            if (accountRepository == null)
            {
                accountRepository = new AccountRepository();
            }
            return accountRepository;
        }
    }
}
