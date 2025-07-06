using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.Service
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _repository;

        public FavouriteService(IFavouriteRepository repository)
        {
            _repository = repository;
        }

        public async Task AddToFavourite(Guid userId, Guid courseId)
        {
            bool alreadyExists = await _repository.Exists(userId, courseId);
            if (alreadyExists)
                return;

            var fav = new Favorite
            {
                User_Id = userId,
                Course_Id = courseId
            };

            await _repository.Add(fav);
        }

        public async Task<List<FavouriteResponse>> GetUserFavourites(Guid userId)
        {
            var favorites = await _repository.GetUserFavourites(userId);
            return favorites.ToFavouriteResponseList();
        }

  
        public async Task<List<Guid>> GetUserFavoriteCourseIds(Guid userId)
        {
            var favorites = await _repository.GetUserFavourites(userId);
            return favorites.Select(f => f.Course_Id).ToList();
        }
        public async Task RemoveFromFavourite(Guid userId, Guid courseId)
        {
            await _repository.Remove(userId, courseId);
        }
    }
}
