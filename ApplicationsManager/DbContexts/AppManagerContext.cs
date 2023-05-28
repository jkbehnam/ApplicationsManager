using ApplicationsManager.Entitiy;
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
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<ApplicationVersion> ApplicationVersions { get; set; }

        public DbSet<User> Users { get; set; }


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
           new Customer { OwnerName = "احمدی", MarketName = "خوارو بار فروشی احمدی", State = "کرمان", City = "کرمان",BarnchName="مطهری", Mobile = "09364142953" },
           new Customer { OwnerName = "اکبری", MarketName = "سوپرمارکت احد", State = "کرمان", City = "کرمان", BarnchName = "مطهری", Mobile = "09364142953" },
           new Customer { OwnerName = "صالحی", MarketName = "سوپرمارکت صالحی", State = "تهران", City = "تهران", BarnchName = "مطهری", Mobile = "09364142953" });

            modelBuilder.Entity<ApplicationVersion>().HasData(
                new ApplicationVersion { Id = 1, name = "13.2.1", code = 1, IsCritical = false, ApplicationEName = "47" },
                new ApplicationVersion { Id = 2, name = "14.2.1", code = 2, IsCritical = false, ApplicationEName = "47" }

                );

            modelBuilder.Entity<ApplicationType>().HasData(
            new ApplicationType { Id = 1,AppEName= "47", Name = "صندوقک" },
            new ApplicationType { Id = 2, AppEName = "41", Name = "ویژیتو" },
            new ApplicationType { Id = 3, AppEName = "52", Name = "سفارشگیر" });

            //modelBuilder.Entity<Subscription>().HasData(
            //new Subscription { Id = 1, planId = 1, ApplicationTypeId = 1, CustomerId = 1, StartTime = new DateTime(2023, 05, 10), EndTime = new DateTime(2023, 05, 15), IsActive = true });

            modelBuilder.Entity<SubscriptionPlan>().HasData(
           new SubscriptionPlan { Id = 1, Name = "ده روزه", Days = 10 },
           new SubscriptionPlan { Id = 2, Name = "یکماهه", Days = 30});

            modelBuilder.Entity<User>().HasData(
                 new User { Id = Guid.NewGuid(), FName = "حمید", LName = "اکبری", Username = "hamid", Password = "123456", Role = UserRole.User },
                new User { Id = Guid.NewGuid(), FName = "میلاد", LName = "انجم شعاع", Username = "milad", Password = "123456", Role = UserRole.Admin }
                );
        }
    }
}
