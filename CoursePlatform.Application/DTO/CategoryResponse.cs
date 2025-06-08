
namespace CoursePlatform.Core.DTO
{
    public  class CategoryResponse
    {   
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int DisplayOrder { get; set; }

        public CategoryUpdateRequest TocategoryUpdateRequest()
        {
            return new CategoryUpdateRequest()
            { Id = Id,
                Name = Name,
            };
        }

    }




    public static class CategoryExtension
    {
        public static CategoryResponse ToCategoryResponse(this Category ctg)
        {
            return new CategoryResponse()
            {
                Id = ctg.Id,
                Name = ctg.Name,
                DisplayOrder = ctg.DisplayOrder
            };
        }
    }
}
