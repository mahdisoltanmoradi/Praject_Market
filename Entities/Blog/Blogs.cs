using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Blog
{
    public class Blogs:BaseEntity<int>
    {
        public Blogs()
        {
            IsDelete = false;
            IsActive = true;
            CreateDate = DateTime.Now;
        }
        [Display(Name = "عنوان")]
        public string BlogTitle { get; set; }

        [Display(Name = "متن")]
        public string Text { get; set; }


        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "کدام دسته بندی")]
        public int Category_id { get; set; }

        [Display(Name = "حذف شده؟")]
        public bool IsDelete { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTimeOffset CreateDate { get; set; }

        public BlogCategories Category { get; set; }
        public ICollection<BlogComments> BlogComments { get; set; }

    }
    public class BlogsConfiguration : IEntityTypeConfiguration<Blogs>
    {
        public void Configure(EntityTypeBuilder<Blogs> builder)
        {
            builder.HasOne(c => c.Category).WithMany(c => c.Blogs).HasForeignKey(c => c.Category_id);
            builder.HasQueryFilter(f => !f.IsDelete);
        }
    }
}
