using Microsoft.EntityFrameworkCore;
using SalamaAssessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
       
        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }


        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch
            {

            } 
        }

    }
}
