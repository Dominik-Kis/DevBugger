using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
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
    /// Interaction logic for CommentDetailWindow.xaml
    /// </summary>
    public partial class CommentDetailWindow : Window
    {
        private CommentsViewModel commentsViewModel;
        private Comment comment;
        public CommentDetailWindow(CommentsViewModel commentsViewModel, Comment comment)
        {
            InitializeComponent();
            this.commentsViewModel = commentsViewModel;
            this.comment = comment;
            DataContext = comment;
        }

        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            new AccountDetailWindow(RepoFactory.getAccountRepo().GetAccount(comment.AccountID));
        }

        private void btnOpenBugReport_Click(object sender, RoutedEventArgs e)
        {
            new BugReportsWindow(RepoFactory.getBugReportRepo().GetBugReport(comment.BugReportID));
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                comment.IDComment = int.Parse(TbIDComment.Text.Trim());
                comment.BugReportID = int.Parse(TbBugReportID.Text.Trim());
                comment.AccountID = int.Parse(TbAccountID.Text.Trim());
                comment.Text = TbText.Text.Trim();
                //comment.Created = new DateTime(int.Parse(TbCreated.Text.Trim()));

                if (commentsViewModel != null)
                {
                    commentsViewModel.Update(comment);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (commentsViewModel != null)
            {
                commentsViewModel.Comments.Remove(comment);
            }

            this.Close();
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age)))
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

    }
}
