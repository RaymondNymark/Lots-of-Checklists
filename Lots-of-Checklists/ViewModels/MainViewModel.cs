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
using Lots_of_Checklists.Core;
using Autofac;

namespace Lots_of_Checklists.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Autofac
        IChecklistRepository _checklistRepository;
        IChecklistService _checklistService;
        private static IContainer Container { get; set; }

        IContainer container = ContainerConfig.Configure();
        

        #endregion



        #region View navigation
        // Essential navigation for the views within this application. Navigates
        // between the Outside a checklist viewmodel and the inside checklist
        // viewmodel.
        private ViewModelBase _selectedViewModel = new OutsideViewModel(_checklistService);

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }
        #endregion

        #region Application wide ServiceAccess
        // Explicit declaration of the container. It gets confused when used
        // here otherwise.
        //private Autofac.IContainer container = ContainerConfig.Configure();

        //public void TestDebug()
        //{
        //    using (var scope = container.BeginLifetimeScope())
        //    {
        //        var app = scope.Resolve<IChecklistRepository>();
        //        //app.CreateNewChecklist("Pre-skate checklist");
        //    }
        //}

        #endregion
        //private IChecklistService _checklistService;

        public MainViewModel(IChecklistRepository checklistRepository, IChecklistService checklistService)
        {
            _checklistRepository = checklistRepository;
            _checklistService = checklistService;


            //var container = ContainerConfig.Configure();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var _checklistService = scope.Resolve<IChecklistService>();
            //}
        }

        #region Application wide ICommands

        /// <summary>
        /// Command to open a specific checklist by double clicking on it in
        /// OutsideView.
        /// </summary>
        public ICommand DoubleClickCommand
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
                            // TODO: Clean this up.  Fix bug that only lets you
                            // click on text instead of whole row in
                            // OutsideView.xaml
                            SelectedViewModel = new InsideViewModel((OutsideViewModel)SelectedViewModel);
                        }
                        catch (System.NullReferenceException)
                        {
                            Console.WriteLine("NullReferenceException");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception encountered: ");
                            Console.Write(e);
                        }
                    }
                };
            }
        }

        public ICommand NewChecklistCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => true,
                    CommandAction = () =>
                    {
                        //TestDebug();
                    }
                };
            }
        }
        #region Debug ICommands

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
                        SelectedViewModel = new OutsideViewModel(_checklistService);
                    }
                };
            }
        }
        #endregion

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
