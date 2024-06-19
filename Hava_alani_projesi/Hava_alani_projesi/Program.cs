using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Media;
using System.Reflection;
namespace Hava_alani_projesi
{
    internal class Program
    {
        static List<string> Personeller = new List<string>();
        static List<string> Biletler = new List<string>();
        static List<string> Havaalanları = new List<string>();

        static void Main(string[] args)
        {
            string anaSecim = "", altSecim = "";
            while (anaSecim != "Ç")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.Write("                    __\r\n                  -=\\`\\\r\n              |\\ ____\\_\\__\r\n            -=\\c`\"\"\"\"\"\"\" \"`)\r\n               `~~~~~/ /~~`\r\n                 -==/ /\r\n                   '-'\n          _  _\r\n         ( `   )_\r\n        (    )    `)\r\n      (_   (_ .  _) _)\r\n                                     _\r\n                                    (  )\r\n     _ .                         ( `  ) . )\r\n   (  _ )_                      (_, _(  ,_)_)\r\n (_  _(_ ,)\n");
                Console.WriteLine("      ****** Havaalanı Bilgi Paneli *******");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("     _-------------------------------------_");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t     P-Personel İşlemleri");
                Console.WriteLine("     -____________________________________-\n");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\t     B-Bilet İşlemleri");
                Console.WriteLine("     -____________________________________-\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t     H-Havaalanı işlemleri");
                Console.WriteLine("     -____________________________________-\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t     Ç-Çıkış");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     -____________________________________-\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Seçiminiz:");
                string projeDizini = AppDomain.CurrentDomain.BaseDirectory;
                string musicKlasorDizini = Path.Combine(projeDizini, "music");
                string dosyaYolu = Path.Combine(musicKlasorDizini, "hg.wav");

                try
                {
                    SoundPlayer player = new SoundPlayer(dosyaYolu);
                    player.PlaySync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
                anaSecim = Console.ReadLine().ToUpper();
                if (anaSecim == "P")
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (File.Exists("Personeller.txt") == false)
                    {
                        StreamWriter sw = new StreamWriter("Personeller.txt", false, Encoding.Default);
                        sw.Close();
                        Console.WriteLine("Personel dosyası bulunamadı. Dosya oluşturuldu...");
                    }
                    else
                    {
                        Console.Clear();
                        StreamReader sr = new StreamReader("Personeller.txt", Encoding.Default);
                        string oku = "";
                        Console.WriteLine("Dosyadaki Personel Sayısı");
                        int i = 0;
                        while ((oku = sr.ReadLine()) != null)
                        {
                            Personeller.Add(oku);
                            Console.WriteLine(++i + "-" + oku);
                        }
                        sr.Close();
                        Console.Clear();
                        Console.WriteLine("Dosyadan {0} kayıt okundu", i);
                    }
                    while (altSecim != "0")
                    {
                        ustMenu:
                        Console.WriteLine("          _  _\r\n         ( `   )_\r\n        (    )    `)\r\n      (_   (_ .  _) _)\r\n                                     _\r\n                                    (  )\r\n     _ .                         ( `  ) . )\r\n   (  _ )_                      (_, _(  ,_)_)\r\n (_  _(_ ,)");
                        Console.WriteLine("#  Personel İşlemleri Menüsü  #");
                        Console.WriteLine("1-Ekleme");
                        Console.WriteLine("2-Silme");
                        Console.WriteLine("3-Güncelleme");
                        Console.WriteLine("4-Tümünü Silme");
                        Console.WriteLine("5-Araya Ekle");
                        Console.WriteLine("6-Bul");
                        Console.WriteLine("7-Sırala");
                        Console.WriteLine("8-Listeleme");
                        Console.WriteLine("9-Ana Menüye Dön");
                        Console.WriteLine("0-Çıkış");
                        string projeDizini11 = AppDomain.CurrentDomain.BaseDirectory;
                        string musicKlasorDizini11 = Path.Combine(projeDizini11, "music");
                        string dosyaYolu11 = Path.Combine(musicKlasorDizini11, "peri.wav");

                        try
                        {
                            SoundPlayer player11 = new SoundPlayer(dosyaYolu11);
                            player11.PlaySync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hata: " + ex.Message);
                        }
                        Console.WriteLine("Seçiminiz: ");
                        altSecim = Console.ReadLine().ToUpper();
                        if (altSecim == "1")
                        {
                            string yeniEklensinMi = "E";
                            do
                            {
                                Console.Clear();
                                PersonelListele();
                                string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini1 = Path.Combine(projeDizini11, "music");
                                string dosyaYolu1 = Path.Combine(musicKlasorDizini11, "ekl.wav");

                                try
                                {
                                    SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                    player1.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                string ad = "";
                                string soyad = "";
                                string gorev = "";
                                do
                                {
                                    Console.Write("Personel Adı(En az 2 karakter): ");
                                    ad = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(ad) || ad.Length < 2)
                                    {
                                        Console.WriteLine("Hata: Personel adı boş bırakılamaz ve en az 2 karakter olmalıdır!");
                                        continue;
                                    }

                                    if (int.TryParse(ad, out _))
                                    {
                                        Console.WriteLine("Hata: Personel adı sayı içeremez!");
                                        continue;
                                    }

                                    Console.Write("Personel Soyadı(En az 2 karakter): ");
                                    soyad = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(soyad) || soyad.Length < 2)
                                    {
                                        Console.WriteLine("Hata: Personel soyadı boş bırakılamaz ve en az 2 karakter olmalıdır!");
                                        continue;
                                    }

                                    if (int.TryParse(soyad, out _))
                                    {
                                        Console.WriteLine("Hata: Personel soyadı sayı içeremez!");
                                        continue;
                                    }

                                    Console.Write("Personel Görevi(En az 2 karakter): ");
                                    gorev = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(gorev) || gorev.Length < 2)
                                    {
                                        Console.WriteLine("Hata: Personel görevi boş bırakılamaz ve en az 2 karakter olmalıdır!");
                                        continue;
                                    }

                                    if (int.TryParse(gorev, out _))
                                    {
                                        Console.WriteLine("Hata: Personel görevi sayı içeremez!");
                                        continue;
                                    }

                                    bool personelVar = Personeller.Any(p => p.Split('#')[0].Equals(ad, StringComparison.OrdinalIgnoreCase) &&
                                                                           p.Split('#')[1].Equals(soyad, StringComparison.OrdinalIgnoreCase) &&
                                                                           p.Split('#')[2].Equals(gorev, StringComparison.OrdinalIgnoreCase));

                                    if (personelVar)
                                    {
                                        Console.WriteLine("Hata: Böyle bir personel bulunuyor!");
                                        string devamEt;
                                        do
                                        {
                                            Console.Write("Devam etmek istiyor musunuz? (E/H): ");
                                            devamEt = Console.ReadLine().ToUpper();
                                            Console.Clear();
                                        } while (devamEt != "E" && devamEt != "H");


                                        if (devamEt == "H")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Üst menüye dönülüyor......\n");
                                            string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                            string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                            string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                            try
                                            {
                                                SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                player3.PlaySync();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Hata: " + ex.Message);
                                            }
                                            Console.Clear();
                                            goto ustMenu;       
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);



                                DateTime iseBaslamaTarih;
                                bool isValidDate = false;
                                do
                                {
                                    Console.Write("İşe başlama tarihi (gg.aa.yyyy): ");
                                    string tarihStr = Console.ReadLine();

                                    if (DateTime.TryParseExact(tarihStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out iseBaslamaTarih))
                                    {
                                        isValidDate = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Geçersiz tarih formatı, lütfen gg.aa.yyyy formatında girin.");
                                    }
                                } while (!isValidDate);

                                Personeller.Add(ad + "#" + soyad + "#" + gorev + "#" + iseBaslamaTarih.ToString("dd.MM.yyyy"));

                                using (StreamWriter sw = new StreamWriter("Personeller.txt", true, Encoding.Default))
                                {
                                    sw.WriteLine(ad + "#" + soyad + "#" + gorev + "#" + iseBaslamaTarih.ToString("dd.MM.yyyy"));
                                }
                                Console.Clear();
                                do
                                {
                                    Console.WriteLine("Yeni Personel Eklendi.\nYeni ekleme yapmak istiyor musunuz (E-H)");
                                    yeniEklensinMi = Console.ReadLine().ToUpper();
                                    Console.Clear();
                                    if (yeniEklensinMi != "E" && yeniEklensinMi != "H")
                                    {
                                        Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                    }
                                } while (yeniEklensinMi != "E" && yeniEklensinMi != "H");



                            } while (yeniEklensinMi == "E");
                        }
                        else if (altSecim == "2")
                        {
                            Console.Clear();
                            string yeniSilinsinMi = "E";
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "sil.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            do
                            {
                                if (Personeller.Count == 0)
                                {
                                    Console.WriteLine("Hata: Kayıt bulunamadı! Önce personel listesi oluşturun.");
                                    Console.WriteLine("Bir tuşa basarak devam edin...");

                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0= Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hsil.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }

                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }

                                PersonelListele();

                                int siraNo = 0;
                                while (true)
                                {
                                    Console.Write("Silmek istediğiniz sıra numarası: ");
                                    if (int.TryParse(Console.ReadLine(), out siraNo) == false)
                                    {
                                        Console.WriteLine("Hata: Sıra numarası düzgün biçimde girilmemiş!");
                                    }
                                    else if (siraNo < 1 || siraNo > Personeller.Count)
                                    {
                                        Console.WriteLine("Hata: Sıra numarası aralık dışında seçilmiş!");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                Personeller.RemoveAt(siraNo - 1);
                                PersoneliDosyayaYaz();
                                Console.Clear();
                                Console.Write("{0}. sıradaki Personel silindi.\nYeni Silme İşlemi Yapmak İstiyor Musunuz? (E-H)\n", siraNo);

                                string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "ksilindi.wav");

                                try
                                {
                                    SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                    player6.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                do
                                {
                                    yeniSilinsinMi = Console.ReadLine().ToUpper();
                                    Console.Clear();
                                    if (yeniSilinsinMi != "E" && yeniSilinsinMi != "H")
                                    {
                                        Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                        Console.Write("Yeni Silme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                    }
                                } while (yeniSilinsinMi != "E" && yeniSilinsinMi != "H");
                            } while (yeniSilinsinMi == "E");
                        }
                        else if (altSecim == "3")
                        {
                            Console.Clear();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "gnc.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            Console.WriteLine("Güncelleme işlmeleri--------------\n");
                            string yeniGuncellensinMi = "E";
                            do
                            {
                                if (!File.Exists("Personeller.txt") || Personeller.Count == 0)
                                {
                                    Console.WriteLine("Hata: Kayıt bulunamadı! Önce personel listesi oluşturun.");
                                    Console.WriteLine("Bir tuşa basarak devam edin...");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hsil.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }

                                PersonelListele();
                                int siraNo = 0;
                                while (true)
                                {
                                    Console.Write("Güncellemek istediğiniz sıra numarası: ");
                                    if (int.TryParse(Console.ReadLine(), out siraNo) == false)
                                    {
                                        Console.WriteLine("Hata: Sıra numarası düzgün biçimde girilmemiş!");
                                    }
                                    else if (siraNo < 1 || siraNo > Personeller.Count)
                                    {
                                        Console.WriteLine("Hata: Sıra numarası aralık dışında seçilmiş!");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                string guncellenecekBilgi = Personeller[siraNo - 1];
                                string[] parca = guncellenecekBilgi.Split('#');
                                string ad = "";
                                string soyad = "";
                                string gorev = "";
                                do 
                                {
                                Console.WriteLine("Personel Adı: " + parca[0]);
                                    do
                                    {
                                        Console.Write("Yeni Personel Adı(En az 2 karakter olmalı): ");
                                        ad = Console.ReadLine();
                                        if (string.IsNullOrEmpty(ad) || ad.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Ad boş bırakılamaz ve en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(ad, out _))
                                        {
                                            Console.WriteLine("Hata: Ad sayı içeremez!");
                                            ad = null;
                                        }
                                    } while (string.IsNullOrEmpty(ad) || ad.Length < 2);

                                    Console.WriteLine("Personel Soy Adı: " + parca[1]);
                                    do
                                    {
                                        Console.Write("Yeni Personel Soy Adı(En az 2 karakter olmalı): ");
                                        soyad = Console.ReadLine();
                                        if (string.IsNullOrEmpty(soyad) || soyad.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Soyad boş bırakılamaz ve en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(soyad, out _))
                                        {
                                            Console.WriteLine("Hata: Soyad sayı içeremez!");
                                            soyad = null;
                                        }
                                    } while (string.IsNullOrEmpty(soyad) || soyad.Length < 2);

                                    Console.WriteLine("Görevi: " + parca[2]);
                                    do
                                    {
                                        Console.Write("Yeni Görevi(En az 2 karakter olmalı): ");
                                        gorev = Console.ReadLine();
                                        if (string.IsNullOrEmpty(gorev) || gorev.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Görev boş bırakılamaz ve en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(gorev, out _))
                                        {
                                            Console.WriteLine("Hata: Görev sayı içeremez!");
                                            gorev = null;
                                        }
                                    } while (string.IsNullOrEmpty(gorev) || gorev.Length < 2);

                                    bool personelVar = Personeller.Any(p => p.Split('#')[0].Equals(ad, StringComparison.OrdinalIgnoreCase) &&
                                       p.Split('#')[1].Equals(soyad, StringComparison.OrdinalIgnoreCase) &&
                                       p.Split('#')[2].Equals(gorev, StringComparison.OrdinalIgnoreCase));

                                if (personelVar)
                                {
                                        Console.WriteLine("Hata: Böyle bir personel bulunuyor!");
                                        string devamEt;
                                        do
                                        {
                                            Console.Clear();
                                            Console.Write("Devam etmek istiyor musunuz? (E/H):\n ");
                                            devamEt = Console.ReadLine().ToUpper();
                                        } while (devamEt != "E" && devamEt != "H");


                                        if (devamEt == "H")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Üst menüye dönülüyor......\n");
                                            string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                            string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                            string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                            try
                                            {
                                                SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                player3.PlaySync();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Hata: " + ex.Message);
                                            }
                                            Console.Clear();
                                            goto ustMenu;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);
                            DateTime iseBaslamaTarih;
                                bool isValidDate = false;
                                do
                                {
                                    Console.Write("İşe Başlama Tarihi (gg.aa.yyyy): ");
                                    string tarihStr = Console.ReadLine();
                                    if (DateTime.TryParseExact(tarihStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out iseBaslamaTarih))
                                    {
                                        isValidDate = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Geçersiz tarih formatı, lütfen gg.aa.yyyy formatında girin.");
                                    }
                                } while (!isValidDate);

                                Personeller.RemoveAt(siraNo - 1);
                                Personeller.Insert(siraNo - 1, ad + "#" + soyad + "#" + gorev + "#" + iseBaslamaTarih.ToString("dd.MM.yyyy"));
                                PersoneliDosyayaYaz();
                                Console.Clear();
                                Console.Write("{0}. sıradaki Personel güncellendi.\nYeni İşlem Yapmak İstiyor Musunuz? (E-H)\n", siraNo);
                                string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "itamam.wav");

                                try
                                {
                                    SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                    player6.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                do
                                {
                                    yeniGuncellensinMi = Console.ReadLine().ToUpper();
                                    Console.Clear();
                                    if (yeniGuncellensinMi != "E" && yeniGuncellensinMi != "H")
                                    {
                                        Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                        Console.Write("Yeni Güncelleme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                    }
                                } while (yeniGuncellensinMi != "E" && yeniGuncellensinMi != "H");
                            } while (yeniGuncellensinMi == "E");
                        }
                        else if (altSecim == "4")
                        {
                            Console.Clear();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "tsil.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            Console.Write("Dosyadaki tüm kayıtlar silinecektir.\nDevam etmek istiyor musunuz? (E-H): ");
                            string cevap;                             
                            do
                            {
                                cevap = Console.ReadLine().ToUpper();
                                if (cevap != "E" && cevap != "H")
                                {
                                    Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                    Console.Write("Yeni Güncelleme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                }
                            } while (cevap != "E" && cevap != "H");
                            if (cevap == "E")
                            {
                                if (File.Exists("Personeller.txt"))
                                {
                                    if (Personeller.Count > 0)
                                    {
                                        Personeller.Clear();
                                        StreamWriter sw = new StreamWriter("Personeller.txt", false, Encoding.Default);
                                        sw.Close();
                                        Console.Clear();
                                        Console.WriteLine("Tüm personel kayıtları silindi....\nDevam etmek için bir tuşa basınız.");
                                        string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                        string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                        string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "kayitsil.wav");
                                        try
                                        {
                                            SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                            player6.PlaySync();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Hata: " + ex.Message);
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Dosya içinde kayıt bulunamadı!");
                                        string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                        string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                        string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "h2.wav");

                                        try
                                        {
                                            SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                            player0.PlaySync();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Hata: " + ex.Message);
                                        }
                                        Console.Clear();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Hata: Dosya bulunamadı!");
                                }
                            }
                        }
                        else if (altSecim == "5")
                        {
                            Console.Clear();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "aekle.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            string yeniEklensinMi = "E";
                            if (File.Exists("Personeller.txt") && new FileInfo("Personeller.txt").Length > 0)
                            {
                                do
                                {
                                    PersonelListele();
                                    int siraNo = 0;
                                    while (true)
                                    {
                                        Console.Write("Eklemek istediğiniz sıra numarası: ");
                                        if (int.TryParse(Console.ReadLine(), out siraNo) == false)
                                        {
                                            Console.WriteLine("Hata: Sıra numarası düzgün biçimde girilmemiş!");
                                        }
                                        else if (siraNo < 1 || siraNo > Personeller.Count)
                                        {
                                            Console.WriteLine("Hata: Sıra numarası aralık dışında seçilmiş!");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    string ad = "";
                                    string soyad = "";
                                    string gorev = "";
                                    do 
                                    {
                                        do
                                        {
                                            Console.Write("Personel Adı(En az 2 karakter girişi olmalı): ");
                                            ad = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(ad))
                                            {
                                                Console.WriteLine("Hata: Personel adı boş bırakılamaz!");
                                            }
                                            else if (ad.Length < 2)
                                            {
                                                Console.WriteLine("Hata: Personel adı en az 2 karakter olmalıdır!");
                                            }
                                            else if (int.TryParse(ad, out _))
                                            {
                                                Console.WriteLine("Hata: Personel adı sayı içeremez!");
                                                ad = null;
                                            }
                                        } while (string.IsNullOrWhiteSpace(ad) || ad.Length < 2);

                                        do
                                        {
                                            Console.Write("Personel Soyadı(En az 2 karakter girişi olmalı): ");
                                            soyad = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(soyad))
                                            {
                                                Console.WriteLine("Hata: Personel soyadı boş bırakılamaz!");
                                            }
                                            else if (soyad.Length < 2)
                                            {
                                                Console.WriteLine("Hata: Personel soyadı en az 2 karakter olmalıdır!");
                                            }
                                            else if (int.TryParse(soyad, out _))
                                            {
                                                Console.WriteLine("Hata: Personel soyadı sayı içeremez!");
                                                soyad = null;
                                            }
                                        } while (string.IsNullOrWhiteSpace(soyad) || soyad.Length < 2);

                                        do
                                        {
                                            Console.Write("Personel Görevi(En az 2 karakter girişi olmalı): ");
                                            gorev = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(gorev))
                                            {
                                                Console.WriteLine("Hata: Personel görevi boş bırakılamaz!");
                                            }
                                            else if (gorev.Length < 2)
                                            {
                                                Console.WriteLine("Hata: Personel görevi en az 2 karakter olmalıdır!");
                                            }
                                            else if (int.TryParse(gorev, out _))
                                            {
                                                Console.WriteLine("Hata: Personel görevi sayı içeremez!");
                                                gorev = null;
                                            }
                                        } while (string.IsNullOrWhiteSpace(gorev) || gorev.Length < 2);

                                        bool personelVar = Personeller.Any(p => p.Split('#')[0].Equals(ad, StringComparison.OrdinalIgnoreCase) &&
                                       p.Split('#')[1].Equals(soyad, StringComparison.OrdinalIgnoreCase) &&
                                       p.Split('#')[2].Equals(gorev, StringComparison.OrdinalIgnoreCase));

                                    if (personelVar)
                                    {
                                            Console.WriteLine("Hata: Böyle bir personel bulunuyor!");
                                            string devamEt;
                                            do
                                            {
                                                Console.Write("Devam etmek istiyor musunuz? (E/H):\n ");
                                                devamEt = Console.ReadLine().ToUpper();
                                                Console.Clear();
                                            } while (devamEt != "E" && devamEt != "H");


                                            if (devamEt == "H")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Üst menüye dönülüyor......\n");
                                                string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                                string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                                string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                                try
                                                {
                                                    SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                    player3.PlaySync();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Hata: " + ex.Message);
                                                }
                                                Console.Clear();
                                                goto ustMenu;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);
                                DateTime iseBaslamaTarih;
                                    bool isValidDate = false;
                                    do
                                    {
                                        Console.Write("İşe Başlama Tarihi (gg.aa.yyyy): ");
                                        string tarihStr = Console.ReadLine();
                                        if (DateTime.TryParseExact(tarihStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out iseBaslamaTarih))
                                        {
                                            isValidDate = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hata: Geçersiz tarih formatı, lütfen gg.aa.yyyy formatında girin.");
                                        }
                                    } while (!isValidDate);
                                    Personeller.Insert(siraNo - 1, ad + "#" + soyad + "#" + gorev + "#" + iseBaslamaTarih.ToString("dd.MM.yyyy"));
                                    PersoneliDosyayaYaz();
                                    Console.Clear();
                                    Console.Write("Personel {0}. sıraya eklendi.\nYeni Ekleme Yapmak İstiyor Musunuz? (E-H)\n", siraNo);
                                    string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                    string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "itamam.wav");

                                    try
                                    {
                                        SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                        player6.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    do
                                    {
                                        yeniEklensinMi = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (yeniEklensinMi != "E" && yeniEklensinMi != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                            Console.Write("Yeni Araya Ekleme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                        }
                                    } while (yeniEklensinMi != "E" && yeniEklensinMi != "H");
                            } while (yeniEklensinMi == "E");
                            }
                            else
                            {
                                Console.WriteLine("Hata: Dosyada kayıtlı girdi bulunamadı!");
                                Console.WriteLine("Bir tuşa basarak bir önceki menüye dönün...");
                                string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hsil.wav");

                                try
                                {
                                    SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                    player0.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        else if (altSecim == "6")
                        {
                            Console.Clear();
                            string araSec = "";
                            while (araSec != "Ç")
                            {
                                Console.WriteLine("--Arama İşlemleri----------");
                                Console.WriteLine("1-Ad'a göre Ara");
                                Console.WriteLine("2-Soy Ad'a göre Ara");
                                Console.WriteLine("3-Görev'e göre Ara");
                                Console.WriteLine("4-İşe Başlama Tarihine göre Ara");
                                Console.WriteLine("0-Herşeyde Ara");
                                Console.WriteLine("Ç-Üst Menüye Dön");
                                Console.Write("Seçiminiz:");
                                string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                                string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "bul.wav");

                                try
                                {
                                    SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                    player1.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                araSec = Console.ReadLine().ToUpper();
                                string ara = "";
                                if (File.ReadAllText("Personeller.txt").Trim() == "")
                                {
                                    Console.WriteLine("Hata: Dosyanın içi boş!");
                                    Console.WriteLine("Bir tuşa basarak devam edin...");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hsil.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }

                                if (araSec == "1")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Adı Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine().ToUpper();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    PersonelAra(0, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (araSec == "2")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Soy Adı Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine().ToUpper();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    PersonelAra(1, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (araSec == "3")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Görevi Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine().ToUpper();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    PersonelAra(2, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (araSec == "4")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Tarihi Giriniz (gg.aa.yyyy formatında): ");
                                        string tarihStr = Console.ReadLine();
                                        if (DateTime.TryParseExact(tarihStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tarih))
                                        {
                                            ara = tarih.ToString("dd.MM.yyyy");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hata: Geçersiz tarih formatı, lütfen gg.aa.yyyy formatında girin.");
                                        }
                                    } while (ara.Length < 4);
                                    Console.Clear();
                                    PersonelAra(3, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (araSec == "0")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Metni Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine().ToUpper();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    PersonelAra(0, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (araSec == "Ç")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Üst menüye dönülüyor..\nBir tuşa basınız....");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "ust.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }
                                    
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Yanlış seçim yaptınız...Menü için bir tuşa basınız...\n\n");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "ysecim.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }                              
                            }
                        }
                        else if (altSecim == "7")
                        {
                            Console.Clear();
                            Console.WriteLine("\nPersoneller Sıralı Listesi-------");
                            List<string> siraliPersonel = new List<string>();
                            siraliPersonel.AddRange(Personeller);
                            siraliPersonel.Sort();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "sırala.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }

                            if (siraliPersonel.Count == 0)
                            {
                                Console.WriteLine("Hata: Kayıt bulunamadı!");
                                string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hkayıt.wav");

                                try
                                {
                                    SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                    player0.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < siraliPersonel.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + ")- " + siraliPersonel[i]);
                                }
                                while (true)
                                {
                                    Console.Write("Orjinal listedeki kayıtların da sıralanmasını istiyor musunuz? (E-H): \n");
                                    string cevap = Console.ReadLine().ToUpper();

                                    if (cevap == "E")
                                    {
                                        Personeller = siraliPersonel;
                                        Console.Clear();
                                        Console.WriteLine("Listeniz sıralanmıştır.");
                                        break;
                                    }
                                    else if (cevap == "H")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Geçersiz bir giriş yaptınız. Lütfen 'E' veya 'H' giriniz.\n");
                                    }
                                }
                            }
                        }
                        else if (altSecim == "8")
                        {
                            Console.Clear();
                            Console.WriteLine("\nPersonel Listesi-------");
                            PersonelListele();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "list.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            if (Personeller.Count == 0)
                            {
                                Console.WriteLine("Hata: Kayıt bulunamadı!");
                                string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hkayıt.wav");

                                try
                                {
                                    SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                    player0.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                            }

                            Console.WriteLine();
                        }
                        else if (altSecim == "9")
                        {
                            Console.Clear();
                            Console.WriteLine("Ana menüye dönülüyor......\n Devam etmek için bir tuşa basınız...");
                            string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                            string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "main.wav");

                            try
                            {
                                SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                player0.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            break;
                        }
                        else if (altSecim == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("Uygulamadan Çıkış Yapılıyor......\nÇıkış yapmak istiyor musunuz?(E-H)\n");
                            string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                            string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "exit2.wav");

                            try
                            {
                                SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                player0.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            string cevap;
                            do
                            {
                                cevap = Console.ReadLine()?.ToUpper();
                                Console.Clear();

                                if (cevap != "E" && cevap != "H")
                                {
                                    Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                }
                            } while (cevap != "E" && cevap != "H");

                            if (cevap == "H")
                            {
                                altSecim = "11";
                            }
                            else
                            {
                                Console.WriteLine("Bir tuşa basınız...\n");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı seçim yaptınız...!");
                        }
                    }
                }
                else if (anaSecim == "B")
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    if (File.Exists("Biletler.txt") == false)
                    {
                        StreamWriter sw = new StreamWriter("Biletler.txt", false, Encoding.Default);
                        sw.Close();
                        Console.WriteLine("Bilet dosyası bulunamadı. Dosya oluşturuldu...");
                    }
                    else
                    {
                        Console.Clear();
                        StreamReader sr = new StreamReader("Biletler.txt", Encoding.Default);
                        string oku = "";
                        Console.WriteLine("Dosyadaki Bilet Bilgisi Sayısı");
                        int i = 0;
                        while ((oku = sr.ReadLine()) != null)
                        {
                            Biletler.Add(oku);
                            Console.WriteLine(++i + "-" + oku);
                        }
                        sr.Close();
                        Console.Clear();
                        Console.WriteLine("Dosyadan {0} kayıt okundu", i);
                    }
                    while (altSecim != "0")
                    {
                        ustMenu:
                        Console.WriteLine("          _  _\r\n         ( `   )_\r\n        (    )    `)\r\n      (_   (_ .  _) _)\r\n                                     _\r\n                                    (  )\r\n     _ .                         ( `  ) . )\r\n   (  _ )_                      (_, _(  ,_)_)\r\n (_  _(_ ,)");
                        Console.WriteLine("#  Bilet İşlemleri Menüsü  #");
                        Console.WriteLine("1-Ekleme");
                        Console.WriteLine("2-Silme");
                        Console.WriteLine("3-Güncelleme");
                        Console.WriteLine("4-Tümünü Silme");
                        Console.WriteLine("5-Araya Ekle");
                        Console.WriteLine("6-Bul");
                        Console.WriteLine("7-Sırala");
                        Console.WriteLine("8-Listeleme");
                        Console.WriteLine("9-Ana Menüye Dön");
                        Console.WriteLine("0-Çıkış");
                        Console.WriteLine("Seçiminiz: ");
                        string projeDizini11 = AppDomain.CurrentDomain.BaseDirectory;
                        string musicKlasorDizini11 = Path.Combine(projeDizini11, "music");
                        string dosyaYolu11 = Path.Combine(musicKlasorDizini11, "bi.wav");

                        try
                        {
                            SoundPlayer player11 = new SoundPlayer(dosyaYolu11);
                            player11.PlaySync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hata: " + ex.Message);
                        }
                        altSecim = Console.ReadLine().ToUpper();
                        if (altSecim == "1")
                        {
                            Console.Clear();
                            string yeniEklensinMi = "E";
                            do
                            {
                                BiletListele();
                                string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini1 = Path.Combine(projeDizini11, "music");
                                string dosyaYolu1 = Path.Combine(musicKlasorDizini11, "ekl.wav");

                                try
                                {
                                    SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                    player1.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                string m_ad = "";
                                string m_soyad = "";
                                int sefer_no;
                                string kalkis_yeri= "";
                                string inis_yeri= "";
                                do
                                {
                                    do
                                    {
                                        Console.Write("Müşteri Adı(En az 2 karakter girişi olmalı): ");
                                        m_ad = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(m_ad))
                                        {
                                            Console.WriteLine("Hata: Müşteri adı boş bırakılamaz!");
                                        }
                                        else if (m_ad.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Müşteri adı en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(m_ad, out _))
                                        {
                                            Console.WriteLine("Hata: Müşteri adı sayı içeremez!");
                                            m_ad = null;
                                        }
                                    } while (string.IsNullOrWhiteSpace(m_ad) || m_ad.Length < 2);

                                    do
                                    {
                                        Console.Write("Müşteri Soyadı(En az 2 karakter girişi olmalı): ");
                                        m_soyad = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(m_soyad))
                                        {
                                            Console.WriteLine("Hata: Müşteri soyadı boş bırakılamaz!");
                                        }
                                        else if (m_soyad.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Müşteri soyadı en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(m_soyad, out _))
                                        {
                                            Console.WriteLine("Hata: Müşteri soyadı sayı içeremez!");
                                            m_soyad = null;
                                        }
                                    } while (string.IsNullOrWhiteSpace(m_soyad) || m_soyad.Length < 2);


                                    string seferNoStr;
                                do
                                {
                                    Console.Write("Sefer NO: ");
                                    seferNoStr = Console.ReadLine().ToUpper();
                                        if (!int.TryParse(seferNoStr, out sefer_no))
                                    {
                                        Console.WriteLine("Hata: Geçersiz sefer numarası!");
                                    }
                                } while (!int.TryParse(seferNoStr, out sefer_no));

                                    do
                                    {
                                        Console.Write("Kalkış Yeri(En az 2 karakter girişi olmalı): ");
                                        kalkis_yeri = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(kalkis_yeri))
                                        {
                                            Console.WriteLine("Hata: Kalkış yeri boş bırakılamaz!");
                                        }
                                        else if (kalkis_yeri.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Kalkış yeri en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(kalkis_yeri, out _))
                                        {
                                            Console.WriteLine("Hata: Kalkış yeri sayı içeremez!");
                                            kalkis_yeri = null;
                                        }
                                    } while (string.IsNullOrWhiteSpace(kalkis_yeri) || kalkis_yeri.Length < 2);

                                    do
                                    {
                                        Console.Write("İniş Yeri(En az 2 karakter girişi olmalı): ");
                                        inis_yeri = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(inis_yeri))
                                        {
                                            Console.WriteLine("Hata: İniş yeri boş bırakılamaz!");
                                        }
                                        else if (inis_yeri.Length < 2)
                                        {
                                            Console.WriteLine("Hata: İniş yeri en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(inis_yeri, out _))
                                        {
                                            Console.WriteLine("Hata: İniş yeri sayı içeremez!");
                                            inis_yeri = null;
                                        }
                                    } while (string.IsNullOrWhiteSpace(inis_yeri) || inis_yeri.Length < 2);


                                    bool biletVar = Biletler.Any(p => string.Equals(p.Split('#')[0], m_ad, StringComparison.OrdinalIgnoreCase) &&
                                                                       string.Equals(p.Split('#')[1], m_soyad, StringComparison.OrdinalIgnoreCase) &&
                                                                          int.Equals(int.Parse(p.Split('#')[2]), sefer_no) &&
                                                                       string.Equals(p.Split('#')[3], kalkis_yeri, StringComparison.OrdinalIgnoreCase) &&
                                                                       string.Equals(p.Split('#')[4], inis_yeri, StringComparison.OrdinalIgnoreCase));


                                    if (biletVar)
                                {
                                    Console.WriteLine("Hata: Böyle bir bilet bulunuyor!");
                                    string devamEt;
                                    do
                                    {
                                        Console.Write("Devam etmek istiyor musunuz? (E/H): ");
                                        devamEt = Console.ReadLine().ToUpper();
                                            Console.Clear();
                                    } while (devamEt != "E" && devamEt != "H");


                                    if (devamEt == "H")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Üst menüye dönülüyor......\n");
                                            string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                            string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                            string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                            try
                                            {
                                                SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                player3.PlaySync();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Hata: " + ex.Message);
                                            }
                                            Console.Clear();
                                        goto ustMenu;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            Console.Write("Kalkış tarihi (gg.aa.yyyy): ");
                                DateTime KalkisTarihi;
                                while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out KalkisTarihi))
                                {
                                    Console.WriteLine("Geçersiz tarih formatı, lütfen gg.aa.yyyy formatında girin.");
                                }

                                string KalkisSaati;
                                bool gecerliSaatGirildi = false;
                                do
                                {
                                    Console.Write("Kalkış saati (HH:mm): ");
                                    KalkisSaati = Console.ReadLine().ToUpper();

                                    if (KalkisSaati.Length == 5 && KalkisSaati[2] == ':')
                                    {
                                        string saatStr = KalkisSaati.Substring(0, 2);
                                        string dakikaStr = KalkisSaati.Substring(3, 2);

                                        int saat, dakika;
                                        if (int.TryParse(saatStr, out saat) && int.TryParse(dakikaStr, out dakika))
                                        {
                                            gecerliSaatGirildi = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hata: Geçersiz saat değeri!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Saat değerini HH:mm formatında girin!");
                                    }
                                } while (!gecerliSaatGirildi);

                                string koltukNoStr;
                                int koltuk_no;
                                do
                                {
                                do
                                {
                                    Console.Write("Koltuk NO: ");
                                    koltukNoStr = Console.ReadLine().ToUpper();
                                        if (!int.TryParse(koltukNoStr, out koltuk_no))
                                    {
                                        Console.WriteLine("Hata: Geçersiz koltuk numarası!");
                                    }
                                } while (!int.TryParse(koltukNoStr, out koltuk_no));
                                    bool koltukVar = Biletler.Any(p =>
                                      int.Equals(int.Parse(p.Split('#')[2]), sefer_no) &&
                                      int.Equals(int.Parse(p.Split('#')[7]), koltuk_no) &&
                                   string.Equals(p.Split('#')[3], kalkis_yeri, StringComparison.OrdinalIgnoreCase) &&
                                   string.Equals(p.Split('#')[4], inis_yeri, StringComparison.OrdinalIgnoreCase) &&
                                   DateTime.Parse(p.Split('#')[5]) == KalkisTarihi);

                                    if (koltukVar)
                                {
                                    Console.WriteLine("Hata: Böyle bir koltuk bulunuyor!");
                                    string devamEt;
                                    do
                                    {
                                        Console.Write("Devam etmek istiyor musunuz? (E/H): ");
                                        devamEt = Console.ReadLine().ToUpper();
                                    } while (devamEt != "E" && devamEt != "H");


                                    if (devamEt == "H")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Üst menüye dönülüyor......\n");
                                            string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                            string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                            string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                            try
                                            {
                                                SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                player3.PlaySync();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Hata: " + ex.Message);
                                            }
                                            Console.Clear();
                                        goto ustMenu;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            Biletler.Add(m_ad + "#" + m_soyad + "#" + sefer_no + "#" + kalkis_yeri + "#" + inis_yeri + "#" + KalkisTarihi + "#" + KalkisSaati + "#" + koltuk_no);
                                StreamWriter sw = new StreamWriter("Biletler.txt", true, Encoding.Default);
                                sw.WriteLine(m_ad + "#" + m_soyad + "#" + sefer_no + "#" + kalkis_yeri + "#" + inis_yeri + "#" + KalkisTarihi + "#" + KalkisSaati + "#" + koltuk_no);
                                sw.Close();

                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("Yeni Bilet Eklendi.\nYeni ekleme yapmak istiyor musunuz (E-H)");
                                    yeniEklensinMi = Console.ReadLine().ToUpper();
                                    Console.Clear();
                                    if (yeniEklensinMi != "E" && yeniEklensinMi != "H")
                                    {
                                        Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                    }
                                } while (yeniEklensinMi != "E" && yeniEklensinMi != "H");
                            } while (yeniEklensinMi == "E");
                        }
                        else if (altSecim == "2")
                        {
                            Console.Clear();
                            string yeniSilinsinMi = "E";
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "sil.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            do
                            {
                                if (Biletler.Count == 0)
                                {
                                    Console.WriteLine("Hata: Kayıt bulunamadı! Önce bilet listesi oluşturun.");
                                    Console.WriteLine("Bir tuşa basarak devam edin...");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "bilethata.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                BiletListele();
                                int siraNo = 0;
                                while (true)
                                {
                                    Console.Write("Silmek istediğiniz sıra numarası:");
                                    if (int.TryParse(Console.ReadLine(), out siraNo) == false)
                                    {
                                        Console.Write("Sıra numarası düzgün biçimde girilmemiş !!!\nTekrar ");
                                    }
                                    else if (siraNo < 1 || siraNo > Biletler.Count)
                                    {
                                        Console.Write("Sıra numarası aralık dışında seçilmiş. !!!\nTekrar");
                                    }
                                    else
                                        break;
                                }
                                Biletler.RemoveAt(siraNo - 1);
                                BiletiDosyayaYaz();

                                Console.Write("{0}. sıradaki Değerli Eşya silindi.\nYeni Silme İşlemi Yapmak İstiyor Musunuz?(E-H)\n", siraNo);
                                string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "ksilindi.wav");

                                try
                                {
                                    SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                    player6.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                do
                                {
                                    yeniSilinsinMi = Console.ReadLine().ToUpper();
                                    Console.Clear();
                                    if (yeniSilinsinMi != "E" && yeniSilinsinMi != "H")
                                    {
                                        Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                        Console.Write("Yeni Silme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                    }
                                } while (yeniSilinsinMi != "E" && yeniSilinsinMi != "H");
                            } while (yeniSilinsinMi == "E");
                        }
                        else if (altSecim == "3")
                        {
                            Console.Clear();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "gnc.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            Console.WriteLine("Güncelleme işlmeleri--------------\n");
                            string yeniGuncellensinMi = "E";
                            do
                            {
                                if (!File.Exists("Biletler.txt") || Biletler.Count == 0)
                                {
                                    Console.WriteLine("Hata: Kayıt bulunamadı! Önce bilet listesi oluşturun.");
                                    Console.WriteLine("Bir tuşa basarak devam edin...");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "bilethata.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                BiletListele();
                                int siraNo = 0;
                                while (true)
                                {
                                    Console.Write("Güncellemek istediğiniz sıra numarası:");
                                    if (int.TryParse(Console.ReadLine(), out siraNo) == false)
                                    {
                                        Console.Write("Sıra numarası düzgün biçimde girilmemiş !!!\nTekrar ");
                                    }
                                    else if (siraNo < 1 || siraNo > Biletler.Count)
                                    {
                                        Console.Write("Sıra numarası aralık dışında seçilmiş. !!!\nTekrar");
                                    }
                                    else
                                        break;
                                }
                                string guncellenecekBilgi = Biletler[siraNo - 1];
                                string[] parca = guncellenecekBilgi.Split('#');
                                Console.WriteLine("Müşteri Adı: " + parca[0]);
                                string m_ad="";
                                string m_soyad="";
                                int sefer_no = 0;
                                string kalkis_yeri="";
                                string inis_yeri = "";
                                do
                                {
                                    do
                                    {
                                        Console.Write("Yeni Müşteri Adı(En az 2 karakter girişi olmalı): ");
                                        m_ad = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(m_ad))
                                        {
                                            Console.WriteLine("Hata: Müşteri adı boş bırakılamaz!");
                                        }
                                        else if (m_ad.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Müşteri adı en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(m_ad, out _))
                                        {
                                            Console.WriteLine("Hata: Müşteri adı sayı içeremez!");
                                            m_ad = null;
                                        }
                                    } while (string.IsNullOrWhiteSpace(m_ad) || m_ad.Length < 2);

                                    Console.WriteLine("Müşteri Soy Adı: " + parca[1]);
                                    do
                                    {
                                        Console.Write("Yeni Müşteri Soy Adı(En az 2 karakter girişi olmalı): ");
                                        m_soyad = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(m_soyad))
                                        {
                                            Console.WriteLine("Hata: Müşteri soyadı boş bırakılamaz!");
                                        }
                                        else if (m_soyad.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Müşteri soyadı en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(m_soyad, out _))
                                        {
                                            Console.WriteLine("Hata: Müşteri soyadı sayı içeremez!");
                                            m_soyad = null;
                                        }
                                    } while (string.IsNullOrWhiteSpace(m_soyad) || m_soyad.Length < 2);


                                    Console.WriteLine("Sefer NO: " + parca[2]);
                                bool isValidSeferNo = false;
                                do
                                {
                                    Console.Write("Yeni Sefer NO: ");
                                    string input = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrEmpty(input))
                                    {
                                        Console.WriteLine("Hata: Sefer NO boş bırakılamaz!");
                                    }
                                    else if (!int.TryParse(input, out sefer_no))
                                    {
                                        Console.WriteLine("Hata: Geçersiz Sefer NO formatı!");
                                    }
                                    else
                                    {
                                        isValidSeferNo = true;
                                    }
                                } while (!isValidSeferNo);

                                Console.WriteLine("Kalkış yeri: " + parca[3]);

                                    bool isValidKalkisYeri = false;
                                    do
                                    {
                                        Console.Write("Yeni Kalkış Yeri(En az 2 karakter girişi olmalı): ");
                                        kalkis_yeri = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(kalkis_yeri))
                                        {
                                            Console.WriteLine("Hata: Kalkış Yeri boş bırakılamaz!");
                                        }
                                        else if (kalkis_yeri.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Kalkış Yeri en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(kalkis_yeri, out _))
                                        {
                                            Console.WriteLine("Hata: Kalkış Yeri sayı içeremez!");
                                            kalkis_yeri = null;
                                        }
                                        else
                                        {
                                            isValidKalkisYeri = true;
                                        }
                                    } while (!isValidKalkisYeri);

                                    Console.WriteLine("Varış Yeri: " + parca[4]);
                                    bool isValidInisYeri = false;
                                    do
                                    {
                                        Console.Write("Yeni Varış Yeri(En az 2 karakter girişi olmalı): ");
                                        inis_yeri = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(inis_yeri))
                                        {
                                            Console.WriteLine("Hata: Varış Yeri boş bırakılamaz!");
                                        }
                                        else if (inis_yeri.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Varış Yeri en az 2 karakter olmalıdır!");
                                        }
                                        else if (int.TryParse(inis_yeri, out _))
                                        {
                                            Console.WriteLine("Hata: Varış Yeri sayı içeremez!");
                                            inis_yeri = null;
                                        }
                                        else
                                        {
                                            isValidInisYeri = true;
                                        }
                                    } while (!isValidInisYeri);


                                    bool biletVar = Biletler.Any(p => string.Equals(p.Split('#')[0], m_ad, StringComparison.OrdinalIgnoreCase) &&
                                                                      string.Equals(p.Split('#')[1], m_soyad, StringComparison.OrdinalIgnoreCase) &&
                                                                         int.Equals(int.Parse(p.Split('#')[2]), sefer_no) &&
                                                                      string.Equals(p.Split('#')[3], kalkis_yeri, StringComparison.OrdinalIgnoreCase) &&
                                                                      string.Equals(p.Split('#')[4], inis_yeri, StringComparison.OrdinalIgnoreCase));

                                    if (biletVar)
                                    {
                                        Console.WriteLine("Hata: Böyle bir bilet bulunuyor!");
                                        string devamEt;
                                        do
                                        {
                                            Console.Clear();
                                            Console.Write("Devam etmek istiyor musunuz? (E/H):\n ");
                                            devamEt = Console.ReadLine().ToUpper();
                                        } while (devamEt != "E" && devamEt != "H");


                                        if (devamEt == "H")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Üst menüye dönülüyor......\n");
                                            string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                            string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                            string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                            try
                                            {
                                                SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                player3.PlaySync();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Hata: " + ex.Message);
                                            }
                                            Console.Clear();
                                            goto ustMenu;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);

                                DateTime KalkisTarih;
                                bool isValidDate = false;
                                do
                                {
                                    Console.Write("Kalkış Tarihi (gg.aa.yyyy): ");
                                    string tarihStr = Console.ReadLine();
                                    if (DateTime.TryParseExact(tarihStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out KalkisTarih))
                                    {
                                        isValidDate = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Geçersiz tarih formatı, lütfen gg.aa.yyyy formatında girin.");
                                    }
                                } while (!isValidDate);
                                string KalkisSaat;
                                bool gecerliSaatGirildi = false;
                                do
                                {
                                    Console.Write("Kalkış saati (HH:mm): ");
                                    KalkisSaat = Console.ReadLine();

                                    if (KalkisSaat.Length == 5 && KalkisSaat[2] == ':')
                                    {
                                        string saatStr = KalkisSaat.Substring(0, 2);
                                        string dakikaStr = KalkisSaat.Substring(3, 2);

                                        int saat, dakika;
                                        if (int.TryParse(saatStr, out saat) && int.TryParse(dakikaStr, out dakika))
                                        {
                                            gecerliSaatGirildi = true;
                                            Console.WriteLine("Kalkış saati: " + saat + ":" + dakika);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hata: Geçersiz saat değeri!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Saat değerini HH:mm formatında girin!");
                                    }
                                } while (!gecerliSaatGirildi);
                                Console.WriteLine("Koltuk NO: " + parca[7]);
                                int Koltuk_no;
                                bool isValidKoltukNo = false;
                                do 
                                { 
                                do
                                {
                                    Console.Write("Yeni Koltuk NO: ");
                                    string koltukNoStr = Console.ReadLine().ToUpper();
                                        if (int.TryParse(koltukNoStr, out Koltuk_no))
                                    {
                                        isValidKoltukNo = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Geçersiz Koltuk NO değeri!");
                                    }
                                } while (!isValidKoltukNo);
                                    bool koltukVar = Biletler.Any(p =>
                                    int.Equals(int.Parse(p.Split('#')[2]), sefer_no) &&
                                    int.Equals(int.Parse(p.Split('#')[7]), Koltuk_no) &&
                                    string.Equals(p.Split('#')[3], kalkis_yeri, StringComparison.OrdinalIgnoreCase) &&
                                    string.Equals(p.Split('#')[4], inis_yeri, StringComparison.OrdinalIgnoreCase) &&
                                    DateTime.Parse(p.Split('#')[5]) == KalkisTarih);
                                    if (koltukVar)
                                    {
                                        Console.WriteLine("Hata: Böyle bir koltuk bulunuyor!");
                                        string devamEt;
                                        do
                                        {
                                            Console.Write("Devam etmek istiyor musunuz? (E/H):\n ");
                                            devamEt = Console.ReadLine().ToUpper();
                                        } while (devamEt != "E" && devamEt != "H");


                                        if (devamEt == "H")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Üst menüye dönülüyor......\n");
                                            string kullaniciAdi3 = Environment.UserName;
                                            string dosyaAdi3 = "ust2.wav";
                                            string dosyaYolu3 = Path.Combine("C:\\Users", kullaniciAdi3, "source\\repos\\Hava_alani_projesi\\Hava_alani_projesi\\music", dosyaAdi3);

                                            try
                                            {
                                                SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                player3.PlaySync();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Hata: " + ex.Message);
                                            }
                                            Console.Clear();
                                            goto ustMenu;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);
                                Biletler.RemoveAt(siraNo - 1);
                                Biletler.Insert(siraNo - 1, m_ad + "#" + m_soyad + "#" + sefer_no + "#" + kalkis_yeri + "#" + inis_yeri + "#" + KalkisTarih + "#" + KalkisSaat + "#" + Koltuk_no);
                                PersoneliDosyayaYaz();
                                Console.Clear();
                                Console.Write("{0}. sıradaki Bilet güncellendi.\nYeni İşlem Yapmak İstiyor Musunuz?(E-H)\n", siraNo);
                                string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "itamam.wav");

                                try
                                {
                                    SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                    player6.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                do
                                {
                                    yeniGuncellensinMi = Console.ReadLine().ToUpper();
                                    Console.Clear();
                                    if (yeniGuncellensinMi != "E" && yeniGuncellensinMi != "H")
                                    {
                                        Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                        Console.Write("Yeni Güncelleme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                    }
                                } while (yeniGuncellensinMi != "E" && yeniGuncellensinMi != "H");
                            }
                            while (yeniGuncellensinMi == "E");
                        }
                        else if (altSecim == "4")
                        {
                            Console.Clear();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "tsil.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            Console.Write("Dosyadaki tüm kayıtlar silinecektir.\nDevam etmek istiyor musunuz ?(E-H):\n");
                            string cevap;
                            do
                            {
                                cevap = Console.ReadLine().ToUpper();
                                if (cevap != "E" && cevap != "H")
                                {
                                    Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                    Console.Write("Yeni Güncelleme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                }
                            } while (cevap != "E" && cevap != "H");
                            if (cevap == "E")
                            {
                                if (File.Exists("Biletler.txt"))
                                {
                                    if (Biletler.Count > 0)
                                    {
                                        Biletler.Clear();
                                        StreamWriter sw = new StreamWriter("Biletler.txt", false, Encoding.Default);
                                        sw.Close();
                                        Console.Clear();
                                        Console.WriteLine("Tüm bilet kayıtları silindi....\nDevam etmek için bir tuşa basınız.");
                                        string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                        string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                        string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "kayitsil.wav");
                                        try
                                        {
                                            SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                            player6.PlaySync();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Hata: " + ex.Message);
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Dosya içinde kayıt bulunamadı!");
                                        string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                        string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                        string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "h2.wav");

                                        try
                                        {
                                            SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                            player0.PlaySync();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Hata: " + ex.Message);
                                        }
                                        Console.Clear();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Hata: Dosya bulunamadı!");
                                }
                            }
                        }
                        else if (altSecim == "5")
                        {
                            Console.Clear();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "aekle.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            string yeniEklensinMi = "E";
                            if (File.Exists("Biletler.txt") && new FileInfo("Biletler.txt").Length > 0)
                            {
                                do
                                {
                                    BiletListele();
                                    int siraNo = 0;
                                    while (true)
                                    {
                                        Console.Write("Eklemek istediğiniz sıra numarası:");
                                        if (int.TryParse(Console.ReadLine(), out siraNo) == false)
                                        {
                                            Console.Write("Sıra numarası düzgün biçimde girilmemiş !!!\nTekrar ");
                                        }
                                        else if (siraNo < 1 || siraNo > Biletler.Count)
                                        {
                                            Console.Write("Sıra numarası aralık dışında seçilmiş. !!!\nTekrar");
                                        }
                                        else
                                            break;
                                    }

                                    string m_ad;
                                    string m_soyad = "";
                                    int sefer_no;
                                    string kalkis_yeri = "";
                                    string inis_yeri = "";
                                    do
                                    {
                                        do
                                        {
                                            Console.Write("Müşteri Adı(En az 2 karakter girişi olmalı): ");
                                            m_ad = Console.ReadLine().ToUpper();
                                            if (string.IsNullOrWhiteSpace(m_ad))
                                            {
                                                Console.WriteLine("Hata: Müşteri adı boş bırakılamaz!");
                                            }
                                            else if (m_ad.Length < 2)
                                            {
                                                Console.WriteLine("Hata: Müşteri adı en az 2 karakter olmalıdır!");
                                            }
                                            else if (int.TryParse(m_ad, out _))
                                            {
                                                Console.WriteLine("Hata: Müşteri adı sayı içeremez!");
                                                m_ad = null;
                                            }
                                        } while (string.IsNullOrWhiteSpace(m_ad));

                                        do
                                        {
                                            Console.Write("Müşteri Soyadı(En az 2 karakter girişi olmalı): ");
                                            m_soyad = Console.ReadLine().ToUpper();
                                            if (string.IsNullOrWhiteSpace(m_soyad))
                                            {
                                                Console.WriteLine("Hata: Müşteri soyadı boş bırakılamaz!");
                                            }
                                            else if (m_soyad.Length < 2)
                                            {
                                                Console.WriteLine("Hata: Müşteri soyadı en az 2 karakter olmalıdır!");
                                            }
                                            else if (int.TryParse(m_soyad, out _))
                                            {
                                                Console.WriteLine("Hata: Müşteri soyadı sayı içeremez!");
                                                m_soyad = null;
                                            }
                                        } while (string.IsNullOrWhiteSpace(m_soyad));



                                        string seferNoStr;
                                    do
                                    {
                                        Console.Write("Sefer NO: ");
                                        seferNoStr = Console.ReadLine().ToUpper();
                                            if (!int.TryParse(seferNoStr, out sefer_no))
                                        {
                                            Console.WriteLine("Hata: Geçersiz sefer numarası!");
                                        }
                                    } while (!int.TryParse(seferNoStr, out sefer_no));

                                        do
                                        {
                                            Console.Write("Kalkış Yeri(En az 2 karakter girişi olmalı): ");
                                            kalkis_yeri = Console.ReadLine().ToUpper();
                                            if (string.IsNullOrWhiteSpace(kalkis_yeri))
                                            {
                                                Console.WriteLine("Hata: Kalkış yeri boş bırakılamaz!");
                                            }
                                            else if (kalkis_yeri.Length < 2)
                                            {
                                                Console.WriteLine("Hata: Kalkış yeri en az 2 karakter olmalı!");
                                                kalkis_yeri = null;
                                            }
                                            else if (int.TryParse(kalkis_yeri, out _))
                                            {
                                                Console.WriteLine("Hata: Kalkış yeri sayı içeremez!");
                                                kalkis_yeri = null;
                                            }
                                        } while (string.IsNullOrWhiteSpace(kalkis_yeri));


                                        do
                                        {
                                            Console.Write("İniş Yeri(En az 2 karakter girişi olmalı): ");
                                            inis_yeri = Console.ReadLine().ToUpper();
                                            if (string.IsNullOrWhiteSpace(inis_yeri))
                                            {
                                                Console.WriteLine("Hata: İniş yeri boş bırakılamaz!");
                                            }
                                            else if (inis_yeri.Length < 2)
                                            {
                                                Console.WriteLine("Hata: İniş yeri en az 2 karakter olmalı!");
                                                inis_yeri = null;
                                            }
                                            else if (int.TryParse(inis_yeri, out _))
                                            {
                                                Console.WriteLine("Hata: İniş yeri sayı içeremez!");
                                                inis_yeri = null;
                                            }
                                        } while (string.IsNullOrWhiteSpace(inis_yeri));
                                        bool biletVar = Biletler.Any(p => string.Equals(p.Split('#')[0], m_ad, StringComparison.OrdinalIgnoreCase) &&
                                   string.Equals(p.Split('#')[1], m_soyad, StringComparison.OrdinalIgnoreCase) &&
                                      int.Equals(int.Parse(p.Split('#')[2]), sefer_no) &&
                                   string.Equals(p.Split('#')[3], kalkis_yeri, StringComparison.OrdinalIgnoreCase) &&
                                   string.Equals(p.Split('#')[4], inis_yeri, StringComparison.OrdinalIgnoreCase));


                                        if (biletVar)
                                        {
                                            Console.WriteLine("Hata: Böyle bir bilet bulunuyor!");
                                            string devamEt;
                                            do
                                            {
                                                Console.Write("Devam etmek istiyor musunuz? (E/H):\n ");
                                                devamEt = Console.ReadLine().ToUpper();
                                            } while (devamEt != "E" && devamEt != "H");


                                            if (devamEt == "H")
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Üst menüye dönülüyor......\n");
                                                string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                                string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                                string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                                try
                                                {
                                                    SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                    player3.PlaySync();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Hata: " + ex.Message);
                                                }
                                                Console.Clear();
                                                goto ustMenu;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    } while (true);
                                    DateTime KalkisTarih;
                                    bool isValidDate = false;
                                    do
                                    {
                                        Console.Write("Kalkış Tarihi (gg.aa.yyyy): ");
                                        string tarihStr = Console.ReadLine().ToUpper();
                                        if (DateTime.TryParseExact(tarihStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out KalkisTarih))
                                        {
                                            isValidDate = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hata: Geçersiz tarih formatı, lütfen gg.aa.yyyy formatında girin.");
                                        }
                                    } while (!isValidDate);
                                    string KalkisSaat;
                                    bool gecerliSaatGirildi = false;
                                    do
                                    {
                                        Console.Write("Kalkış saati (HH:mm): ");
                                        KalkisSaat = Console.ReadLine().ToUpper();

                                        if (KalkisSaat.Length == 5 && KalkisSaat[2] == ':')
                                        {
                                            string saatStr = KalkisSaat.Substring(0, 2);
                                            string dakikaStr = KalkisSaat.Substring(3, 2);

                                            int saat, dakika;
                                            if (int.TryParse(saatStr, out saat) && int.TryParse(dakikaStr, out dakika))
                                            {
                                                gecerliSaatGirildi = true;
                                                Console.WriteLine("Kalkış saati: " + saat + ":" + dakika);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Hata: Geçersiz saat değeri!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hata: Saat değerini HH:mm formatında girin!");
                                        }
                                    } while (!gecerliSaatGirildi);
                                    string koltukNoStr;
                                    int koltuk_no;
                                    do
                                    {
                                    do
                                    {
                                        Console.Write("Koltuk NO: ");
                                        koltukNoStr = Console.ReadLine().ToUpper();
                                            if (!int.TryParse(koltukNoStr, out koltuk_no))
                                        {
                                            Console.WriteLine("Hata: Geçersiz koltuk numarası!");
                                        }
                                    } while (!int.TryParse(koltukNoStr, out koltuk_no));
                                        bool koltukVar = Biletler.Any(p =>
                                        int.Equals(int.Parse(p.Split('#')[2]), sefer_no) &&
                                        int.Equals(int.Parse(p.Split('#')[7]), koltuk_no) &&
                                        string.Equals(p.Split('#')[3], kalkis_yeri, StringComparison.OrdinalIgnoreCase) &&
                                        string.Equals(p.Split('#')[4], inis_yeri, StringComparison.OrdinalIgnoreCase) &&
                                        DateTime.Parse(p.Split('#')[5]) == KalkisTarih);
                                        if (koltukVar)
                                        {
                                            Console.WriteLine("Hata: Böyle bir koltuk bulunuyor!");
                                            string devamEt;
                                            do
                                            {
                                                Console.Write("Devam etmek istiyor musunuz? (E/H):\n ");
                                                devamEt = Console.ReadLine().ToUpper();
                                            } while (devamEt != "E" && devamEt != "H");


                                            if (devamEt == "H")
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Üst menüye dönülüyor......\n");
                                                string kullaniciAdi3 = Environment.UserName;
                                                string dosyaAdi3 = "ust2.wav";
                                                string dosyaYolu3 = Path.Combine("C:\\Users", kullaniciAdi3, "source\\repos\\Hava_alani_projesi\\Hava_alani_projesi\\music", dosyaAdi3);

                                                try
                                                {
                                                    SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                    player3.PlaySync();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Hata: " + ex.Message);
                                                }
                                                Console.Clear();
                                                goto ustMenu;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    } while (true);
                                    Biletler.Insert(siraNo - 1, m_ad + "#" + m_soyad + "#" + sefer_no + "#" + kalkis_yeri + "#" + inis_yeri + "#" + KalkisTarih + "#" + KalkisSaat + "#" + koltuk_no);
                                    BiletiDosyayaYaz();
                                    Console.Clear();
                                    Console.Write("BİLET {0}. sıraya eklendi.\nYeni Ekleme Yapmak İstiyor Musunuz?(E-H)\n", siraNo);
                                    string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                    string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "itamam.wav");

                                    try
                                    {
                                        SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                        player6.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    do
                                    {
                                        yeniEklensinMi = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (yeniEklensinMi != "E" && yeniEklensinMi != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                            Console.Write("Yeni Araya Ekleme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                        }
                                    } while (yeniEklensinMi != "E" && yeniEklensinMi != "H");
                                }
                                while (yeniEklensinMi == "E");
                            }
                            else
                            {
                                Console.WriteLine("Hata: Dosyada kayıtlı girdi bulunamadı!");
                                Console.WriteLine("Bir tuşa basarak bir önceki menüye dönün...");
                                string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "bilethata.wav");

                                try
                                {
                                    SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                    player0.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                Console.ReadKey();
                                Console.Clear();
                            }
                            
                            }
                        else if (altSecim == "6")
                        {
                            Console.Clear();
                            string araSec = "";
                            while (araSec != "Ç")
                            {
                                Console.Clear();
                                Console.WriteLine("--Arama İşlemleri----------");
                                Console.WriteLine("1-Müşteri Ad'a göre Ara");
                                Console.WriteLine("2-Müşteri Soy Ad'a göre Ara");
                                Console.WriteLine("3-Sefer NO' a göre Ara");
                                Console.WriteLine("4-Kalkış Yerine göre Ara");
                                Console.WriteLine("5-İniş Yerine göre Ara");
                                Console.WriteLine("6-Tarihe göre Ara");
                                Console.WriteLine("7-Saate göre Ara");
                                Console.WriteLine("8-Koltuk NO' a göre Ara");
                                Console.WriteLine("0-Herşeyde Ara");
                                Console.WriteLine("Ç-Üst Menüye Dön");
                                Console.Write("Seçiminiz:");
                                string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                                string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "bul.wav");

                                try
                                {
                                    SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                    player1.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                araSec = Console.ReadLine().ToUpper();
                                string ara = "";
                                if (File.ReadAllText("Biletler.txt").Trim() == "")
                                {
                                    Console.WriteLine("Hata: Dosyanın içi boş!");
                                    Console.WriteLine("Bir tuşa basarak devam edin...");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "bilethata.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                else if (araSec == "1")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Adı Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine().ToUpper();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    BiletAra(0, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }

                                else if (araSec == "2")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Soy Adı Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine().ToUpper();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    BiletAra(1, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }

                                else if (araSec == "3")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Sefer NO Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine().ToUpper();

                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                        else if (!int.TryParse(ara, out _))
                                        {
                                            Console.WriteLine("Hata: Geçersiz sayı girişi!");
                                        }
                                    } while (ara.Length < 2 || !int.TryParse(ara, out _));

                                    Console.Clear();
                                    BiletAra(2, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }
                                else if (araSec == "4")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Kalkış Yerini Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine().ToUpper();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    BiletAra(3, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }
                                else if (araSec == "5")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak İniş Yerini Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine().ToUpper();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    BiletAra(4, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }
                                else if (araSec == "6")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Tarihi Giriniz (gg.aa.yyyy formatında): ");
                                        string tarihStr = Console.ReadLine();
                                        if (DateTime.TryParseExact(tarihStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tarih))
                                        {
                                            ara = tarih.ToString("dd.MM.yyyy");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hata: Geçersiz tarih formatı, lütfen gg.aa.yyyy formatında girin.");
                                        }
                                    } while (ara.Length < 4);
                                    Console.Clear();
                                    BiletAra(5, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }
                                else if (araSec == "7")
                                {
                                    string KalkisSaati;
                                    bool gecerliSaatGirildi = false;
                                    do
                                    {
                                        Console.Write("Kalkış saati (HH:mm): ");
                                        KalkisSaati = Console.ReadLine();

                                        if (KalkisSaati.Length == 5 && KalkisSaati[2] == ':')
                                        {
                                            string saatStr = KalkisSaati.Substring(0, 2);
                                            string dakikaStr = KalkisSaati.Substring(3, 2);

                                            int saat, dakika;
                                            if (int.TryParse(saatStr, out saat) && int.TryParse(dakikaStr, out dakika))
                                            {
                                                gecerliSaatGirildi = true;
                                                Console.WriteLine("Kalkış saati: " + saat + ":" + dakika);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Hata: Geçersiz saat değeri!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hata: Saat değerini HH:mm formatında girin!");
                                        }
                                    } while (!gecerliSaatGirildi);

                                    ara = KalkisSaati;
                                    Console.Clear();
                                    BiletAra(6, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }
                                else if (araSec == "8")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Koltuk NO Giriniz (en az 1 karakter): ");
                                        ara = Console.ReadLine().ToUpper();

                                        if (ara.Length < 1)
                                        {
                                            Console.WriteLine("Hata: En az 1 karakter girmelisiniz!");
                                        }
                                        else if (!int.TryParse(ara, out _))
                                        {
                                            Console.WriteLine("Hata: Geçersiz sayı girişi!");
                                        }
                                    } while (ara.Length < 1 || !int.TryParse(ara, out _));

                                    Console.Clear();
                                    BiletAra(7, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }
                                else if (araSec == "0")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Metni Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    BiletAra(0, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }
                                else if (araSec == "Ç")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Üst menüye dönülüyor..\nBir tuşa basınız....");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "ust.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Yanlış seçim yaptınız...Menü için bir tuşa basınız...\n\n");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "ysecim.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }                        
                            }
                        }
                        else if (altSecim == "7")
                        {
                            Console.Clear();
                            Console.WriteLine("\nBiletler Sıralı Listesi-------");
                            List<string> siraliBilet = new List<string>();
                            siraliBilet.AddRange(Biletler);
                            siraliBilet.Sort();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "sırala.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            if (siraliBilet.Count == 0)
                            {
                                Console.WriteLine("Hata: Kayıt bulunamadı!");
                                string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hkayıt.wav");

                                try
                                {
                                    SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                    player0.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < siraliBilet.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + ")- " + siraliBilet[i]);
                                }
                                while (true)
                                {
                                    Console.Write("Orjinal listedeki kayıtların da sıralanmasını istiyor musunuz? (E-H): \n");
                                    string cevap = Console.ReadLine().ToUpper();

                                    if (cevap == "E")
                                    {
                                        Biletler = siraliBilet;
                                        Console.Clear();
                                        Console.WriteLine("Listeniz sıralanmıştır.");
                                        break;
                                    }
                                    else if (cevap == "H")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Geçersiz bir giriş yaptınız. Lütfen 'E' veya 'H' giriniz.\n");
                                    }
                                }
                            }
                        }                        
                        else if (altSecim == "8")
                        {
                            Console.Clear();
                            Console.WriteLine("\nBilet Listesi-------");
                            BiletListele();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "list.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            if (Biletler.Count == 0)
                            {
                                Console.WriteLine("Hata: Kayıt bulunamadı!");
                                string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hkayıt.wav");

                                try
                                {
                                    SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                    player0.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (altSecim == "9")
                        {
                            Console.Clear();
                            Console.WriteLine("Ana menüye dönülüyor......\n Devam etmek için bir tuşa basınız...");
                            string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                            string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "main.wav");

                            try
                            {
                                SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                player0.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            break;
                        }
                        else if (altSecim == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("Uygulamadan Çıkış Yapılıyor......\nÇıkış yapmak istiyor musunuz?(E-H)\n");
                            string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                            string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "exit2.wav");

                            try
                            {
                                SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                player0.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            string cevap;
                            do
                            {
                                cevap = Console.ReadLine()?.ToUpper();
                                Console.Clear();

                                if (cevap != "E" && cevap != "H")
                                {
                                    Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                }
                            } while (cevap != "E" && cevap != "H");


                            if (cevap == "H")
                            {
                                altSecim = "11";
                            }
                            else
                            {
                                Console.WriteLine("Bir tuşa basınız...\n");
                                Environment.Exit(0);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Hatalı seçim yaptınız...!");
                        }
                    }
                }

                else if (anaSecim == "H")
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (File.Exists("Havaalanlari.txt") == false)
                    {
                        StreamWriter sw = new StreamWriter("Havaalanlari.txt", false, Encoding.Default);
                        sw.Close();
                        Console.WriteLine("Havaalanı dosyası bulunamadı. Dosya oluşturuldu...");
                    }
                    else
                    {
                        Console.Clear();
                        StreamReader sr = new StreamReader("Havaalanlari.txt", Encoding.Default);
                        string oku = "";
                        Console.WriteLine("Dosyadaki Havaalanı Bilgisi Sayısı");
                        int i = 0;
                        while ((oku = sr.ReadLine()) != null)
                        {
                            Havaalanları.Add(oku);
                            Console.WriteLine(++i + "-" + oku);
                        }
                        sr.Close();
                        Console.Clear();
                        Console.WriteLine("Dosyadan {0} kayıt okundu", i);
                    }
                    while (altSecim != "0")
                    {
                        ustMenu:
                        Console.WriteLine("          _  _\r\n         ( `   )_\r\n        (    )    `)\r\n      (_   (_ .  _) _)\r\n                                     _\r\n                                    (  )\r\n     _ .                         ( `  ) . )\r\n   (  _ )_                      (_, _(  ,_)_)\r\n (_  _(_ ,)");
                        Console.WriteLine("#  Havaalanı İşlemleri Menüsü  #");
                        Console.WriteLine("1-Ekleme");
                        Console.WriteLine("2-Silme");
                        Console.WriteLine("3-Güncelleme");
                        Console.WriteLine("4-Tümünü Silme");
                        Console.WriteLine("5-Araya Ekle");
                        Console.WriteLine("6-Bul");
                        Console.WriteLine("7-Sırala");
                        Console.WriteLine("8-Listeleme");
                        Console.WriteLine("9-Ana Menüye Dön");
                        Console.WriteLine("0-Çıkış");
                        Console.WriteLine("Seçiminiz: ");
                        string projeDizini11 = AppDomain.CurrentDomain.BaseDirectory;
                        string musicKlasorDizini11 = Path.Combine(projeDizini11, "music");
                        string dosyaYolu11 = Path.Combine(musicKlasorDizini11, "hi.wav");
                        try
                        {
                            SoundPlayer player11 = new SoundPlayer(dosyaYolu11);
                            player11.PlaySync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hata: " + ex.Message);
                        }
                        altSecim = Console.ReadLine().ToUpper();
                        if (altSecim == "1")
                        {
                            Console.Clear();
                            string yeniEklensinMi = "E";
                            do
                            {
                                HavaalaniListele();
                                string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini1 = Path.Combine(projeDizini11, "music");
                                string dosyaYolu1 = Path.Combine(musicKlasorDizini11, "ekl.wav");

                                try
                                {
                                    SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                    player1.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                string h_ad="";
                                int h_tel = 0;
                                string h_sehir="";
                                do
                                {
                                    do
                                    {
                                        Console.Write("Havaalanı Adı(En az 3 karakter girişi olmalı): ");
                                        h_ad = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(h_ad))
                                        {
                                            Console.WriteLine("Hata: Havaalanı adı boş bırakılamaz!");
                                        }
                                        else if (h_ad.Length < 3)
                                        {
                                            Console.WriteLine("Hata: Havaalanı adı en az 3 karakter olmalı!");
                                            h_ad = null;
                                        }
                                        else if (int.TryParse(h_ad, out _))
                                        {
                                            Console.WriteLine("Hata: Havaalanı adı sayı içeremez!");
                                            h_ad = null;
                                        }
                                    } while (string.IsNullOrWhiteSpace(h_ad));


                                    Console.Write("Havalimanı Telefon Numarasını Boşluksuz Giriniz (en az 9 karakter, örnek havalimanı telefon numarası: '455 000 000'):\n ");
                                bool isValidHTel = false;
                                do
                                {
                                    string hTelStr = Console.ReadLine().ToUpper();
                                        if (hTelStr.Length >= 9 && int.TryParse(hTelStr, out h_tel))
                                    {
                                        isValidHTel = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Geçersiz Havaalanı TEL değeri! En az 9 karakter boşluksuz girilmeli ve sayı olmalıdır.");
                                        Console.Write("Havaalanı TEL: ");
                                    }
                                } while (!isValidHTel);


                                    Console.Write("Havaalanı Şehir(En az 2 karakter girişi olmalı): ");
                                    do
                                    {
                                        h_sehir = Console.ReadLine().ToUpper();
                                        if (string.IsNullOrWhiteSpace(h_sehir))
                                        {
                                            Console.WriteLine("Hata: Havaalanı şehir boş bırakılamaz!");
                                            Console.Write("Havaalanı Şehir: ");
                                        }
                                        else if (h_sehir.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Havaalanı şehir en az 2 karakter olmalı!");
                                            h_sehir = null;
                                            Console.Write("Havaalanı Şehir: ");
                                        }
                                        else if (int.TryParse(h_sehir, out _))
                                        {
                                            Console.WriteLine("Hata: Havaalanı şehir sayı içeremez!");
                                            h_sehir = null;
                                            Console.Write("Havaalanı Şehir: ");
                                        }
                                    } while (string.IsNullOrWhiteSpace(h_sehir));


                                    bool havaVar = Havaalanları.Any(p => string.Equals(p.Split('#')[0], h_ad, StringComparison.OrdinalIgnoreCase) &&
                                                                       int.Equals(int.Parse(p.Split('#')[1]), h_tel) &&
                                                                      string.Equals(p.Split('#')[2], h_sehir, StringComparison.OrdinalIgnoreCase));

                                    if (havaVar)
                                    {
                                        Console.WriteLine("Hata: Böyle bir havaalanı bilgisi bulunuyor!");
                                        string devamEt;
                                        do
                                        {
                                            Console.Write("Devam etmek istiyor musunuz? (E/H): \n");
                                            devamEt = Console.ReadLine().ToUpper();
                                            Console.Clear();
                                        } while (devamEt != "E" && devamEt != "H");


                                        if (devamEt == "H")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Üst menüye dönülüyor......\n");
                                            string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                            string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                            string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                            try
                                            {
                                                SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                player3.PlaySync();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Hata: " + ex.Message);
                                            }
                                            Console.Clear();
                                            goto ustMenu;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);

                                Havaalanları.Add(h_ad + "#" + h_tel + "#" + h_sehir);
                                StreamWriter sw = new StreamWriter("Havaalanlari.txt", true, Encoding.Default);
                                sw.WriteLine(h_ad + "#" + h_tel + "#" + h_sehir);
                                sw.Close();
                                do
                                {
                                    Console.WriteLine("Yeni Havaalanı Bilgisi Eklendi.\nYeni ekleme yapmak istiyor musunuz (E-H)");
                                    yeniEklensinMi = Console.ReadLine().ToUpper();
                                    Console.Clear();
                                    if (yeniEklensinMi != "E" && yeniEklensinMi != "H")
                                    {
                                        Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                    }
                                } while (yeniEklensinMi != "E" && yeniEklensinMi != "H");
                            } while (yeniEklensinMi == "E");
                        }
                        else if (altSecim == "2")
                        {
                            Console.Clear();
                            string yeniSilinsinMi = "E";
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "sil.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            do
                            {
                                if (Havaalanları.Count == 0)
                                {
                                    Console.WriteLine("Hata: Kayıt bulunamadı! Önce havaalanı listesi oluşturun.");
                                    Console.WriteLine("Bir tuşa basarak devam edin...");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "havahata.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                HavaalaniListele();
                                int siraNo = 0;
                                while (true)
                                {
                                    Console.Write("Silmek istediğiniz sıra numarası:");
                                    if (int.TryParse(Console.ReadLine(), out siraNo) == false)
                                    {
                                        Console.Write("Sıra numarası düzgün biçimde girilmemiş !!!\nTekrar ");
                                    }
                                    else if (siraNo < 1 || siraNo > Havaalanları.Count)
                                    {
                                        Console.Write("Sıra numarası aralık dışında seçilmiş. !!!\nTekrar");
                                    }
                                    else
                                        break;
                                }
                                Havaalanları.RemoveAt(siraNo - 1);
                                HavaalaniDosyayaYaz();

                                Console.Write("{0}. sıradaki Havaalanı silindi.\nYeni Silme İşlemi Yapmak İstiyor Musunuz?(E-H)\n", siraNo);
                                string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "ksilindi.wav");

                                try
                                {
                                    SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                    player6.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                do
                                {
                                    yeniSilinsinMi = Console.ReadLine().ToUpper();
                                    Console.Clear();
                                    if (yeniSilinsinMi != "E" && yeniSilinsinMi != "H")
                                    {
                                        Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                        Console.Write("Yeni Silme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                    }
                                } while (yeniSilinsinMi != "E" && yeniSilinsinMi != "H");
                            }
                            while (yeniSilinsinMi == "E");
                        }
                        else if (altSecim == "3")
                        {
                            Console.Clear();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "gnc.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            Console.WriteLine("Güncelleme işlmeleri--------------\n");
                            string yeniGuncellensinMi = "E";
                            do
                            {
                                if (!File.Exists("Havaalanlari.txt") || Havaalanları.Count == 0)
                                {
                                    Console.WriteLine("Hata: Kayıt bulunamadı! Önce havaalanı listesi oluşturun.");
                                    Console.WriteLine("Bir tuşa basarak devam edin...");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "havahata.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                HavaalaniListele();
                                int siraNo = 0;
                                while (true)
                                {
                                    Console.Write("Güncellemek istediğiniz sıra numarası:");
                                    if (int.TryParse(Console.ReadLine(), out siraNo) == false)
                                    {
                                        Console.Write("Sıra numarası düzgün biçimde girilmemiş !!!\nTekrar ");
                                    }
                                    else if (siraNo < 1 || siraNo > Havaalanları.Count)
                                    {
                                        Console.Write("Sıra numarası aralık dışında seçilmiş. !!!\nTekrar");
                                    }
                                    else
                                        break;
                                }
                                string guncellenecekBilgi = Havaalanları[siraNo - 1];
                                string[] parca = guncellenecekBilgi.Split('#');
                                Console.WriteLine("Havaalanı Adı: " + parca[0]);
                                string h_ad = "";
                                int h_tel = 0;
                                string h_sehir = "";
                                do
                                {
                                    do
                                    {
                                        Console.Write("Yeni Havaalanı Adı(En az 3 karakter girişi olmalı): ");
                                        h_ad = Console.ReadLine().ToUpper();

                                        if (string.IsNullOrWhiteSpace(h_ad))
                                        {
                                            Console.WriteLine("Hata: Havaalanı Adı boş bırakılamaz!");
                                        }
                                        else if (h_ad.Length < 3)
                                        {
                                            Console.WriteLine("Hata: Havaalanı Adı en az 3 karakter olmalı!");
                                            h_ad = null;
                                        }
                                        else if (int.TryParse(h_ad, out _))
                                        {
                                            Console.WriteLine("Hata: Havaalanı Adı sayı içeremez!");
                                            h_ad = null;
                                        }
                                    } while (string.IsNullOrWhiteSpace(h_ad));



                                    bool isValidHTel = false;
                                do
                                {
                                    Console.WriteLine("Havaalanı TEL: " + parca[1]);
                                    Console.Write("Yeni Havaalanı TEL: ");
                                    string hTelStr = Console.ReadLine().ToUpper();

                                        if (hTelStr.Length >= 9 && int.TryParse(hTelStr, out h_tel))
                                        {
                                        isValidHTel = true;
                                        }
                                    else
                                    {
                                        Console.WriteLine("Hata: Geçersiz Havaalanı TEL değeri! En az 9 karakter boşluksuz girilmeli ve sayı olmalıdır.");
                                    }
                                } while (!isValidHTel);

                                    do
                                    {
                                        Console.WriteLine("Havaalanı Şehir: " + parca[2]);
                                        Console.Write("Yeni Havaalanı Şehir(En az 2 karakter girişi olmalı): ");
                                        h_sehir = Console.ReadLine().ToUpper();

                                        if (string.IsNullOrWhiteSpace(h_sehir))
                                        {
                                            Console.WriteLine("Hata: Havaalanı Şehir boş bırakılamaz!");
                                        }
                                        else if (h_sehir.Length < 2)
                                        {
                                            Console.WriteLine("Hata: Havaalanı Şehir en az 2 karakter olmalı!");
                                            h_sehir = null;
                                        }
                                        else if (int.TryParse(h_sehir, out _))
                                        {
                                            Console.WriteLine("Hata: Havaalanı Şehir sayı içeremez!");
                                            h_sehir = null;
                                        }
                                    } while (string.IsNullOrWhiteSpace(h_sehir));


                                    bool havaVar = Havaalanları.Any(p => string.Equals(p.Split('#')[0], h_ad, StringComparison.OrdinalIgnoreCase) &&
                                       int.Equals(int.Parse(p.Split('#')[1]), h_tel) &&
                                      string.Equals(p.Split('#')[2], h_sehir, StringComparison.OrdinalIgnoreCase));

                                    if (havaVar)
                                    {
                                        Console.WriteLine("Hata: Böyle bir havaalanı bilgisi bulunuyor!");
                                        string devamEt;
                                        do
                                        {
                                         Console.Clear();
                                            Console.Write("Devam etmek istiyor musunuz? (E/H):\n ");
                                            devamEt = Console.ReadLine().ToUpper();
                                        } while (devamEt != "E" && devamEt != "H");


                                        if (devamEt == "H")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Üst menüye dönülüyor......\n");
                                            string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                            string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                            string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                            try
                                            {
                                                SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                player3.PlaySync();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Hata: " + ex.Message);
                                            }
                                            Console.Clear();
                                            goto ustMenu;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);

                                Havaalanları.RemoveAt(siraNo - 1);
                                Havaalanları.Insert(siraNo - 1, h_ad + "#" + h_tel + "#" + h_sehir);
                                PersoneliDosyayaYaz();
                                Console.Write("{0}. sıradaki Havaalanı bilgisi güncellendi.\nYeni İşlem Yapmak İstiyor Musunuz?(E-H)\n", siraNo);
                                string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "itamam.wav");

                                try
                                {
                                    SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                    player6.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                do
                                {
                                    yeniGuncellensinMi = Console.ReadLine().ToUpper();
                                    Console.Clear();
                                    if (yeniGuncellensinMi != "E" && yeniGuncellensinMi != "H")
                                    {
                                        Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                        Console.Write("Yeni Güncelleme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                    }
                                } while (yeniGuncellensinMi != "E" && yeniGuncellensinMi != "H");
                            }
                            while (yeniGuncellensinMi == "E");
                        }
                        else if (altSecim == "4")
                        {
                            Console.Clear();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "tsil.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            Console.Write("Dosyadaki tüm kayıtlar silinecektir.\nDevam etmek istiyor musunuz ?(E-H):\n");
                            string cevap;
                            do
                            {
                                cevap = Console.ReadLine().ToUpper();
                                if (cevap != "E" && cevap != "H")
                                {
                                    Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                    Console.Write("Yeni Güncelleme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                }
                            } while (cevap != "E" && cevap != "H");
                            if (cevap == "E")
                            {
                                if (File.Exists("Havaalanlari.txt"))
                                {
                                    if (Havaalanları.Count > 0)
                                    {
                                        Havaalanları.Clear();
                                        StreamWriter sw = new StreamWriter("Havaalanlari.txt", false, Encoding.Default);
                                        sw.Close();
                                        Console.Clear();
                                        Console.WriteLine("Tüm havaalanı kayıtları silindi....\nDevam etmek için bir tuşa basınız.");
                                        string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                        string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                        string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "kayitsil.wav");
                                        try
                                        {
                                            SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                            player6.PlaySync();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Hata: " + ex.Message);
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Hata: Dosya içinde kayıt bulunamadı!");
                                        string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                        string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                        string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "h2.wav");

                                        try
                                        {
                                            SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                            player0.PlaySync();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Hata: " + ex.Message);
                                        }
                                        Console.Clear();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Hata: Dosya bulunamadı!");
                                }
                            }
                        }
                        else if (altSecim == "5")
                        {
                            Console.Clear();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "aekle.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            string yeniEklensinMi = "E";
                            if (File.Exists("Havaalanlari.txt") && new FileInfo("Havaalanlari.txt").Length > 0)
                            {
                                do
                                {
                                    HavaalaniListele();
                                    int siraNo = 0;
                                    while (true)
                                    {
                                        Console.Write("Eklemek istediğiniz sıra numarası:");
                                        if (int.TryParse(Console.ReadLine(), out siraNo) == false)
                                        {
                                            Console.Write("Sıra numarası düzgün biçimde girilmemiş !!!\nTekrar ");
                                        }
                                        else if (siraNo < 1 || siraNo > Havaalanları.Count)
                                        {
                                            Console.Write("Sıra numarası aralık dışında seçilmiş. !!!\nTekrar");
                                        }
                                        else
                                            break;
                                    }
                                    string h_ad = "";
                                    int h_tel = 0;
                                    string h_sehir = "";
                                    do
                                    {
                                    Console.Write("Havaalanı Ad: ");
                                        do
                                        {
                                            Console.Write("Yeni Havaalanı Adı(En az 3 karakter girişi olmalı): ");
                                            h_ad = Console.ReadLine().ToUpper();

                                            if (string.IsNullOrWhiteSpace(h_ad))
                                            {
                                                Console.WriteLine("Hata: Havaalanı Adı boş bırakılamaz!");
                                            }
                                            else if (h_ad.Length < 3)
                                            {
                                                Console.WriteLine("Hata: Havaalanı Adı en az 3 karakter olmalı!");
                                                h_ad = null;
                                            }
                                            else if (int.TryParse(h_ad, out _))
                                            {
                                                Console.WriteLine("Hata: Havaalanı Adı sayı içeremez!");
                                                h_ad = null;
                                            }
                                        } while (string.IsNullOrWhiteSpace(h_ad));


                                        Console.Write("Havalimanı Telefon Numarasını Boşluksuz Giriniz (en az 9 karakter, örnek havalimanı telefon numarası: '455 000 000'):\n ");
                                    bool isValidHTel = false;
                                    do
                                    {
                                        string hTelStr = Console.ReadLine().ToUpper();
                                            if (hTelStr.Length >= 9 && int.TryParse(hTelStr, out h_tel))
                                        {
                                            isValidHTel = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hata: Geçersiz Havaalanı TEL değeri! En az 9 karakter girilmeli ve sayı olmalıdır.");
                                            Console.Write("Havaalanı TEL: ");
                                        }
                                    } while (!isValidHTel);



                                        Console.Write("Havaalanı Şehir(En az 2 karakter girişi olmalı): ");
                                        do
                                        {
                                            h_sehir = Console.ReadLine().ToUpper();

                                            if (string.IsNullOrWhiteSpace(h_sehir))
                                            {
                                                Console.WriteLine("Hata: Havaalanı Şehir boş bırakılamaz!");
                                                Console.Write("Havaalanı Şehir: ");
                                            }
                                            else if (h_sehir.Length < 2)
                                            {
                                                Console.WriteLine("Hata: Havaalanı Şehir en az 2 karakter olmalı!");
                                                h_sehir = null;
                                                Console.Write("Havaalanı Şehir: ");
                                            }
                                            else if (int.TryParse(h_sehir, out _))
                                            {
                                                Console.WriteLine("Hata: Havaalanı Şehir sayı içeremez!");
                                                h_sehir = null;
                                                Console.Write("Havaalanı Şehir: ");
                                            }
                                        } while (string.IsNullOrWhiteSpace(h_sehir));


                                        bool havaVar = Havaalanları.Any(p => string.Equals(p.Split('#')[0], h_ad, StringComparison.OrdinalIgnoreCase) &&
                                                                    int.Equals(int.Parse(p.Split('#')[1]), h_tel) &&
                                                                    string.Equals(p.Split('#')[2], h_sehir, StringComparison.OrdinalIgnoreCase));

                                        if (havaVar)
                                        {
                                            Console.WriteLine("Hata: Böyle bir havaalanı bilgisi bulunuyor!");
                                            string devamEt;
                                            do
                                            {
                                                Console.Write("Devam etmek istiyor musunuz? (E/H):\n ");
                                                devamEt = Console.ReadLine().ToUpper();
                                            } while (devamEt != "E" && devamEt != "H");


                                            if (devamEt == "H")
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Üst menüye dönülüyor......\n");
                                                string projeDizini3 = AppDomain.CurrentDomain.BaseDirectory;
                                                string musicKlasorDizini3 = Path.Combine(projeDizini3, "music");
                                                string dosyaYolu3 = Path.Combine(musicKlasorDizini3, "ust2.wav");

                                                try
                                                {
                                                    SoundPlayer player3 = new SoundPlayer(dosyaYolu3);
                                                    player3.PlaySync();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Hata: " + ex.Message);
                                                }
                                                Console.Clear();
                                                goto ustMenu;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    } while (true);

                                    Havaalanları.Add(h_ad + "#" + h_tel + "#" + h_sehir);
                                    HavaalaniDosyayaYaz();
                                    Console.Clear();
                                    Console.Write("Havaalani bilgisi {0}. sıraya eklendi.\nYeni Ekleme Yapmak İstiyor Musunuz?(E-H)\n", siraNo);
                                    string projeDizini6 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini6 = Path.Combine(projeDizini6, "music");
                                    string dosyaYolu6 = Path.Combine(musicKlasorDizini6, "itamam.wav");

                                    try
                                    {
                                        SoundPlayer player6 = new SoundPlayer(dosyaYolu6);
                                        player6.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    do
                                    {
                                        yeniEklensinMi = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (yeniEklensinMi != "E" && yeniEklensinMi != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                            Console.Write("Yeni Araya Ekleme İşlemi Yapmak İstiyor Musunuz? (E-H)\n");
                                        }
                                    } while (yeniEklensinMi != "E" && yeniEklensinMi != "H");
                                }
                                while (yeniEklensinMi == "E");
                            }
                                 else
                                 {
                                    Console.WriteLine("Hata: Dosyada kayıtlı girdi bulunamadı!");
                                    Console.WriteLine("Bir tuşa basarak bir önceki menüye dönün...");
                                string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "havahata.wav");

                                try
                                {
                                    SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                    player0.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                Console.ReadKey();
                                Console.Clear();
                                 }
                        }                        
                        else if (altSecim == "6")
                        {
                            Console.Clear();
                            string araSec = "";
                            while (araSec != "Ç")
                            {
                                Console.WriteLine("--Arama İşlemleri----------");
                                Console.WriteLine("1-Havaalanı Ad'a göre Ara");
                                Console.WriteLine("2-Havaalanı TEL göre Ara");
                                Console.WriteLine("3-Havaalanı Şehire göre Ara");
                                Console.WriteLine("0-Herşeyde Ara");
                                Console.WriteLine("Ç-Üst Menüye Dön");
                                Console.Write("Seçiminiz:");
                                string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                                string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "bul.wav");

                                try
                                {
                                    SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                    player1.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                                araSec = Console.ReadLine().ToUpper();
                                string ara = "";
                                if (File.ReadAllText("Havaalanlari.txt").Trim() == "")
                                {
                                    Console.WriteLine("Hata: Dosyanın içi boş!");
                                    Console.WriteLine("Bir tuşa basarak devam edin...");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "havahata.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                if (araSec == "1")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Havalimanı Adını Giriniz (en az 3 karakter): ");
                                        ara = Console.ReadLine();
                                        if (ara.Length < 3)
                                        {
                                            Console.WriteLine("Hata: En az 3 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 3);
                                    Console.Clear();
                                    HavaalaniAra(0, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (araSec == "2")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Havalimanı Telefon Numarasını Boşluksuz Giriniz (en az 9 karakter, örnek havalimanı telefon numarası: '455 000 000'):\n ");
                                        ara = Console.ReadLine();
                                        if (ara.Length < 9)
                                        {
                                            Console.WriteLine("Hata: Telefon numarası en az 9 karakter olmalıdır!");
                                        }
                                    } while (ara.Length < 9);
                                    Console.Clear();
                                    HavaalaniAra(1, ara);
                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (araSec == "3")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Havalimanı Şehrini Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine();
                                        if (ara.Length < 2)
                                        {
                                            Console.WriteLine("Hata: En az 2 karakter girmelisiniz!");
                                        }
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    HavaalaniAra(2, ara);

                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (araSec == "0")
                                {
                                    do
                                    {
                                        Console.Write("Aranacak Metni Giriniz (en az 2 karakter): ");
                                        ara = Console.ReadLine();
                                    } while (ara.Length < 2);
                                    Console.Clear();
                                    HavaalaniAra(0, ara);

                                    Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                    string devam;
                                    do
                                    {
                                        devam = Console.ReadLine().ToUpper();
                                        Console.Clear();
                                        if (devam != "E" && devam != "H")
                                        {
                                            Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.\n");
                                            Console.WriteLine("Yeni arama yapmak istiyor musunuz? (E-H)\n");
                                        }
                                    } while (devam != "E" && devam != "H");
                                    if (devam != "E")
                                    {
                                        araSec = "Ç";
                                    }
                                }
                                else if (araSec == "Ç")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Üst menüye dönülüyor..\nBir tuşa basınız....");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "ust.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Yanlış seçim yaptınız...\n Menü için bir tuşa basınız...\n\n");
                                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "ysecim.wav");

                                    try
                                    {
                                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                        player0.PlaySync();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Hata: " + ex.Message);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }
                            }
                        }
                        else if (altSecim == "7")
                        {
                            Console.Clear();
                            Console.WriteLine("\nHavaalanları Sıralı Listesi-------");
                            List<string> siraliHavaalani = new List<string>();
                            siraliHavaalani.AddRange(Havaalanları);
                            siraliHavaalani.Sort();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "sırala.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            if (siraliHavaalani.Count == 0)
                            {
                                Console.WriteLine("Hata: Kayıt bulunamadı!");
                                string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hkayıt.wav");

                                try
                                {
                                    SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                    player0.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < siraliHavaalani.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + ")- " + siraliHavaalani[i]);
                                }
                                while (true)
                                {
                                    Console.Write("Orjinal listedeki kayıtların da sıralanmasını istiyor musunuz? (E-H): \n");
                                    string cevap = Console.ReadLine().ToUpper();

                                    if (cevap == "E")
                                    {
                                        Havaalanları = siraliHavaalani;
                                        Console.Clear();
                                        Console.WriteLine("Listeniz sıralanmıştır.");
                                        break;
                                    }
                                    else if (cevap == "H")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Geçersiz bir giriş yaptınız. Lütfen 'E' veya 'H' giriniz.\n");
                                    }
                                }
                            }
                        }                        
                        else if (altSecim == "8")
                        {
                            Console.Clear();
                            Console.WriteLine("\nHavaalanı Bilgi Listesi-------");
                            HavaalaniListele();
                            string projeDizini1 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini1 = Path.Combine(projeDizini1, "music");
                            string dosyaYolu1 = Path.Combine(musicKlasorDizini1, "list.wav");

                            try
                            {
                                SoundPlayer player1 = new SoundPlayer(dosyaYolu1);
                                player1.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            if (Havaalanları.Count == 0)
                            {
                                Console.WriteLine("Hata: Kayıt bulunamadı!");
                                string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                                string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                                string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "hkayıt.wav");

                                try
                                {
                                    SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                    player0.PlaySync();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Hata: " + ex.Message);
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (altSecim == "9")
                        {
                            Console.Clear();
                            Console.WriteLine("Ana menüye dönülüyor......\n Devam etmek için bir tuşa basınız...");
                            string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                            string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "main.wav");

                            try
                            {
                                SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                player0.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            break;
                            
                        }
                        else if (altSecim == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("Uygulamadan Çıkış Yapılıyor......\nÇıkış yapmak istiyor musunuz?(E-H)");
                            string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                            string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                            string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "exit2.wav");

                            try
                            {
                                SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                                player0.PlaySync();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                            string cevap;
                            do
                            {
                                cevap = Console.ReadLine()?.ToUpper();
                                Console.Clear();
                                if (cevap != "E" && cevap != "H")
                                {
                                    Console.WriteLine("Hata: Geçersiz giriş! Sadece 'E' veya 'H' giriniz.");
                                }
                            } while (cevap != "E" && cevap != "H");

                            if (cevap == "H")
                            {
                                altSecim = "11";
                            }
                            else
                            {
                                Console.WriteLine("Bir tuşa basınız...\n");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı seçim yaptınız...!");
                        }                        
                    }
                }
                else if (anaSecim == "Ç")
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.WriteLine("Uygulamadan çıkış yapılıyor...\n Bir tuşa basınız.\n");
                    Console.WriteLine("                    ____ \r\n                  .'* *.'\r\n               __/_*_*(_\r\n              / _______ \\\r\n             _\\_)/___\\(_/_ \r\n            / _((\\- -/))_ \\\r\n            \\ \\())(-)(()/ /\r\n             ' \\(((()))/ '\r\n            / ' \\)).))/ ' \\\r\n           / _ \\ - | - /_  \\\r\n          (   ( .;''';. .'  )\r\n          _\\\"__ /    )\\ __\"/_\r\n            \\/  \\   ' /  \\/\r\n             .'  '...' ' )\r\n              / /  |  \\ \\\r\n             / .   .   . \\\r\n            /   .     .   \\\r\n           /   /   |   \\   \\\r\n         .'   /    b    '.  '.\r\n     _.-'    /     Bb     '-. '-._ \r\n _.-'       |      BBb       '-.  '-. \r\n(________mrf\\____.dBBBb.________)____)");
                    string projeDizini0 = AppDomain.CurrentDomain.BaseDirectory;
                    string musicKlasorDizini0 = Path.Combine(projeDizini0, "music");
                    string dosyaYolu0 = Path.Combine(musicKlasorDizini0, "exit.wav");

                    try
                    {
                        SoundPlayer player0 = new SoundPlayer(dosyaYolu0);
                        player0.PlaySync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata: " + ex.Message);
                    }
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Hatali seçim yaptınız!\nLütfen tekrar seçim yapınız.");
                }
                Console.ReadKey();
            }
        }
        static void PersonelListele()
        {
            Console.WriteLine("Personel Kayıtları:");
            for (int i = 1; i <= Personeller.Count; i++)
            {
                Console.WriteLine(i + ")-" + Personeller[i - 1]);
            }
        }
        static void PersonelAra(int indis, string ara)
        {
            Console.WriteLine("-----Bulunan Kayıtlar-----------");
            int bulunan = 0;
            foreach (var item in Personeller)
            {
                string[] parca = item.ToUpper().Split('#');
                if (indis == 0)
                {
                    if (item.ToUpper().IndexOf(ara.ToUpper()) != -1)
                    {
                        Console.WriteLine(item);
                        bulunan++;
                    }
                }
                else
                {
                    if (parca[indis].IndexOf(ara.ToUpper()) != -1)
                    {
                        Console.WriteLine(item);
                        bulunan++;
                    }
                }
            }
            if (bulunan == 0)
                Console.WriteLine("Aranan kayıt bulunamadı");
            else
                Console.WriteLine("Aranan {0} kayıt bulundu", bulunan);


        }
        static void PersoneliDosyayaYaz()
        {
            StreamWriter sw = new StreamWriter("Personeller.txt", false, Encoding.Default);
            for (int i = 1; i <= Personeller.Count; i++)
            {
                sw.WriteLine(Personeller[i - 1]);
            }
            sw.Close();
        }

        static void BiletListele()
        {
            Console.WriteLine("Bilet Kayıtları:");
            for (int i = 1; i <= Biletler.Count; i++)
            {
                Console.WriteLine(i + ")-" + Biletler[i - 1]);
            }
        }
        static void BiletAra(int indis, string ara)
        {
            Console.WriteLine("-----Bulunan Kayıtlar-----------");
            int bulunan = 0;
            foreach (var item in Biletler)
            {
                string[] parca = item.ToUpper().Split('#');
                if (indis == 0)
                {
                    if (item.ToUpper().IndexOf(ara.ToUpper()) != -1)
                    {
                        Console.WriteLine(item);
                        bulunan++;
                    }
                }
                else
                {
                    if (parca[indis].IndexOf(ara.ToUpper()) != -1)
                    {
                        Console.WriteLine(item);
                        bulunan++;
                    }
                }
            }
            if (bulunan == 0)
                Console.WriteLine("Aranan kayıt bulunamadı");
            else
                Console.WriteLine("Aranan {0} kayıt bulundu", bulunan);


        }
        static void BiletiDosyayaYaz()
        {
            StreamWriter sw = new StreamWriter("Biletler.txt", false, Encoding.Default);
            for (int i = 1; i <= Biletler.Count; i++)
            {
                sw.WriteLine(Biletler[i - 1]);
            }
            sw.Close();
        }
        static void HavaalaniListele()
        {
            Console.WriteLine("Havaalanı Bilgisi Kayıtları:");
            for (int i = 1; i <= Havaalanları.Count; i++)
            {
                Console.WriteLine(i + ")-" + Havaalanları[i - 1]);
            }
        }
        static void HavaalaniAra(int indis, string ara)
        {
            Console.WriteLine("-----Bulunan Kayıtlar-----------");
            int bulunan = 0;
            foreach (var item in Havaalanları)
            {
                string[] parca = item.ToUpper().Split('#');
                if (indis == 0)
                {
                    if (item.ToUpper().IndexOf(ara.ToUpper()) != -1)
                    {
                        Console.WriteLine(item);
                        bulunan++;
                    }
                }
                else
                {
                    if (parca[indis].IndexOf(ara.ToUpper()) != -1)
                    {
                        Console.WriteLine(item);
                        bulunan++;
                    }
                }
            }
            if (bulunan == 0)
                Console.WriteLine("Aranan kayıt bulunamadı");
            else
                Console.WriteLine("Aranan {0} kayıt bulundu", bulunan);


        }
        static void HavaalaniDosyayaYaz()
        {
            StreamWriter sw = new StreamWriter("Havaalanlari.txt", false, Encoding.Default);
            for (int i = 1; i <= Havaalanları.Count; i++)
            {
                sw.WriteLine(Havaalanları[i - 1]);
            }
            sw.Close();
        }
    }
}
