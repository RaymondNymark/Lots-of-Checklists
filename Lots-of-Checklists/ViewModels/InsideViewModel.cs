using Lots_of_Checklists.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lots_of_Checklists.ViewModels
{
    public class InsideViewModel : ViewModelBase
    {
        //private ChecklistsEntities _dbContext = new ChecklistsEntities();
        //public ObservableCollection<Item> CurrentItemCollectionSource
        //{
        //    get => _dbContext.Checklist.FirstOrDefault(r => r.Description == "ChecklistOne").Item;
        //}

        //public ObservableCollection<Item> ItemCollection = new ObservableCollection<Item>(_selectedChecklist.Item);

        private ObservableCollection<Item> _itemSource;
        public ObservableCollection<Item> ItemSource
        {
            get => _itemSource;
            set => SetProperty(ref _itemSource, value);
        }

        public InsideViewModel(OutsideViewModel currentViewModel)
        {
            ItemSource = currentViewModel.SelectedChecklist.Item;
        }
    }
}
