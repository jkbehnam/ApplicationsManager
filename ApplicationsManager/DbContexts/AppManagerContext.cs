﻿using ApplicationsManager.Entitiy;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsManager
{
    public class AppManagerContext : DbContext

    {
        public AppManagerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ApplicationType> ApplicationTypes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionActivity> SubscriptionActivities { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<ApplicationVersion> ApplicationVersions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Subscription>()
            //    .HasKey(ua => new { ua.Id });

            //modelBuilder.Entity<Subscription>()
            //    .HasOne(ua => ua.Customer)
            //    .WithMany(u => u.Subscriptions)
            //    .HasForeignKey(ua => ua.CustomerId);

            //modelBuilder.Entity<Subscription>()
            //    .HasOne(ua => ua.ApplicationType)
            //    .WithMany(a => a.Subscriptions)
            //    .HasForeignKey(ua => ua.ApplicationTypeId);

            modelBuilder.Entity<Customer>().HasData(
           new Customer { Id = 1, Name = "احمدی", Username = "ahmadi", Password = "123456", Mobile = "09364142953" },
           new Customer { Id = 2, Name = "اکبری", Username = "akbari", Password = "123456", Mobile = "09364142953" },
           new Customer { Id = 3, Name = "حسینی", Username = "hosseini", Password = "123456", Mobile = "09364142953" });

            modelBuilder.Entity<ApplicationType>().HasData(
            new ApplicationType { Id = 1, Name = "صندوقک" },
            new ApplicationType { Id = 2, Name = "ویژیتو" },
            new ApplicationType { Id = 3, Name = "سفارشگیر" });

            modelBuilder.Entity<Subscription>().HasData(
            new Subscription { Id = 1, planId = 1, ApplicationTypeId = 1, CustomerId = 1, StartTime = new DateTime(2023, 05, 10), EndTime = new DateTime(2023, 05, 15), IsActive = true });

            modelBuilder.Entity<SubscriptionPlan>().HasData(
           new SubscriptionPlan { Id = 1, Name = "ده روزه",Days=10,MaxUsers=5 },
           new SubscriptionPlan { Id = 2, Name = "یکماهه", Days = 30, MaxUsers = 5 });
        }
    }
}