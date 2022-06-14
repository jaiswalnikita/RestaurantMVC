using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models
{
    public class ClassContext : DbContext
    {
        public ClassContext(DbContextOptions<ClassContext> options) : base(options)
        {

        }

        public DbSet<RestauranAPI> tblresturent { get; set; }
        public DbSet<PlayerAPI> tblplayer{ get; set; }
        public DbSet<RestaurantPlayerLink> tblmapping { get; set; }
    }
}
