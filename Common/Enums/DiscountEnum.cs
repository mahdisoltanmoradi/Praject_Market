using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum DiscountType
    {
        [Display(Name = "تخفیف برای محصولات")]
        AssignedProduct = 1,
        [Display(Name = "تخفیف برای دسته بندی")]
        AssignedToCategories = 2,
        [Display(Name = "تخفیف برای مشتری")]
        AssignedToUser = 3,
        [Display(Name = "تخفیف برای برند")]
        AssignedToBrand = 3,
    }

    /// <summary>
    ///  محدودیت تعداد استفاده
    /// </summary>
    public enum DiscountLimitationType
    {
        /// <summary>
        /// بدونه محدودیت تعداد
        /// </summary>
        [Display(Name = "بدونه محدودیت تعداد")]
        Unlimited = 0,
        /// <summary>
        /// فقط N بار
        /// </summary>
        [Display(Name = "فقط N بار")]
        NTimesOnly = 1,
        /// <summary>
        /// N بار به ازای هر مشتری
        /// </summary>
        [Display(Name = "N بار به ازای هر مشتری")]
        NTimesPerCustomer = 2,
    }
}
