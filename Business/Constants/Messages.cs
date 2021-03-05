using Core.Entities.Concrete;
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

        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string UserRegistered = "Kayıt olundu.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "token oluşturuldu";
    }
}
