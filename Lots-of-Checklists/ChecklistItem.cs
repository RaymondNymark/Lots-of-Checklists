using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lots_of_Checklists
{
    public partial class ChecklistItem
    {
        public int _checkListItemID;
        public string _checkListItemName;
        public bool _checkListItemIsChecked;

        public int ChecklistID;
        public Checklist Checklist;

    }
}
