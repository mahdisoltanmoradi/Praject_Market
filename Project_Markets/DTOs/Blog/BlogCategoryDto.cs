using Entities.Blog;
using infrastructure.WebFramework.BaseModel;
using System.ComponentModel.DataAnnotations;

namespace Project_Markets.DTOs.Blog
{
    public class BlogCategoryDto : BaseDto<BlogCategoryDto, BlogCategories, int>
    {
        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "نمایش داده شود؟")]
        public bool IsActive { get; set; }
    }
}
