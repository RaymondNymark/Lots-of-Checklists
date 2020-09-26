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


        //private readonly DelegateCommand _changeNameCommand;
        //public ICommand ChangeNameCommand => _changeNameCommand;

        //public OutsideViewModel()
        //{
        //    _changeNameCommand = new DelegateCommand();
        //}























        // Legacy code
        ////private ViewModelBase _selectedViewModel = new InsideChecklistViewModel();
        ////public ViewModelBase SelectedViewModel
        ////{
        ////    get => _selectedViewModel;
        ////    set => _selectedViewModel = value;
        ////}


        //private static ChecklistsEntities _dbContext = new ChecklistsEntities();

        //// For some reason, this needs to be declared before anything will work. Strange!
        //public static ObservableCollection<Checklist> ChecklistCollection = new ObservableCollection<Checklist>(_dbContext.Checklist);

        //// Indirect collection

        ////private static ObservableCollection<Checklist> CurrentSource

        //// Adding anything to this or directly to _dbContext will refresh it. Neat!
        //public static ObservableCollection<Checklist> CurrentCollectionSource
        //{
        //    get => _dbContext.Checklist.Local;
        //}

        //private static ObservableCollection<Checklist> CurrentChecklistSource
        //{
        //    get => _dbContext.Checklist.Local;
        //}

        //private static ObservableCollection<Item> CurrentChecklistItemSource
        //{
        //    get => _dbContext.Checklist.FirstOrDefault(r => r.Description == "ChecklistOne").Item;
        //}

        //private object _content;
        //public object Content
        //{
        //    get => _content;
        //    set => SetProperty(ref _content, value);
        //}

        ////public static void testFuncs()
        ////{
        ////    CurrentChecklistCollectionSource = new ObservableCollection<Item>();
        ////}

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

        //// Debug-only
        //private readonly DelegateCommand _debugCommand;
        //public ICommand DebugCommandExecute => _debugCommand;
        //// Debug button commands go here:
        //private void DebugCommandExecuted(object commandParameter)
        //{
        //    // Have to figure out how to change source.
        //    //CurrentCollectionSource = _dbContext.Checklist.FirstOrDefault(r => r.Description == "ChecklistOne").Item.ToList();
        //}

        //// Add new checklistCommand
        //private readonly DelegateCommand _addNewChecklistCommand;
        //public ICommand AddNewChecklistCommand => _addNewChecklistCommand;



        //private void OnAddNewChecklist(object commandParameter)
        //{
        //    // TODO: Implement this.
        //    // Both of these implementations work.
        //    using (_dbContext)
        //    {
        //        _dbContext.Checklist.Add(new Checklist { Description = "Forbidden Checklist😃" });
        //        _dbContext.SaveChanges();
        //    }

        //    //CurrentCollectionSource.Add(new Checklist { Description = "Forbidden Checklist" });
        //}


        //private readonly DelegateCommand _deleteSelectedChecklistCommand;
        //public ICommand DeleteSelectedChecklistCommand => _deleteSelectedChecklistCommand;

        //public MainWindowViewModel()
        //{
        //    _deleteSelectedChecklistCommand = new DelegateCommand(OnChecklistDelete);
        //    _addNewChecklistCommand = new DelegateCommand(OnAddNewChecklist);
        //    _debugCommand = new DelegateCommand(DebugCommandExecuted);
        //}

        //private void OnChecklistDelete(object commandParameter)
        //{
        //}


        //public class DelegateCommand : ICommand
        //{
        //    private readonly Action<object> _executeAction;

        //    public DelegateCommand(Action<object> executeAction)
        //    {
        //        _executeAction = executeAction;
        //    }

        //    public void Execute(object parameter) => _executeAction(parameter);

        //    public bool CanExecute(object parameter) => true;

        //    public event EventHandler CanExecuteChanged;
        //}


        //#endregion


        //#region Temporary legacy code region TODO: Remove this.
        ////// Attempt 2
        //////private ChecklistsEntities _context = new ChecklistsEntities();

        //////public IList<Checklist> Context
        //////{
        //////    get => _context.Checklist.
        //////    set => SetProperty(ref _context.Checklist, value);
        //////}

        ////// Attempt 3

        //////private void FillList()
        //////{
        //////    foreach(Checklist c in Context.Checklist)
        //////    {
        //////        ChecklistCollection.Add(c);
        //////    }
        //////}


        ////// Attempt 4.  Using ObservableCollection with get and set properties.
        ////private DbSet<Checklist> ChecklistDB
        ////{
        ////    get => Context.Checklist;
        ////}
        ////public ObservableCollection<Checklist> BetterChecklistCollection { get; } = new ObservableCollection<Checklist>(Context.Checklist);
        //////public ObservableCollection<Checklist> Attempt5ChecklistCollection { get; } = new ObservableCollection<Checklist>(Context.Checklist);

        ////private ObservableCollection<Checklist> _Attempt5ChecklistCollection = new ObservableCollection<Checklist>(Context.Checklist);

        ////public ObservableCollection<Checklist> Attempt5ChecklistCollection
        ////{
        ////    get => _Attempt5ChecklistCollection;
        ////}

        ////public void AddChecklist5()
        ////{
        ////    var newItem = new Checklist { Description = "NewestChecklist" };

        ////    Context.Checklist.Add(newItem);
        ////    Context.SaveChanges();

        ////    //OnPropertyChanged(nameof(Context.Checklist));
        ////    //OnPropertyChanged(nameof(Attempt5ChecklistCollection));
        ////}

        ////private static ChecklistsEntities _dbContext = new ChecklistsEntities();

        ////public static System.Data.Entity.DbSet<Lots_of_Checklists.Checklist> _privateIChecklist = _dbContext.Checklist;

        ////public List<Checklist> PrivateIChecklist
        ////{
        ////    get => _privateIChecklist.ToList();
        ////    //set => SetProperty(ref _privateIChecklist, value);
        ////}

        ////public ObservableCollection<Checklist> ListOChecklists = new ObservableCollection<Checklist>(_dbContext.Checklist);

        //////private List<Checklist> _checklistSource = _dbContext.Checklist.ToList();

        //////public List<Checklist> ChecklistSource
        //////{
        //////    get => _checklistSource;
        //////    set => SetProperty(ref _checklistSource, value);
        //////}

        ////// Method to add to checklist.
        ////private void AddChecklist(string description)
        ////{
        ////    //using (_dbContext)
        ////    //{
        ////    //    _privateIChecklist.Add(new Checklist { Description = description });
        ////    //    _dbContext.SaveChanges();
        ////    //}
        ////    //OnPropertyChanged();
        ////    AddChecklist5();
        ////}
        //#endregion


    }
}
