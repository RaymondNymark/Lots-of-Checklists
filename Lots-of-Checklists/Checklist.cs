using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lots_of_Checklists
{
    public partial class Checklist
    {
        public Checklist()
        {
            this._checklistItems = new HashSet<ChecklistItem>();
        }

        public readonly int _checklistID;
        public string _checkListName { get; set; }

        public ICollection<ChecklistItem> _checklistItems { get; set; }
        //DB connection
    }
}
