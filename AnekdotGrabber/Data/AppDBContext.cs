using AnekdotGrabber.Interfaces;
using AnekdotGrabber.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Data

{
    class AppDBContext : DbContext, IAppDbContext
    {
        public DbSet<Story> Stories { get; set; }
        public AppDBContext() : base("StoryBase") 
        {
        }
    }
}
