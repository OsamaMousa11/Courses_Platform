

namespace CoursePlatform.Infrastructure.Configuration
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            // تحديد المفتاح المركب
            builder.HasKey(f => new { f.User_Id, f.Course_Id });

            // تكوين العلاقة مع User مع استخدام ClientSetNull بدلاً من Cascade
            builder.HasOne(f => f.Users)
                   .WithMany(u => u.Favorites)
                   .HasForeignKey(f => f.User_Id)
                   .OnDelete(DeleteBehavior.ClientSetNull); // تغيير هنا

            // تكوين العلاقة مع Course مع استخدام ClientSetNull بدلاً من Cascade
            builder.HasOne(f => f.Courses)
                   .WithMany(c => c.Favorites)
                   .HasForeignKey(f => f.Course_Id)
                   .OnDelete(DeleteBehavior.ClientSetNull); // تغيير هنا

            // تحديد اسم الجدول
            builder.ToTable("Favourites");
        }
    }
}