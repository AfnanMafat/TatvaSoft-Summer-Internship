﻿using Mission.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mission.Entities.Context
{
    public class MissionDbContext : DbContext
    {
        public MissionDbContext(DbContextOptions<MissionDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Tatva",
                LastName = "Admin",
                EmailAddress = "admin@tatvasoft.com",
                UserType = "admin",
                Password = "Tatva@123",
                PhoneNumber = "9876543210",
                CreatedDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            base.OnModelCreating(builder);
        }
    }

}
