using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Blog
{
    public class BlogCategories:BaseEntity<int>
    {
        public BlogCategories()
        {
            IsActive = true;
            CreateDate = DateTime.Now;
        }
        [Display(Name ="گروه دسته بندی")]
        public string BlogCategoryTitle { get; set; }

        [Display(Name = "وضعیت")]
        public  bool IsActive { get; set; }

        [Display(Name = "حذف شده؟")]
        public bool IsDelete { get; set; }

        [Display(Name = "تاریخ ایجادشده")]
        public DateTimeOffset CreateDate { get; set; }

        public ICollection<Blogs> Blogs { get; set; }
    }
    public class BlogCategoriesConfiguration : IEntityTypeConfiguration<BlogCategories>
    {
        public void Configure(EntityTypeBuilder<BlogCategories> builder)
        {
            builder.HasQueryFilter(f => !f.IsDelete);
        }
    }
}
