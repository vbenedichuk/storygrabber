using AnekdotGrabber.Model;
using System.Data.Entity;

namespace AnekdotGrabber.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Story> Stories { get; set; }
        int SaveChanges();
    }
}
