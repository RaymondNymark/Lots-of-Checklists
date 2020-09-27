using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Lots_of_Checklists.ViewModels.MainViewModel;
using Lots_of_Checklists.Models;

namespace Lots_of_Checklists.ViewModels
{
    public class OutsideViewModel : ViewModelBase
    {
        private static ChecklistsEntities _dbContext = new ChecklistsEntities();
        public static ObservableCollection<Checklist> ChecklistCollection = new ObservableCollection<Checklist>(_dbContext.Checklist);
        public static ObservableCollection<Checklist> CurrentCollectionSource
        {
            get => _dbContext.Checklist.Local;
        }


        private Checklist _selectedChecklist;
        public Checklist SelectedChecklist
        {
            get => _selectedChecklist;
            set => SetProperty(ref _selectedChecklist, value);
        }


        
        //#region Delegate Command Region
        ////-----Temporary unimplemented methods-----

        //// Insert
        //private readonly DelegateCommand _addChecklistCommand;
        //private readonly DelegateCommand _addItemToChecklistCommand;
        //// Remove
        //private readonly DelegateCommand _removeChecklistCommand;
        //private readonly DelegateCommand _removeItemFromChecklistCommand;
        //// Update
        //private readonly DelegateCommand _renameSelectedObjectCommand;
        //// TODO: Implement drag and drop class to re-order items.

        //// View-related
        //private readonly DelegateCommand _openChecklistCommand;
        //private readonly DelegateCommand _closeChecklistCommand;
    }
}
