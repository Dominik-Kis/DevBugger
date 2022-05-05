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
        private static GamePageRepository gamePageRepository { get; set; }

        public static AccountRepository getAccountRepo()
        {
            if (accountRepository == null)
            {
                accountRepository = new AccountRepository();
            }
            return accountRepository;
        }

        public static GamePageRepository getGamePageRepo()
        {
            if (gamePageRepository == null)
            {
                gamePageRepository = new GamePageRepository();
            }
            return gamePageRepository;
        }
    }
}
