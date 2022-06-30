using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
using DevBuggerDesktop.Pages;
using DevBuggerDesktop.Util;
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
    /// Interaction logic for GameDetailWindow.xaml
    /// </summary>
    public partial class GameDetailWindow : Window
    {
        private readonly GamePage game;
        private GamesViewModel gamesViewModel;
        public GameDetailWindow(GamesViewModel gamesViewModel, GamePage game)
        {
            InitializeComponent();
            this.gamesViewModel = gamesViewModel;
            this.game = game;
            DataContext = game;
        }

        public GameDetailWindow(GamePage game)
        {
            InitializeComponent();
            this.game = game;
            DataContext = game;
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()) || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age)))
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                game.IDGamePage = int.Parse(TbIDGamePage.Text.Trim());
                game.AccountID = int.Parse(TbAccountID.Text.Trim());
                game.Title = TbTitle.Text.Trim();
                game.Description = TbDescription.Text.Trim();
                //game.Created = new DateTime(int.Parse(TbCreated.Text.Trim()));

                if (gamesViewModel != null)
                {
                    gamesViewModel.Update(game);
                }
                else
                {
                    RepoFactory.getGamePageRepo().UpdateGamePage(game);
                }

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gamesViewModel != null)
            {
                gamesViewModel.Games.Remove(game);
            }
            else
            {
                RepoFactory.getGamePageRepo().DeleteGamePage(game);
            }
        }

        private void btnBugReports_Click(object sender, RoutedEventArgs e)
        {
            frameDashboard.Content = new BugReportsPage(game);
        }

        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            new AccountDetailWindow(RepoFactory.getAccountRepo().GetAccount(game.AccountID));
        }
    }
}
