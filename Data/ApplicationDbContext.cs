using Microsoft.EntityFrameworkCore;
using smarthousedevices.Models;

namespace smarthousedevices.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Device> Devices{ get; set; }
    }
}
