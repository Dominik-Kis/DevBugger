using DevBuggerDesktop.DAL;
using DevBuggerRest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuggerDesktop.ViewModels
{
    public class BugCategorysViewModel
    {
        public ObservableCollection<BugCategory> BugCategorys { get; set; }

        public BugCategorysViewModel()
        {
            BugCategorys = new ObservableCollection<BugCategory>(RepoFactory.getBugCategoryRepo().GetBugCategories());
            BugCategorys.CollectionChanged += BugCategorys_CollectionChanged;
        }

        private void BugCategorys_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepoFactory.getBugCategoryRepo().AddBugCategory(BugCategorys[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepoFactory.getBugCategoryRepo().DeleteBugCategory(e.OldItems.OfType<BugCategory>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepoFactory.getBugCategoryRepo().UpdateBugCategory(e.NewItems.OfType<BugCategory>().ToList()[0]);
                    break;
            }
        }

        internal void Update(BugCategory bugCategory) => BugCategorys[BugCategorys.IndexOf(bugCategory)] = bugCategory;
    }
}
