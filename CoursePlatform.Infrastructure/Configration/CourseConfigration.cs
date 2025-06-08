
namespace CoursePlatform.Infrastructure.Configration
{
    public class CoursesConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(10,2)");

            builder.Property(x => x.ImageUrl).HasColumnType("VARCHAR(100)").IsRequired();

            builder.Property(x => x.Rating).IsRequired();

            builder.Property(x => x.CreatedAt).HasColumnType("date").IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.Category)
                .WithMany(g => g.Courses)
                .HasForeignKey(g => g.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Favorites)
                   .WithOne(f => f.Courses)
                   .HasForeignKey(f => f.Course_Id).OnDelete(DeleteBehavior.Cascade);



        }   
    }
}
