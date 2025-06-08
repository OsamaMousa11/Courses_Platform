
namespace CoursePlatform.Infrastructure.Configration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();


            builder.Property(x => x.DisplayOrder).IsRequired();
            builder.HasCheckConstraint("CK_DisplayOrder_Range", "[DisplayOrder] >= 1 AND [DisplayOrder] <= 50");

            builder.HasIndex(x => x.DisplayOrder).IsUnique();

            builder.HasMany(x => x.Courses).WithOne(g => g.Category).HasForeignKey(g=>g.CategoryId);

            builder.ToTable("Categories");


        }
    }
}
