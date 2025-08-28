using System.ComponentModel.DataAnnotations;
using infrastructure.WebFramework.BaseModel;
using Microsoft.AspNetCore.Http;

namespace Project_Markets.DTOs.Product
{
    public class ProductCategoryDto : BaseDto<ProductCategoryDto, Entities.Product.ProductCategory, int>
    {
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string GroupTitle { get; set; }

        [Display(Name = "تصویر گروه محصول")]
        public string ImageProduct { get; set; } // اسم فایل ذخیره شده
        public IFormFile ImageFile { get; set; } // فایل آپلودی

    }
}
