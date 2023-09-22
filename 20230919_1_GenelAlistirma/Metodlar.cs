using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230919_1_GenelAlistirma
{
    internal static class Metodlar
    {
        public static string GetString(string metin, int min = 1, int max = 500)
        {
            string txt = string.Empty;
            bool hata = false;
            do
            {
                Console.Write(metin);
                txt = Console.ReadLine();
                #region IsNullOrEmpty Metodu
                // IsNullOrEmpty metodu içerisine parametre olarak girilen string değerin boş olup olmadığını kontrol eder. Geriye bool tipinde değer döndürür. Eğer string değer boş ise "true", boş değil ise "false" değer döndürür.
                #endregion
                if (string.IsNullOrEmpty(txt)) 
                {
                    Console.WriteLine("Boş bir değer giremezsiniz...");
                    hata = true;
                }
                else
                {
                    if (txt.Length < min ||txt.Length > max)
                    {
                        Console.WriteLine("min. {0}, max. {1} uzunluğunda değer girmelisiniz", min, max);
                        hata = true;
                    }
                    else if (!IsOnlyLetters(txt.Replace(" ", "")))
                    {
                        Console.WriteLine("Lütfen sadece harf kullanın.");
                        hata = true;
                    }
                    else
                    {
                        hata = false;
                    }
                }
            } while (hata);
            return txt.Trim();
        }

        private static bool IsOnlyLetters(string txt)
        {
            foreach (var item in txt)
            {
                #region char.IsLetter Metodu
                // char.IsLetter metodu, parametre olarak char bir değer bekler. Girilen char değer Unicode(uluslar arası karakter setine tanımlı harfler) bir değer ise geriye "true" değer döndürür. Değilse geriye "false" değer döndürür.
                #endregion
                if (!char.IsLetter(item))
                {
                    return false;
                }
            }
            return true;
        }

        public static int GetInt(string metin, int min = int.MinValue, int max = int.MaxValue)
        {
            int sayi = 0;
            bool hata = false;
            do
            {
                Console.Write(metin);
                try
                {
                    sayi = int.Parse(Console.ReadLine());// 54
                    if (sayi >= min && sayi <= max)
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen {0} ile {1} arasında bir değer giriniz",min,max);
                        hata = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hata = true;
                }
            } while (hata);
            return sayi;
        }

        public static double GetDouble(string metin, double min = double.MinValue, double max = double.MaxValue) // "1. Not: ", 0, 100
        {
            double sayi = 0;
            bool hata = false;
            do
            {
                Console.Write(metin);
                try
                {
                    sayi = double.Parse(Console.ReadLine());
                    if(sayi >= min && sayi <= max) 
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen min. {0}, max. {1} aralığında bir değer giriniz", min, max);
                        hata = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hata = true;
                }
            } while (hata);
            return sayi;
        }

        public static DateTime GetDateTime (string metin, int minYear, int maxYear) // "Doğum Tarihi(yyyy-aa-gg): ", 2006, 2016
        {
            DateTime date = DateTime.Now;
            bool hata = false;
            do
            {
                Console.Write(metin);
                try
                {
                    date = DateTime.Parse(Console.ReadLine());
                    if (date.Year <= maxYear && date.Year >= minYear)
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen {0} ile {1} yılları arasında bir tarih giriniz");
                        hata = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hata = true;
                }
            } while (hata);
            return date;
        }
    }
}
