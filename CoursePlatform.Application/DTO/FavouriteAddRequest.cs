using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.DTO
{
    public  class FavouriteAddRequest
    {
        [Required(ErrorMessage = "Course  is required")]
        public Guid Course_Id { get; set; }

        public Favorite ToFavourite(Guid userId)
        {
            return new Favorite
            {
                User_Id = userId,
                Course_Id = Course_Id
            };
        }

    }
}
