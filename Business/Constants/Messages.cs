using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string addedEntityMessage = "Veri başarı ile eklendi.";
        public static string deletedEntityMessage = "Veri kaydı başarı ile silindi.";
        public static string updatedEntityMessage = "Veri başarı ile güncellendi.";
        public static string priceError = "Aracın fiyatı 0 veya daha küçük olamaz.";
        public static string nameError = "Model isminin uzunluğu minimum iki karakter olmalıdır.";
        public static string notReturnedYet = "Araç şuan kiralanmış durumdadır. Lütfen daha sonra tekrar deneyiniz.";
        public static string notRented = "Girilen bilgiler ile eşleşen bir kiralama verisi bulunmaktadır.";
        public static string imageLimitExceeded = "Seçili araç için yüklenebilecek resim limitine ulaştınız.";
    }
}
