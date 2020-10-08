using Lots_of_Checklists.Models;

namespace Lots_of_Checklists.Core
{
    public interface IChecklistRepository
    {
        void CreateNewChecklist(string name);
        void DeleteChecklist(int checklistID);
        Checklists Get(int checklistID);
    }
}