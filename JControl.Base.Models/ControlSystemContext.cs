

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace JControl.Base.Models
{
    public class ControlSystemContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory) //Logger
                .UseSqlServer(
                connectionString: "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=BaseDb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CateoryEntity>()
            //    .HasMany(x => x.Devices)
            //    .WithOne(y => y.Cateory);

            modelBuilder.Entity<ProductEntity>()
                .HasMany(b => b.ProductPorts)
                .WithOne(c => c.ParentProduct);

            modelBuilder.Entity<ProductEntity>()
                .HasMany(b => b.RoomDevices)
                .WithOne(c => c.Product);

            modelBuilder.Entity<PortCateoryEntity>()
                .HasMany(b => b.ProductPorts)
                .WithOne(c => c.PortCateory);

        }
        //根据项目需要添加

        public DbSet<RoomDeviceEntity>  RoomDevices { get; set; }
        public DbSet<ProductEntity> Devices { get; set; }
        //public DbSet<CateoryEntity> Cateories { get; set; }
        public DbSet<RouterLinkEntity> Routers { get; set; }

        public DbSet<ProductPortEntity> ProductPorts { get; set; }

        public DbSet<PortCateoryEntity> PortCateories { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory =
            LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                   .AddConsole();


            });
    }
}
