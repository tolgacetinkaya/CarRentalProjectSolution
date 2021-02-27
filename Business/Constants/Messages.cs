using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Yeni bir araç eklendi";
        public static string CarDeleted = "Araç silindi!";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarsListed = "Araçlar listelendi";
        public static string NameInValid = "Ürün ismi geçersizdir. En az 3 karakterden oluşmalıdır";
        public static string DataUpdated = "Güncelleme yapıldı";
        public static string DataDeleted = "Silme işlemi yapıldı";
        public static string UserAdded = "Kullanıcı kaydı oluşturulmuştur";
        public static string UserUpdated = "Kullanıcı bilgileri güncellenmiştir";
        public static string UserDeleted = "Kullanıcınız silinmiştir.";
        public static string CanNotBeRented = "Araç teslim edilmediği için kiralık olarak eklenemez";
        public static string RentalAdded = "Kiralık araçlar listesine eklendi";
        public static string CarImageLimitExceded="Bir arabanın en fazla 5 resmi olabilir";
        public static string CarImageDeleted="Fotoğraf silindi";
        public static string CarIsNotExist="Böyle bir araç yok";
        public static string FileUploadError = "Dosya yükleme hatası";
    }
}
