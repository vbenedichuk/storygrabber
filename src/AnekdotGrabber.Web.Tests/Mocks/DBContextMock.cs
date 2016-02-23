using AnekdotGrabber.Model;
using System.Data.Entity;
using Com.Benedichuk.Testing.EF;
using AnekdotGrabber.Web.Models;
using System.Collections.Generic;

namespace AnekdotGrabber.Test.Mocks
{
    class DBContextMock : IApplicationDbContext
    {
        public int SaveChangesCount { get; private set; }
        public DbSet<Story> Stories { get; set; }
        public DBContextMock()
        {
            this.Stories = new TestDbSet<Story>();
        }
        public DBContextMock(IEnumerable<Story> stories):this()
        {
            (this.Stories as TestDbSet<Story>).AddRangeForTest(stories);
        }
        public int SaveChanges()
        {
            this.SaveChangesCount++;
            (Stories as TestDbSet<Story>).SaveChanges();
            return 1;
        }
    }
}
