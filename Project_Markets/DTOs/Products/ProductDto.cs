using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Entities.Product;
using infrastructure.WebFramework.BaseModel;
using Microsoft.AspNetCore.Http;

namespace Project_Markets.DTOs.Products
{
    public class ProductDto:BaseDto<ProductDto,Entities.Product.Product, int>
    {
        [Display(Name ="دسته بندی")]
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

        [Display(Name = "امتیاز محصول")]
        public Rank ScoreProduct { get; set; }

        [Display(Name ="کلمه کلیدی")]
        [MaxLength(600)]
        public string Tags { get; set; }

        [Display(Name = "فایل ازمایشی")]
        [MaxLength(100)]
        public string DemoFileName { get; set; }

        [Display(Name = "تصویر محصول")]
        [MaxLength(50)]
        public string ProductImageName { get; set; }
        public List<IFormFile> ImageFile { get; set; } // فایل آپلودی
    }

    public class SelectProductDto : BaseDto<SelectProductDto,Entities.Product.Product, int>
    {
        [Display(Name = "دسته بندی")]
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

        [Display(Name = "امتیاز محصول")]
        public Rank ScoreProduct { get; set; }

        [Display(Name = "کلمه کلیدی")]
        [MaxLength(600)]
        public string Tags { get; set; }

        [Display(Name = "تصویر محصول")]
        [MaxLength(50)]
        public string ProductImageName { get; set; }

        [Display(Name = "فایل ازمایشی")]
        [MaxLength(100)]
        public string DemoFileName { get; set; }

        [Display(Name = "دسته بندی محصول")]
        public string GroupTitle { get; set; }

        public override void CustomMappings(IMappingExpression<Entities.Product.Product, SelectProductDto> mapping)
        {
            mapping.ForMember(c => c.GroupTitle, config => config.MapFrom(c => c.ProductCategories.GroupTitle));
        }
    }
}
