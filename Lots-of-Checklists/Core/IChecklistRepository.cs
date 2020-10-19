using Lots_of_Checklists.Models;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace Lots_of_Checklists.Core
{
    public interface IChecklistRepository
    {
        void CreateChecklist();
        void CreateChecklist(Checklists checklist);
        void CreateChecklist(string checklistName);
        void DeleteChecklist(int checklistID);
        void DeleteChecklist(string name);
        Checklists Get(int checklistID);
        ObservableCollection<Checklists> GetChecklistsCollection();
        DbSet<Checklists> GetChecklistsDbSet();
    }
}