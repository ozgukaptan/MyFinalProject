using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        // publicler pascal case yazılır
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda" ;
        public static string ProductListed = "Ürünler Listelendi";
        public static string UnitPriceInvalid = "Geçersiz fiyat";

        public static string PrpductCountOfCategoryError = "Bir kategoride 10 ürü nolabilir";

        public static string PrpductNameAlreadyExist = "aynı isimli ürü olmaz.";

        public static string CategoryLimitExceded = "Category limit";
    }
}
