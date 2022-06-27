using DevBuggerDesktop.Models;
using DevBuggerDesktop.ViewModels;
using DevBuggerDesktop.Windows;
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
    /// Interaction logic for GamesPage.xaml
    /// </summary>
    public partial class GamesPage : Page
    {
        GamesViewModel gamesViewModel;
        public GamesPage()
        {
            gamesViewModel = new GamesViewModel();
            InitializeComponent();
            LvGames.ItemsSource = gamesViewModel.Games;
        }

        public GamesPage(Account account)
        {
            gamesViewModel = new GamesViewModel(account);
            InitializeComponent();
            LvGames.ItemsSource = gamesViewModel.Games;
        }

        private void BtnDetail_Click(object sender, RoutedEventArgs e)
        {
            if (LvGames.SelectedItem != null)
            {
                new GameDetailWindow(gamesViewModel, LvGames.SelectedItem as GamePage);
            }
        }
    }
}
