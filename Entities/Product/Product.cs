using Entities.Common;
using Entities.Order;
using Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Product
{
    public class Product : BaseEntity<int>
    {
        public int CategoryId { get; set; }

        [Display(Name = "وضعیت")]
        [Required]
        public bool Status { get; set; }


        [Display(Name = "عنوان کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ProductTitle { get; set; }

        [Display(Name = "مشخصات فنی کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductDescription { get; set; }

        [Display(Name = "قیمت کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductPrice { get; set; }

        [Display(Name = "قیمت قبل کالا")]
        public int DeleteProductPrice { get; set; }

        [Display(Name = "تعداد محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductCount { get; set; }

        [Display(Name = "رنگ کالا")]
        public Color ProductColor { get; set; }

        [Display(Name = "بازدید")]
        public int ProductVisit { get; set; }

        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "سایز کالا")]
        public Size ProductSize { get; set; }

        [Display(Name ="امتیاز محصول")]
        public Rank ScoreProduct { get; set; }

        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string ProductImageName { get; set; }

        [MaxLength(100)]
        public string DemoFileName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        #region Relation

        public ProductCategory ProductCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductComment> ProductComment { get; set; }
        public ICollection<Discount.Discount> Discounts { get; set; }
        #endregion
    }
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ProductCategories).WithMany(x => x.Products).HasForeignKey(x=>x.CategoryId);
        }
    }

    public enum Size
    {
        [Display(Name ="سایز کوچک")]
        Single = 1,
        [Display(Name = "سایز متوسط")]
        medium = 2,
        [Display(Name = "سایز بزرگ")]
        Large = 3
    }

    public enum Color
    {
        [Display(Name = "مشکی")]
        Black = 1,
        [Display(Name = "سفید")]
        White = 2,
        [Display(Name = "زرد")]
        yellow = 3,
        [Display(Name = "سبز")]
        Green = 4
    }

    public enum Rank
    {
        [Display(Name = "خیلی بد")]
        VeryBad = 1,
        [Display(Name = "بد")]
        Bad = 2,
        [Display(Name = "متوسط")]
        Medium = 3,
        [Display(Name = "خوب")]
        Good = 4,
        [Display(Name ="خیلی خوب")]
        VeryGood=5
    }

}
