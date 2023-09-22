using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230919_1_GenelAlistirma
{
    internal static class Menu
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        public static void Islemler(ConsoleKey cevap)
        {
            switch (cevap)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Ekle("ÖĞRENCİ EKLE");
                break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Listele("ÖĞRENCİ LİSTESİ");
                break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Sil("ÖĞRENCİ SİL");
                break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Ortalama("GENEL NOT ORTALAMASI");
                break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    YasOrtalamasi("YAŞ ORTALAMASI");
                break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    BaslikYazdir("TOPLAN ÖĞRENCİ SAYISI");
                    AnaMenuyeDon(string.Format("Toplam {0} adet öğrenci kayıtlıdır", ogrenciler.Count));
                    break;
            }
        }

        private static void YasOrtalamasi(string v)
        {
            BaslikYazdir(v);
            int toplamYas = 0;
            foreach (var item in ogrenciler)
            {
                toplamYas += item.Yas;
            }
            double yasOrtalamasi = (double)toplamYas / ogrenciler.Count;
            AnaMenuyeDon(string.Format("Toplam {0} öğrencinin yaş ortalaması: {1}", ogrenciler.Count, yasOrtalamasi));
        }

        private static void Ortalama(string v)
        {
            BaslikYazdir(v);

            double genelToplam = 0;
            foreach (var item in ogrenciler)
            {
                genelToplam += item.Ortalama;
            }
            double genelOrtalama = genelToplam / ogrenciler.Count;
            AnaMenuyeDon(string.Format("Toplam {0} öğrencinin genel not ortalaması: {1}", ogrenciler.Count, genelOrtalama));
        }

        private static void Sil(string v)
        {
            BaslikYazdir(v);
            for (int i = 0; i < ogrenciler.Count; i++)
            {
                ogrenciler[i].Yazdir(i + 1);
            }
            Console.WriteLine();
            int siraNo = Metodlar.GetInt("Silmek istediğiniz öğrencinin sıra numarasını giriniz.\nAna Menüye Dönmek İçin 0'a basınız: ", 0, ogrenciler.Count);
            if (siraNo == 0)
            {
                AnaMenuyeDon("Silme işlemi iptal edildi");
            }
            else
            {
                int indexNo = siraNo - 1;
                Console.Write(ogrenciler[indexNo].TamAd + " öğrencisini silmek isteğinize emin misiniz?(e): ");
                if (Console.ReadKey().Key == ConsoleKey.E)
                {
                    string silinen = ogrenciler[indexNo].TamAd;
                    ogrenciler.RemoveAt(indexNo);
                    AnaMenuyeDon(string.Format("{0} isimli öğrenci başarı ile silinmiştir", silinen));
                }
                else
                {
                    AnaMenuyeDon("Silme işlemi iptal edildi");
                }
            }
        }

        private static void Listele(string v)
        {
            BaslikYazdir(v);
            for (int i = 0; i < ogrenciler.Count; i++)
            {
                ogrenciler[i].Yazdir(i+1);
            }
            AnaMenuyeDon(string.Format("Toplam {0} adet öğrenci listelenmiştir", ogrenciler.Count));
        }

        private static void Ekle(string v)
        {
            BaslikYazdir(v);
            Ogrenci o = new Ogrenci();
            o.Ad = Metodlar.GetString("Öğrenci Adı: ", 2,20);
            o.Soyad = Metodlar.GetString("Öğrenci Soyadı: ", 2, 20);
            o.N1 = Metodlar.GetDouble("1. Not: ", 0, 100);
            o.N2 = Metodlar.GetDouble("2. Not: ", 0, 100);
            o.DogumTarihi = Metodlar.GetDateTime("Doğum Tarihi(yyyy-aa-gg): ", 2006, 2016);
            ogrenciler.Add(o);
            AnaMenuyeDon(string.Format("{0} Öğrencisi Başarı ile Eklendi", o.TamAd));
        }

        private static void AnaMenuyeDon(string v)
        {
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine("Ana Menüye Dönmek İçin Bir Tuşa Basınız");
            Console.ReadKey();
        }

        private static void BaslikYazdir(string v)
        {
            Console.Clear();
            Console.WriteLine(v);
            Console.WriteLine("---------------------------");
            Console.WriteLine();
        }

    }
}
