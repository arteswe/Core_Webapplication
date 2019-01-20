using Microsoft.EntityFrameworkCore;

namespace BloodpressureApp.Entities
{
    public class BloodPressureInfoContext : DbContext
    {
        public BloodPressureInfoContext( DbContextOptions<BloodPressureInfoContext> options) : 
            base(options)
        {
            Database.Migrate();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Bloodpressure> Bloodpressures { get; set; }
        public DbSet<Weight> Weight { get; set; }

        
    }
}
