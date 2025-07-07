using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.ServiceContract
{
    public interface IFavouriteService
    {
        Task AddToFavourite(Guid userId, Guid courseId);
        Task<List<FavouriteResponse>> GetUserFavourites(Guid userId);

        Task<List<Guid>> GetUserFavoriteCourseIds(Guid userId);
        Task RemoveFromFavourite(Guid userId, Guid courseId);

        Task<List<FavouriteResponse>> GetAllFavourites();
    }

}
