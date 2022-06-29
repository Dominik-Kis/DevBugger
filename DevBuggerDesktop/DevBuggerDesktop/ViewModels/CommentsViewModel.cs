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
    public class CommentsViewModel
    {
        public ObservableCollection<Comment> Comments { get; set; }

        public CommentsViewModel()
        {
            try
            {
                Comments = new ObservableCollection<Comment>(RepoFactory.getCommentRepo().GetComments());
                Comments.CollectionChanged += Comments_CollectionChanged;
            }
            catch (Exception)
            {
                MessageBox.Show("No bug categorys found");
            }
        }

        public CommentsViewModel(Account account)
        {
            try
            {
                Comments = new ObservableCollection<Comment>(RepoFactory.getCommentRepo().GetCommentsByAccountID(account.IDAccount));
                Comments.CollectionChanged += Comments_CollectionChanged;
            }
            catch (Exception)
            {
                MessageBox.Show("No bug categorys found");
            }
        }

        public CommentsViewModel(BugReport bugReport)
        {
            try
            {
                Comments = new ObservableCollection<Comment>(RepoFactory.getCommentRepo().GetCommentsByBugReportID(bugReport.IDBugReport));
                Comments.CollectionChanged += Comments_CollectionChanged;
            }
            catch (Exception)
            {
                MessageBox.Show("No bug categorys found");
            }
        }

        private void Comments_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepoFactory.getCommentRepo().AddComment(Comments[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepoFactory.getCommentRepo().DeleteComment(e.OldItems.OfType<Comment>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepoFactory.getCommentRepo().UpdateComment(e.NewItems.OfType<Comment>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Comment comment) => Comments[Comments.IndexOf(comment)] = comment;
    }
}
