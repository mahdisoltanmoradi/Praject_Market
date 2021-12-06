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
    public class BlogComments:BaseEntity<int>
    {
        public BlogComments()
        {
            IsActive = true;
            IsDelete = false;
            CreateDate = DateTime.Now;
        }

        [Display(Name = "متن")]
        public string Text { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "حذف شده؟")]
        public bool IsDelete { get; set; }

        [Display(Name = "تاریخ")]
        public DateTimeOffset CreateDate { get; set; }
        public Nullable<int> Reply_id { get; set; }
        public int User_id { get; set; }
        public int Blog_id { get; set; }
        public virtual BlogComments ReplyComment { get; set; }
        public Blogs Blogs { get; set; }
        public virtual ICollection<BlogComments> Children { get; set; }
        public User.User User { get; set; }
    }
    public class BlogCommentsConfiguration : IEntityTypeConfiguration<BlogComments>
    {
        public void Configure(EntityTypeBuilder<BlogComments> builder)
        {
            builder.HasQueryFilter(p => p.IsDelete == false);

            builder.HasOne(x => x.ReplyComment)
           .WithMany(x => x.Children)
           .HasForeignKey(x => x.Reply_id);

            builder.HasOne(x => x.User)
           .WithMany(x => x.BlogComments)
           .HasForeignKey(x => x.User_id);

            builder.HasOne(x => x.Blogs)
           .WithMany(x => x.BlogComments)
           .HasForeignKey(x => x.Blog_id);
        }
    }
}
