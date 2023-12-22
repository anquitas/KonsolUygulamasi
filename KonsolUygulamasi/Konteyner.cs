using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsolUygulamasi
{
    internal class Konteyner
    {
        //## NİTELİKLER  ----------  ----------  ----------  ----------  
        public int Genislik {  get; protected set; }
        public int Uzunluk {  get; protected set; }
        public int Baslangic {  get; protected set; }

        public int YatayKapasite { get => Genislik; }
        public int DikeyKapasite { get => Uzunluk; }

        public string[] Icerik;

        //## OLUŞTURUCULAR  ----------  ----------  ----------  ----------

        private Konteyner() { }

        private Konteyner (int uzunluk, int genislik) 
        {
            Uzunluk = uzunluk;
            Genislik = genislik;
        }


        //## METODLAR  ----------  ----------  ----------  ----------

        public Konteyner Yarat() => new Konteyner ();
        public Konteyner Yarat(int uzunluk, int genislik) => new Konteyner(uzunluk, genislik);


        public void BalangicBelirle (int baslangic) => Baslangic = baslangic;

        public bool IcerikAl(string[] icerik)
        {
            if (icerik.Length <= DikeyKapasite)
            {
                Icerik = icerik;
                return true;
            } return false;
        }

        public bool BosMu() => Icerik == null;
            

    }

    internal class Konteyner <T>
    {
        //## NİTELİKLER  ----------  ----------  ----------  ----------  
        public int Genislik { get; protected set; }
        public int Uzunluk { get; protected set; }
        public int Baslangic { get; protected set; }

        

        //## OLUŞTURUCULAR  ----------  ----------  ----------  ----------

        private Konteyner() { }

        private Konteyner(int uzunluk, int genislik)
        {
            Uzunluk = uzunluk;
            Genislik = genislik;
        }


        //## METODLAR  ----------  ----------  ----------  ----------

        public Konteyner<T> Yarat() => new Konteyner<T>();



    }


}
