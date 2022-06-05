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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevBuggerDesktop.Pages
{
    /// <summary>
    /// Interaction logic for CommentsPage.xaml
    /// </summary>
    public partial class CommentsPage : Page
    {
        CommentsViewModel commentsViewModel;
        public CommentsPage()
        {
            commentsViewModel = new CommentsViewModel();
            InitializeComponent();
            LvComments.ItemsSource = commentsViewModel.Comments;
        }
        public CommentsPage(Account account)
        {
            commentsViewModel = new CommentsViewModel(account);
            InitializeComponent();
            LvComments.ItemsSource = commentsViewModel.Comments;
        }
        public CommentsPage(GamePage game)
        {
            commentsViewModel = new CommentsViewModel(game);
            InitializeComponent();
            LvComments.ItemsSource = commentsViewModel.Comments;
        }
        private void BtnDetail_Click(object sender, RoutedEventArgs e)
        {
            if (LvComments.SelectedItem != null)
            {
                //new CommentDetail(commentsViewModel, LvComments.SelectedItem as Comment);
            }
        }
    }
}
