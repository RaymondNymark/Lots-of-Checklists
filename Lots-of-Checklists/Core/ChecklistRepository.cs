using System;
using System.Collections.Generic;
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

        public Checklist Get(int checklistID)
        {
            return _dbContext.Set<Checklist>().Find(checklistID);
        }
    }
}
