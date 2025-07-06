using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Infrastructure.Repositories
{
    public  class FavouriteRepository:IFavouriteRepository
    {

        private readonly AppDbContext _context;

        public FavouriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(Guid userId, Guid courseId)
        {
            return await _context.Favorites
                .AnyAsync(f => f.User_Id == userId && f.Course_Id == courseId);
        }

        public async Task<List<Favorite>> GetUserFavourites(Guid userId)
        {
            return await _context.Favorites
                .Where(f => f.User_Id == userId)
                .Include(f => f.Courses)
                    .ThenInclude(c => c.Category)
                .ToListAsync();
        }
        public async Task Remove(Guid userId, Guid courseId)
        {
            var fav = await _context.Favorites
                .FirstOrDefaultAsync(f => f.User_Id == userId && f.Course_Id == courseId);

            if (fav != null)
            {
                _context.Favorites.Remove(fav);
                await _context.SaveChangesAsync();
            }
        }

    }
}
