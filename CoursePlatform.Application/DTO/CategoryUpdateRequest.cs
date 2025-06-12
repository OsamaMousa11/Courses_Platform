
namespace CoursePlatform.Core.DTO
{
    public class CategoryUpdateRequest
    {
        public Guid Id{ get; set; }
        [Required(ErrorMessage = "Category name can't be blank")]
        public string? Name { get; set; }

        public Category ToCategory()
        {
              return new Category
            {
                Id = Id,
                Name = Name
            };
        }

    }
}
