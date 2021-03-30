using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı";
        public static string Updated = "Güncelleme işlemi başarılı";
        public static string Deleted = "Silme işlemi başarılı";
        public static string Listed = "Listeleme işlemi başarılı";
        public static string PriceError = "Hatalı fiyat girildi";
        public static string MaintenanceError = "Sistem bakımda";
        public static string Delivered = "Teslim Edildi";
        public static string CarImageLimitExceded = "Bir araba için 5'ten fazla resim eklenemez";
        public static string AuthorizationDenied = "Yetkiniz yok, yetkilendirme reddedildi";
        public static string UserRegistered = "Kayıt Olundu";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
