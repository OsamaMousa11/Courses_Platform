using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Infrastructure.Configration
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
      
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Role).IsRequired();


            builder.HasMany(u => u.Favorites)
               .WithOne(f => f.Users)
               .HasForeignKey(f => f.User_Id).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
