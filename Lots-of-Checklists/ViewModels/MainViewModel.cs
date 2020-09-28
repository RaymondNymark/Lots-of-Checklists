using Lots_of_Checklists.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lots_of_Checklists.ViewModels;

namespace Lots_of_Checklists.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region View navigation
        // Essential navigation for the views within this application. Navigates
        // between the Outside a checklist viewmodel and the inside checklist
        // viewmodel.
        private ViewModelBase _selectedViewModel = new OutsideViewModel();

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }
        #endregion


        #region Application wide ICommands

        // ICommand template for this implementation. This one will always
        // execute since CanExecuteFunc is always true.
        public ICommand DebugCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => true,
                    CommandAction = () =>
                    {
                        try
                        {
                            Console.WriteLine("DebugCommand executed.");
                            var newInsideView = new InsideViewModel((OutsideViewModel)SelectedViewModel);
                            SelectedViewModel = newInsideView;
                        }
                        catch (System.NullReferenceException)
                        {
                            Console.WriteLine("NullReferenceException");
                        }
                    }
                };
            }
        }

        public ICommand DebugCommandTwo
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => true,
                    CommandAction = () =>
                    {
                        Console.WriteLine("DebugCommandTwo executed.");
                        SelectedViewModel = new OutsideViewModel();
                    }
                };
            }
        }
        #endregion
    }


    /// <summary>
    /// Simplistic delegate command implementation.  According to MVVM
    /// standards, commands should be implemented in the viewModel. This
    /// implementation is taken from the Toggle-Dark-Mode application with a few
    /// adjustments.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        public Action CommandAction { get; set; }
        public Func<bool> CanExecuteFunc { get; set; }

        public void Execute(object parameter)
        {
            CommandAction();
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc == null || CanExecuteFunc();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
