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
using Lots_of_Checklists.Core;
using Autofac;

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

        //public static ObservableCollection<Checklists> Checklistscollection = new ObservableCollection<Checklists>(container.BeginLifetimeScope().Resolve<IChecklistRepository>().GetChecklistsCollection());
        //public static ObservableCollection<Checklists> ItemsSourceProperty
        //{
        //    get => container.BeginLifetimeScope().Resolve<IChecklistRepository>().GetChecklistsCollection();
        //}


        private IChecklistService _checklistService;
        public ObservableCollection<Checklists> ChecklistsCollection { get; private set; }


        private Checklist _selectedChecklist;
        public Checklist SelectedChecklist
        {
            get => _selectedChecklist;
            set => SetProperty(ref _selectedChecklist, value);
        }




        //private static Autofac.IContainer container;

        public OutsideViewModel(IChecklistService checklistService)
        {
            

                _checklistService = checklistService;
            ChecklistsCollection = new ObservableCollection<Checklists>(_checklistService.Checklists);

            //container = ContainerConfig.Configure();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var app = scope.Resolve<IChecklistRepository>();
            //    Checklistscollection = new ObservableCollection<Checklists>(app.GetChecklistsDbSet());
            //    ItemsSourceProperty = app.GetChecklistsCollection();
            //}
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
