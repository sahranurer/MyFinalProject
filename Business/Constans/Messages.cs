using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductListed = "Ürünler Listelendi";

        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductCountOdCategory = "Bir ürün en fazla 10 tane olabilir.";
        public static string ProductNameAlreadyExists="Böyle bir isim var.Tekrar eklenmez";
        public static string CategoryLimitexceded = "Kategori limiti aşıldı";
        public static string AuthorizationDenied="yetkiniz yok";
        public static string UserRegistered="Kayıt Oldu.";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError="Parola Hatası";
        public static string SuccessfulLogin="Başarılı Giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut";

        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
