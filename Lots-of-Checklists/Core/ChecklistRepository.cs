using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lots_of_Checklists.Models;

namespace Lots_of_Checklists.Core
{
    public class ChecklistRepository : IChecklistRepository
    {
        private readonly LotsOfChecklistsContext _dbContext;

        public ChecklistRepository(LotsOfChecklistsContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            _dbContext = dbContext;
        }

        public Checklists Get(int checklistID)
        {
            return _dbContext.Set<Checklists>().Find(checklistID);
        }

        public void CreateNewChecklist(string name)
        {
            try
            {
                _dbContext.Checklists.Add(new Checklists { Name = name });
            }
            catch
            {
                throw new ArgumentException("Unable to access dbContext");
            }
        }

        public void DeleteChecklist(int checklistID)
        {
            try
            {
                var checklist = _dbContext.Set<Checklists>().Find(checklistID);
                // Avoid actually deleting things for now.
                checklist.IsDeleted = true;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("Unable to find checklistID");
            }

        }
    }
}
