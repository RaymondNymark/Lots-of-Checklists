using Lots_of_Checklists.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Lots_of_Checklists.Core
{
    public class ChecklistService : IChecklistService
    {
        IChecklistRepository _checklistRepository;

        public ChecklistService(IChecklistRepository checklistRepository)
        {
            _checklistRepository = checklistRepository;
        }

        public DbSet<Checklists> Checklists
        {
            get => _checklistRepository.GetChecklistsDbSet();
        }

        public void MarkChecklistAsDeleted(int checklistID)
        {
            _checklistRepository.Get(checklistID).IsDeleted = true;
        }


    }
}
