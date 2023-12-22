using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsolUygulamasi
{
    //##  TİP TANIMLARI  ----------  ----------  ----------  ----------
    #region deligate tanımları
    public delegate void fonksiyonListesi(int fonksiyonNumarasi);  //  yapılacak aksiyon
    public delegate void bilgiFonksiyonu();  //  yazdırılacak önbilgi
    #endregion

    public class Menu
    {

        //##  ALANLAR  ----------  ----------  ----------  ----------
        
        List<string> _secenekler = new List<string>();  //  seçenekler string listesi

        #region menü fonksiyonları
        public fonksiyonListesi fonksList;
        public bilgiFonksiyonu menuBilgisi;
        #endregion


        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        public string Baslik { get; protected set; }  //  menü başlığına erişim
        public int SecenekSayisi { get => _secenekler.Count;  }  //  seçenek sayısını dinamik olarak verir


        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        #region oluşturucular
        private Menu() { }

        private Menu(string baslik) => Baslik = baslik;   //  asıl oluşturucu
        #endregion



        //##  METODLAR  ----------  ----------  ----------  ----------

        #region Yaratıcı fonksiyonlar
        public static Menu Yarat(string baslik, string[] secenekler)
        {  //  sadece menü ana hattını yaratır
            Menu temp = new Menu(baslik);  //  menuyu yarat
            temp.SecenekEkle(secenekler);  //  seceneklerini ekle
                return temp;
        }  //  instance dönderen yaratıcı fonksiyon

        public static Menu Yarat(string baslik, string[] secenekler, fonksiyonListesi fonksList)
        {  //  ana menüyü yaratır, seçenekler fonksiyonunu ekler
            Menu temp = new Menu(baslik);  //  menuyu yarat
            temp.SecenekEkle(secenekler);  //  seceneklerini ekle
            temp.fonksList = fonksList;  //  seceneklerin uygulayacağı aksiyonları ekle
                return temp;
        }  //  instance dönderen yaratıcı fonksiyon

        public static Menu Yarat(string baslik, string[] secenekler, fonksiyonListesi fonksList, bilgiFonksiyonu bilgiFonks)
        {  //  ana menüyü yaratır, secenekler fonksiyonunu ekler, bilgi fonksiyonunu ekler
            Menu temp = new Menu(baslik);  //  menuyu yarat
            temp.SecenekEkle(secenekler);  //  seceneklerini ekle
            temp.fonksList = fonksList;  //  seceneklerin uygulayacağı aksiyonları ekle
            temp.menuBilgisi = bilgiFonks;  // menunun başında sergilenecek bilgileri ekle
                return temp;
        }  //  instance dönderen yaratıcı fonksiyon

        #endregion

        private void SecenekEkle(string[] secenekler)
        { foreach (string secenek in secenekler) _secenekler.Add(secenek); }  //  seçenek dizisini menüye ekler

        public void SecimYap(int secim) => fonksList(secim);  // menüye bağlı menü fonksiyonundan seçim yapar

        #region yazdırma fonksiyonları
        public void yazdir()
        {  
            Console.Clear();  //  gelecek menü 
            Console.WriteLine(Baslik);  //  menü girişine başlığı yazdırır
            bilgiYazdir();  //varsa bilgi fonksiyonunu aktive eder ve bilgiyi yazdırır
            int secenekNumarasi = 0;

            foreach (string secenek in _secenekler)
            {
                secenekNumarasi++;  //  seçenek öncesinde numarasını arttır
                Console.WriteLine(secenekNumarasi + " " + secenek);
            }  //  seçenekleri yazdıran döngü
        }  //  menü seçeneklerini ekrana yazdırır
        public void bilgiYazdir()
        { if (menuBilgisi != null) menuBilgisi(); }  // eğer varsa menüye ait menü fonksiyonunu aktive eder
        #endregion

    }  //  Menu sınıfı sonu
}  //  KonsolUygulamasi namespace sonu
