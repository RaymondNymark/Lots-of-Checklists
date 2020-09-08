using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lots_of_Checklists
{
    public class ChecklistContext : DbContext
    {
        public ChecklistContext() : base()
        {

        }

        public DbSet<Checklist> Checklist { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
    }
}
