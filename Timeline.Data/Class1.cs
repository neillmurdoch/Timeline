using Microsoft.EntityFrameworkCore;
using System;

namespace Timeline.Data
{
    public class TimelineDbContext : DbContext
    {
        public TimelineDbContext(DbContextOptions<TimelineDbContext> options)
            : base(options)
        {

        }

        public DbSet<>
    }
}
