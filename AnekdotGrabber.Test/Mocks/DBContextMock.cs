using AnekdotGrabber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnekdotGrabber.Model;
using System.Data.Entity;
using AnekdotGrabber.Test.Mocks.EF;

namespace AnekdotGrabber.Test.Mocks
{
    class DBContextMock : IAppDbContext
    {
        public int SaveChangesCount { get; private set; }
        public DbSet<Story> Stories { get; set; }

        public DBContextMock()
        {
            this.Stories = new TestDbSet<Story>();
        }


        public int SaveChanges()
        {
            this.SaveChangesCount++;
            return 1;
        }
    }
}
