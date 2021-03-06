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
    public class GamesViewModel
    {
        public ObservableCollection<GamePage> Games { get; set; }

        public GamesViewModel()
        {
            try
            {
                Games = new ObservableCollection<GamePage>(RepoFactory.getGamePageRepo().GetGamePages());
                Games.CollectionChanged += Games_CollectionChanged;
            }
            catch (Exception)
            {
                MessageBox.Show("No games found");
            }
        }

        public GamesViewModel(Account account)
        {
            try
            {
                Games = new ObservableCollection<GamePage>(RepoFactory.getGamePageRepo().GetGamePagesByAccountID(account.IDAccount));
                Games.CollectionChanged += Games_CollectionChanged;
            }
            catch (Exception)
            {
                MessageBox.Show("No games found");
            }
        }

        private void Games_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepoFactory.getGamePageRepo().AddGamePage(Games[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepoFactory.getGamePageRepo().DeleteGamePage(e.OldItems.OfType<GamePage>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepoFactory.getGamePageRepo().UpdateGamePage(e.NewItems.OfType<GamePage>().ToList()[0]);
                    break;
            }
        }

        internal void Update(GamePage game) => Games[Games.IndexOf(game)] = game;
    }
}
