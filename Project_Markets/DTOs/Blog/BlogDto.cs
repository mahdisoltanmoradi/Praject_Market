using AutoMapper;
using Entities.Blog;
using infrastructure.WebFramework.BaseModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Project_Markets.DTOs.Blog
{
    public class BlogDto : BaseDto<BlogDto,Blogs, int>
    {
        [Display(Name = "عنوان")]
        [Required]
        public string BlogTitle { get; set; }

        [Display(Name = "متن")]
        [Required]
        public string Text { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "عنوان گروه")]
        public int Category_id { get; set; }

        public IFormFile ImageBlog { get; set; }

        [Display(Name = "کامنت")]
        public BlogComments Comments { get; set; }


        public override void CustomMappings(IMappingExpression<Blogs, BlogDto> mapping)
        {
            mapping.ForMember(c => c.Comments, config => config.MapFrom(c => c.BlogComments));
        }
    }

    public class SelectBlogDto : BaseDto<SelectBlogDto,Blogs, int>
    {
        [Display(Name = "عنوان")]
        [Required]
        public string BlogTitle { get; set; }

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
