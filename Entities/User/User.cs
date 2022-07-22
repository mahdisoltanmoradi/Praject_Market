using Entities.Blog;
using Entities.Common;
using Entities.Notification;
using Entities.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.User
{
    public class User:IdentityUser<int>,IEntity
    {
        public User()
        {
            IsActive = true;
        }

        [Display(Name = "محل سکونت")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string lifeLocation { get; set; }

        [Display(Name = "کد فعال سازی")]
        [MaxLength(50, ErrorMessage = "{0}نمیتواند بیشتر از {1}کراکتر باشد.")]
        public string ActiveCode { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "عکس کاربر")]
        public string UserAvatar { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }

        public bool IsDelete { get; set; }

        #region Relation
        public List<ProductComment> ProductComment { get; set; }
        public List<BlogComments> BlogComments { get; set; }
        public virtual List<Wallet.Wallet> Wallets { get; set; }
        public ICollection<UserNotification> UserNotifications { get; set; }
        #endregion
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(200);
        }
    }
}

