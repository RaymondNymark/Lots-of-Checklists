using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lots_of_Checklists.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Essential navigation for the views within this application. Navigates
        // between the Outside a checklist viewmodel and the inside checklist
        // viewmodel.
        private ViewModelBase _selectedViewModel = new OutsideViewModel();

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }


        private readonly DelegateCommand _displayInsideView;
        public ICommand DisplayInsideView => _displayInsideView;

        public MainViewModel()
        {
            _displayInsideView = new DelegateCommand(OnDisplayInsideView);
        }

        private void OnDisplayInsideView(object commandParameter)
        {
            Console.WriteLine("WriteLineinConsole.");
            SelectedViewModel = new InsideViewModel();
        }


        public class DelegateCommand : ICommand
        {
            private readonly Action<object> _executeAction;

            public DelegateCommand(Action<object> executeAction)
            {
                _executeAction = executeAction;
            }

            public void Execute(object parameter) => _executeAction(parameter);

            public bool CanExecute(object parameter) => true;

            public event EventHandler CanExecuteChanged;
        }










        //public ICommand UpdateViewCommand { get; set; }

        //public MainViewModel()
        //{
        //    UpdateViewCommand = new UpdateViewCommand(this);
        //}


        //public void OnChangeName(object commandParameter)
        //{
        //    SelectedViewModel = new InsideViewModel();
        //}


        //public MainViewModel()
        //{
        //    _debugCommand = new DelegateCommand(OnDebug);
        //}

        //private void OnDebug(object commandParameter)
        //{
        //    Console.WriteLine("OnDebugRan");
        //    //SelectedViewModel = new InsideViewModel();
        //}

        //private readonly DelegateCommand _debugCommand;
        //public ICommand DebugCommand => _debugCommand;

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
    }

}
