
namespace CoursePlatform.Infrastructure.Configration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.DisplayOrder).IsRequired();

            builder.HasMany(x => x.Courses).WithOne(g => g.Category).HasForeignKey(g=>g.CategoryId);

            builder.ToTable("Categories");


        }
    }
}
