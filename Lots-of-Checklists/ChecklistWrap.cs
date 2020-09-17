using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lots_of_Checklists
{
    public class ChecklistWrap : Checklist, INotifyPropertyChanged
    {
        private string _description;
        public new string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        // TODO: Implement ObservableItemCollection property. Currently testing main attributes to make sure it works.
        


        // Context related things:




        #region INotifyPropertyChangedLocalImplementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
        #endregion
    }
}

