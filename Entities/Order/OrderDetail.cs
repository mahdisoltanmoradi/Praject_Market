﻿using Entities.Catalogs;
using Entities.Common;

namespace Entities.Order
{
    public class OrderDetail : BaseEntity<int>
    {
        public CatalogItem CatalogItem { get; set; }
        public int CatalogItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
        public int UnitPrice { get; private set; }
        public int Units { get; private set; }
        public OrderDetail(int catalogItemId, string productName, string pictureUri, int unitPrice, int units)
        {
            CatalogItemId = catalogItemId;
            ProductName = productName;
            PictureUri = pictureUri;
            UnitPrice = unitPrice;
            Units = units;
        }


        //ef core
        public OrderDetail()
        {

        }

    }
}
