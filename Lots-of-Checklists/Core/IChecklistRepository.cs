using Lots_of_Checklists.Models;

namespace Lots_of_Checklists.Core
{
    public interface IChecklistRepository
    {
        Checklist Get(int checklistID);
    }
}