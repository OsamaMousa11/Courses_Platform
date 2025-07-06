using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.Domain.RepositoryContract
{
     public  interface IFavouriteRepository
    {
        Task Add(Favorite favorite);
        Task<bool> Exists(Guid userId, Guid courseId);
        Task<List<Favorite>> GetUserFavourites(Guid userId);

        Task Remove(Guid userId, Guid courseId);
    }
}
