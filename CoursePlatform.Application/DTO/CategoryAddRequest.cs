

using System.ComponentModel.DataAnnotations;


namespace CoursePlatform.Core.DTO
{
    public class CategoryAddRequest
    {   
        [Required(ErrorMessage = "Category name can't be blank")]

        public string? Name { get; set; }


        public Category ToCategory()
        {
            return new Category() { Name=Name };
        }
    }
}
