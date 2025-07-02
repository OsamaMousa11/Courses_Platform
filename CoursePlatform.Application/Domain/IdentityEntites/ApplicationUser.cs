
using Microsoft.AspNetCore.Identity;


namespace CoursePlatform.Core.Domain.IdentityEntites
{
    public  class ApplicationUser:IdentityUser<Guid>
    {

       // public Guid? FavouriteID { get; set; }
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
 