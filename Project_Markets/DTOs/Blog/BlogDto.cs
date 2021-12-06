using AutoMapper;
using Entities.Blog;
using infrastructure.WebFramework.BaseModel;
using System.ComponentModel.DataAnnotations;

namespace Project_Markets.DTOs.Blog
{
    public class BlogDto : BaseDto<BlogDto,Blogs, int>
    {
        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "متن")]
        [Required]
        public string Text { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "عنوان گروه")]
        public int Category_id { get; set; }

    }

    public class SelectBlogDto : BaseDto<SelectBlogDto,Blogs, int>
    {
        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "متن")]
        [Required]
        public string Text { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "عنوان گروه")]
        public int Category_id { get; set; }

        [Display(Name = "دسته بندی")]
        public string BlogCategoryTitle { get; set; }

        public override void CustomMappings(IMappingExpression<Blogs, SelectBlogDto> mapping)
        {
            mapping.ForMember(c => c.BlogCategoryTitle, config => config.MapFrom(c => c.Category.BlogCategoryTitle));
        }
    }
}
