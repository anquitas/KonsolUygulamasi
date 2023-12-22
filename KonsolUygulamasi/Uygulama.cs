using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsolUygulamasi
{
    
    public class Uygulama
    {
        //##  ALANLAR  ----------  ----------  ----------  ---------- 
        #region menü geçmişi kontrolü
        int aktifMenuID = 0;
        List<int> menuNavYigit = new List<int>();  //  menü açılma geçmişi
        #endregion

        List<Menu> _menuler = new List<Menu>();  //  uygulamada kullanılacak menüler
        
        String[] _komutlar = { ":q", ":geri" };  //  navigasyon seçenekleri

 

        //##  NİTELİKLER  ----------  ----------  ----------  ----------
        public string UygulamaIsmi { get; protected set;  }  //  uygulama ismine dışarıdan erişim  //  saltOkunu
        List<Menu> Menuler { get { return _menuler; } }  //  menülere dışarıdan erişim  //  saltOkunur



        //##  OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        #region oluşturucular
        private Uygulama() { }  //  uygulama ismi olmadan
        private Uygulama(string uygulamaIsmi) { this.UygulamaIsmi = uygulamaIsmi; }  //  uygulama ismi ile
        #endregion


        //##  METODLAR  ----------  ----------  ----------  ----------

        #region yapısal
        public static Uygulama yarat() => new Uygulama();  //  instance dönderen yaratıcı fonksiyon
        public void menuEkle(Menu eklenecekMenu) => _menuler.Add(eklenecekMenu);  //  yaratılan menüyü konsol uygulamasına ekler
        #endregion

        #region menü davranışları
        public void basla() => menuyeGit(0);  //  anamenüyü başlatır
        public void menuyuUygula(int menuID)
        {  
            Menuler[menuID].yazdir();
            aktifMenuID = menuID;
            menuNavYigit.Add(menuID);
        }  //  menüyü aktive eder  //yazdirma ve akışa kaydetme
        public void menuyeGit(int menuID)
        {  
            //menuNavYigit.Add(menuID);  
            //aktifMenuID = menuID;
            bool menuyuGoster = true;
            bool komutMu = false;

            while (menuyuGoster)
            {  
                string girdi = "";  //  kullanıcıdan alınacak girdi
                menuyuUygula(menuID);  //  parametre menüyü uygular
                komutMu = komutAl(out girdi);  //  alınan girdi komut mu
                Console.Clear();  //  yapılacak değişiklikten önce menüyü temizler
                if (komutMu == false)  //  komut değilse 
                    secimYap(int.Parse(girdi));  //  istenilen seçimi uygular
                else if (komutMu == true)  // komutsa
                    menuyuGoster = komutUygular(girdi);  //  girilen komutu uygular
            }  //  kapatılmadığı sürece menüyü tekrarlar
        }  //  istenilen menüye navigasyonu sağlar
        public bool komutUygular(string komut)
        {
            switch (komut)
            {
                case "q":
                    Environment.Exit(0);
                    break;
                case "": return false;
                case "geri":
                    return false;
            }
            return true;
        }  //  komutları içeren fonksiyon
        public void secimYap(int secim) => _menuler[aktifMenuID].SecimYap(secim);
        // menüde aksiyon yapılmasını sağlamak için seçim yapar
        #endregion

        #region girdi alma
        public bool komutAl(out string metin)
        {
            string girdi = Console.ReadLine();
            if (girdi[0] == ':')
            {
                //int komutNo = Array.IndexOf(_komutlar, komut);
                metin = girdi.Substring(1);
                return true;
            }
            metin = girdi;
            return false;
        }  //  komutu analiz eder
        #endregion

        #region araç fonksiyonlar
        public static string secimAl(string[] secenekler)
        {   
            int secenekNumarasi = 1;  //  ilk seçeneğe 1 numarasını verir
            foreach (string secenek in secenekler)  
            {
                Console.WriteLine($"{secenekNumarasi} - {secenek}");  // seçeneği yazdırır
                secenekNumarasi++;  // seçenek numarasını sonraki seçenek için arttırır
            }  //  seçenekleri yazdıran döngü
            int secim = Convert.ToInt32(Console.ReadLine());  // konsoldan secimi alır ve int'e çevirir
                return secenekler[secim - 1];  //  seçim numarasına uygun gelen seçimi dönderir
        }  //  dizi kullanarak geçici bir seçim menüsü oluşturur, seçilen seçeneği string olarak dönderir

        public static string girdiAl(string gosterilecekMetin)
        {  //  girdi almak için basit bir fonksiyon
            Console.WriteLine(gosterilecekMetin);
            return Console.ReadLine();
        }  //  soru ile istenilen girdiyi almak için basit static bir araç fonksiyonu
        #endregion

    }  //  Uygulama sınıfı sonu
}  //  KonsolUygulamasi namespace sonu
