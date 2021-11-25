using Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductCategory:BaseEntity<int>
    {

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string GroupTitle { get; set; }
    
        [Display(Name ="تصویر گروه محصول")]
        public string ImageProduct { get; set; }

        [Display(Name = "حذف شده ؟")]
        public bool IsDelete { get; set; }

        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public List<ProductCategory> productCategorie { get; set; }

        [InverseProperty("SubCategories")]
        public List<Product> SubCategory { get; set; }

        [InverseProperty("Category")]
        public List<Product> Category { get; set; }
    }
}
