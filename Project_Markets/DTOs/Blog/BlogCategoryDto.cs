using System.ComponentModel.DataAnnotations;
using Entities.Blog;
using infrastructure.WebFramework.BaseModel;
using Microsoft.AspNetCore.Http;

namespace Project_Markets.DTOs.Blog
{
    public class BlogCategoryDto : BaseDto<BlogCategoryDto, BlogCategories, int>
    {
        [Display(Name = "عنوان")]
        [Required]
        public string BlogCategoryTitle { get; set; }

        [Display(Name = "نمایش داده شود؟")]
        public bool IsActive { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
