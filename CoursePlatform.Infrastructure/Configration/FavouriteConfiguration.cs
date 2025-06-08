
namespace CoursePlatform.Infrastructure.Configuration
{
    public class FavouriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            
            builder.HasKey(f => new { f.User_Id, f.Course_Id });

           
            builder.HasOne(f => f.Users)
                   .WithMany(u => u.Favorites)
                   .HasForeignKey(f => f.User_Id)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(f => f.Courses)
                   .WithMany(c => c.Favorites)
                   .HasForeignKey(f => f.Course_Id)
                   .OnDelete(DeleteBehavior.Restrict);;

            
            builder.ToTable("Favourites");
        }
    }
}