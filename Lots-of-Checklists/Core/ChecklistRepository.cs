using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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



        #region CRUD operations

        #region Creation
        /// <summary>
        /// Create a new generic default checklist named "New checklist".
        /// </summary>
        public void CreateChecklist()
        {
            try
            {
                var newDefaultChecklist = new Checklists() { Name = "New checklist" };
                _dbContext.Checklists.Add(newDefaultChecklist);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("Unable to access dbContext.");
            }
        }

        /// <summary>
        /// Create a new checklist with a non generic name.
        /// </summary>
        /// <param name="checklistName">Name of the new checklist</param>
        public void CreateChecklist(string checklistName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a new checklist into the database by passing an already
        /// instantiated checklist in.
        /// </summary>
        /// <param name="checklist">Checklist to pass in</param>
        public void CreateChecklist(Checklists checklist)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Reading
        public ObservableCollection<Checklists> GetChecklistsCollection()
        {
            return _dbContext.Checklists.Local;
        }

        public DbSet<Checklists> GetChecklistsDbSet()
        {
            return _dbContext.Checklists;
        }

        public Checklists Get(int checklistID)
        {
            return _dbContext.Set<Checklists>().Find(checklistID);
        }
        #endregion

        #region Updating
        //
        #endregion

        #region Deletion
        /// <summary>
        /// Realistically this should probably never be used. Instead mark
        /// checklist as deleted.
        /// </summary>
        /// <param name="checklistID">Checklist ID column</param>
        public void DeleteChecklist(int checklistID)
        {
            try
            {
                var selectedChecklist = _dbContext.Checklists.Where(c => c.ChecklistID == checklistID).FirstOrDefault();
                if (selectedChecklist.ChecklistID == checklistID)
                {
                    _dbContext.Checklists.Remove(selectedChecklist);
                    _dbContext.SaveChanges();
                }
                // TODO: Implement better exception handling in case ID is not
                // found.
            }
            catch
            {
                throw new ArgumentException(checklistID.ToString());
            }
        }

        public void DeleteChecklist(string name)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        //public Checklists Get(int checklistID)
        //{
        //    return _dbContext.Set<Checklists>().Find(checklistID);
        //}

        //public void CreateNewChecklist(string name)
        //{
        //    try
        //    {
        //        _dbContext.Checklists.Add(new Checklists { Name = name });
        //        _dbContext.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new ArgumentException("Unable to access dbContext");
        //    }
        //}

        //public void DeleteChecklist(int checklistID)
        //{
        //    try
        //    {
        //        var checklist = _dbContext.Set<Checklists>().Find(checklistID);
        //        // Avoid actually deleting things for now.
        //        checklist.IsDeleted = true;
        //        _dbContext.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new ArgumentException("Unable to find checklistID");
        //    }

        //}
    }
}
