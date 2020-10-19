using Lots_of_Checklists.Models;
using System.Data.Entity;

namespace Lots_of_Checklists.Core
{
    public interface IChecklistService
    {
        DbSet<Checklists> Checklists { get; }

        void MarkChecklistAsDeleted(int checklistID);
    }
}