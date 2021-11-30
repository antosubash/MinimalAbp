
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

public class MyDbContext : AbpDbContext<MyDbContext>
{
        public DbSet<Book> Books => Set<Book>();

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Always call the base method
            base.OnModelCreating(builder);

            builder.Entity<Book>(b =>
            {
                b.ToTable("Books");

                //Configure the base properties
                b.ConfigureByConvention();

                //Configure other properties (if you are using the fluent API)
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });
        }
    }