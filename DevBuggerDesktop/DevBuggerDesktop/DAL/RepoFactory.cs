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
        private static BugCategoryRepository bugCategoryRepository { get; set; }
        private static BugReportRepository bugReportRepository { get; set; }
        private static BugReportImageRepository bugReportImageRepository { get; set; }
        private static CommentRepository commentRepository { get; set; }

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

        public static BugCategoryRepository getBugCategoryRepo()
        {
            if (bugCategoryRepository == null)
            {
                bugCategoryRepository = new BugCategoryRepository();
            }
            return bugCategoryRepository;
        }

        public static BugReportRepository getBugReportRepo()
        {
            if (bugReportRepository == null)
            {
                bugReportRepository = new BugReportRepository();
            }
            return bugReportRepository;
        }

        public static BugReportImageRepository getBugReportImageRepo()
        {
            if (bugReportImageRepository == null)
            {
                bugReportImageRepository = new BugReportImageRepository();
            }
            return bugReportImageRepository;
        }

        public static CommentRepository getCommentRepo()
        {
            if (commentRepository == null)
            {
                commentRepository = new CommentRepository();
            }
            return commentRepository;
        }
    }
}
