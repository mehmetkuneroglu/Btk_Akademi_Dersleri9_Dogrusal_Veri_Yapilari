using Microsoft.Win32.SafeHandles;
using System.Collections;

internal class Program
{
    //Bir sınıfa bir arayüzden-(Interface) miras alarak işlem yapmak,
    //Arayüzden miras alındığında arayüzün metot ve özlellikleri sınıf
    //içerisine implemente edilmelidir/tanımlanmalıdır
    public class Sehir : IComparable<Sehir> 
    {
        public Sehir(int plakaNo, string sehirAdi)
        {
            PlakaNo = plakaNo;
            SehirAdi = sehirAdi;
        }

        public int PlakaNo { get; set; }
        public string SehirAdi { get; set; }

        public override string ToString()
        {
            return $" {PlakaNo,-14} {SehirAdi,-15}";
        }

        public int CompareTo(Sehir other) // İkili listeyi sıralamak için bu işlemi yapmak şart,
                                          // aksi taktirde sıralama yapamaz. interface sonucu 
        {

            if (this.PlakaNo<other.PlakaNo)
            {
                return -1;
            }                
            else if (this.PlakaNo==other.PlakaNo)
            {
                return 0;
            }
            else
            {
                return 1;
            }            
        }
    }
    private static void Main(string[] args)
    {
        // List<T> yapısı
        var liste = new List<int>() { 5,45,12,65,98,25,84};
        liste.ForEach(x => Console.Write($" {x,-5}"));
        liste.Sort();
        Console.WriteLine("\n\n Sıralama işleminden sonra\n");
        liste.ForEach(x => Console.Write($" {x,-5}"));

        var sehirler = new List<Sehir>()
        {
            new Sehir(06,"Ankara"),
            new Sehir(09,"Aydın"),
            new Sehir(32,"Isparta"),
            new Sehir(16,"Bursa"),
            new Sehir(07,"Antalya")
        };
        sehirler.Sort();
        Console.WriteLine("\n\n Plaka NO       Şehir\n");
        sehirler.ForEach(x => Console.WriteLine($"{x}"));

        Console.ReadKey();
    }

    #region Ornekler

    private static void sortedListOrnegiKitapIcerigi()
    {
        // sortedList uygulaması
        var kitapIcerigi = new SortedList()
        {
            {1,"Önsöz" },
            {50,"Değişkenler" },
            {60,"Döngüler" },
            {15,"Operatörler" },
            {25,"İlişkisel Operatörler" },
            {80,"Metotlar" },

        };
        Console.WriteLine($"{"  Konular",-35}{"|  Sayfa",12}");
        Console.WriteLine(new string('_', 50));
        foreach (DictionaryEntry item in kitapIcerigi)
        {
            Console.WriteLine($"\n   {item.Value,-35} |{item.Key,7}");
            Console.WriteLine(new string('.', 50));
        }
    }
    private static void shortedListTemelleriOrnegi()
    {
        // SortedList Temelleri
        //tanımlama
        var liste = new SortedList()
        {
            {1,"bir" },
            {2,"iki" },
            {4,"dört" },
            {8,"sekiz" },
            {3,"üç" },
            {5,"beş" },
            {7,"yedi" },
            {6,"altı" }


        };
        liste.Add(9, "dokuz"); // tekil ekleme yöntemi

        //dolaşma
        foreach (DictionaryEntry item in liste)
        {
            Console.WriteLine($"{item.Key,-3} - {item.Value,-10}");
        }
        Console.WriteLine("\nListedeki eleman sayısı     : {0}", liste.Count);
        Console.WriteLine("Listenin kapasitesi         : {0}", liste.Capacity);
        liste.TrimToSize();
        Console.WriteLine("Listenin kapasitesi         : {0}", liste.Capacity);
        Console.WriteLine(liste[4]); //key e bağlı olarak değer çağırma
        Console.WriteLine(liste.GetByIndex(4)); //indexe bağlı olarak değer çağırma
        Console.WriteLine(liste.GetKey(1)); // indexe bağlı keyi çağırma
        Console.WriteLine(liste.GetByIndex(liste.Count - 1)); // listenin sonuncu elemanı

        //Anahtarları alma
        Console.WriteLine("\nAnahtarlar");
        var anahtarlar = liste.Keys;
        foreach (var key in anahtarlar)
        {
            Console.WriteLine(key);
        }
        //Değerleri alma
        Console.WriteLine("\nDeğerler");
        var degerler = liste.Values;
        foreach (var value in degerler)
        {
            Console.WriteLine(value);
        }
        // değerleri güncelleme
        Console.WriteLine("\ndeğer değiştirme işleminden sonra 1");
        if (liste.ContainsKey(1))
        {
            liste[1] = "One";
        }
        foreach (DictionaryEntry item in liste)
        {
            Console.WriteLine($"{item.Key,-3} - {item.Value,-10}");
        }
        // değer silme
        Console.WriteLine("\nDeğer silme işlemi anahtara göre 5, indexe göre 2");
        liste.Remove(5);
        liste.RemoveAt(2);
        foreach (DictionaryEntry item in liste)
        {
            Console.WriteLine($"{item.Key,-3} - {item.Value,-10}");
        }
       
    }


   
    private static void hashTableIle_URL_TasarimiOrnegi()
    {

        //Hashtable Uygulaması
        // başlığı okuma / burada amacımız uygun bir URL oluşturmak olabilir
        Console.WriteLine("Bir başlık giriniz:");
        string baslik = Console.ReadLine();
        // yazıyı küçült
        baslik = baslik.ToLower();
        // Hashtable işlemi
        var karakterler = new Hashtable()
        {
            {'ç','c'},
            {'ğ','g'},
            {'ı','i'},
            {'ö','o'},
            {'ş','s'},
            {'ü','u'},
            {'.','-'},
            {'\'','-'},
            {',','-'},
            {'?','-'},
            {' ','-'}

        };
        foreach (DictionaryEntry item in karakterler)
        {
            baslik = baslik.Replace((char)item.Key, (char)item.Value);
        }
        Console.WriteLine(baslik);
    }

    private static void hashTableOrnegi()
    {
        // Hashtable- tanımlama
        var sehirler = new Hashtable();
        // değer atama
        sehirler.Add(6, "Ankara");
        sehirler.Add(9, "Aydın");
        sehirler.Add(32, "Isparta");
        sehirler.Add(34, "İstanbul");

        //Dolaşma
        foreach (DictionaryEntry item in sehirler) //DictionaryEntry ifadesine ulaşmak için döngüyü sadece item ile boş çalıştırdık
        {
            Console.WriteLine($"{item.Key,-5} - {item.Value,-20}");
        }
        Console.WriteLine();

        //Anahtarkları alma
        Console.WriteLine("Anahtarlar (Keys)");
        var anahtarlar = sehirler.Keys;
        foreach (var item in anahtarlar)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        //Değerleri alma
        Console.WriteLine("Değerler (Values)");
        ICollection degerler = sehirler.Values; // var değerine karşılık gelen değerin  ICollection olduğunu gördük
        foreach (var item in degerler)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        // Elemana erişme
        Console.WriteLine("Elemana erişme [9] anahtarı için değer");
        Console.WriteLine(sehirler[9]);

        //Eleman silme
        Console.WriteLine("\nEleman silme [34] anahtarı için değer silindi");
        sehirler.Remove(34);
        foreach (var item in degerler)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    private static void dizilerVeMetotlariOrnegi()
    {
        // Array - Dizi- Tanımlama

        int[] sayilar = new int[] { 5, 3, 8, 10, 2, 24, 55, 63, 51, 12 }; //tanımlama 1

        var numaralar = Array.CreateInstance(typeof(int), sayilar.Length); //tanımlama 2

        var arr = new ArrayList(sayilar);// ArrayList metodu bir koleksiyon-dizi alabildiği için diziyi içine ekledik

        numaralar.SetValue(-5, 0); //tanımlama 2 ye değer atama
        numaralar.SetValue(3, 1);
        numaralar.SetValue(8, 2);
        numaralar.SetValue(10, 3);
        numaralar.SetValue(-2, 4);



        //Dolaşma
        for (int i = 0; i < numaralar.Length; i++)
        {
            Console.WriteLine("sayılar[{0}]= {1} - numaralar[{0}]= {2}", i, sayilar[i], numaralar.GetValue(i));
        }

        // sıralama işlemi
        Array.Sort(sayilar);
        Array.Sort(numaralar);
        arr.Sort();

        //Alternatif dolaşma tekniği
        Console.WriteLine();
        for (int i = 0; i < numaralar.Length; i++)
        {
            Console.WriteLine(
                $"sayılar[{i}]= {sayilar[i],3}" +
                $" - numaralar[{i}]= {numaralar.GetValue(i),3}" +
                $" - arr[{i}]= {arr[i],3}");
        }
        Console.WriteLine();


        // dizileri kopyalama

        var yeniSayilar = Array.CreateInstance(typeof(int), sayilar.Length);
        sayilar.CopyTo(yeniSayilar, 0);
        Console.WriteLine("Kopyalama ileminden sonra");
        Console.WriteLine();
        for (int i = 0; i < yeniSayilar.Length; i++)
        {
            Console.WriteLine($"yenisayilar[{i}]= {yeniSayilar.GetValue(i),3}");
        }
        Console.WriteLine();
        // Dizilerde silme işlemi
        Console.WriteLine("Silme işleminden sonra");
        Console.WriteLine();
        Array.Clear(yeniSayilar, 2, 2);

        for (int i = 0; i < yeniSayilar.Length; i++)
        {
            Console.WriteLine($"yenisayilar[{i}]= {yeniSayilar.GetValue(i),3}");
        }
        Console.WriteLine();
        Console.WriteLine("Dizi içinde aranan index değeri / 55 değeri için");

        Console.WriteLine(Array.IndexOf(yeniSayilar, 55)); // bulunan değerin ilk index değerini döndürür
                                                           // eğer aranan değer listede yoksa -1 değeri döner
    }
    #endregion
}