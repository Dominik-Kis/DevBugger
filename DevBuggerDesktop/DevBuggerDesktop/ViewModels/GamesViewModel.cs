using Caliburn.Micro;
using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerDesktop.ViewModels
{
    public class GamesViewModel
    {
        public BindableCollection<GamePage> Games { get; set; }

        public GamesViewModel()
        {
            Games = new BindableCollection<GamePage>(RepoFactory.getGamePageRepo().GetGamePages());
        }
    }
}
