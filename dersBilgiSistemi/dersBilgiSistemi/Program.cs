internal class Program
{
    // Base Class
    public abstract class Kisi
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        // Ortak bir metot
        public abstract void BilgiGoster();
    }
    // Interface
    public interface ILogin
    {
        void Login();
    }
    // Öğrenci Sınıfı
    public class Ogrenci : Kisi, ILogin
    {
        public string Bolum { get; set; }

        public override void BilgiGoster()
        {
            Console.WriteLine($"Öğrenci ID: {ID}, Ad: {Ad}, Soyad: {Soyad}, Bölüm: {Bolum}");
        }

        public void Login()
        {
            Console.WriteLine($"Öğrenci {Ad} {Soyad} giriş yaptı.");
        }
    }
    // Öğretim Görevlisi Sınıfı
    public class OgretimGorevlisi : Kisi, ILogin
    {
        public string UzmanlikAlani { get; set; }

        public override void BilgiGoster()
        {
            Console.WriteLine($"Öğretim Görevlisi ID: {ID}, Ad: {Ad}, Soyad: {Soyad}, Uzmanlık Alanı: {UzmanlikAlani}");
        }

        public void Login()
        {
            Console.WriteLine($"Öğretim Görevlisi {Ad} {Soyad} giriş yaptı.");
        }
    }
    // Ders Sınıfı
    public class Ders
    {
        public string DersAdi { get; set; }
        public int Kredi { get; set; }
        public OgretimGorevlisi Ogretmen { get; set; }
        public List<Ogrenci> KayitliOgrenciler { get; set; } = new List<Ogrenci>();

        public void DersBilgisiGoster()
        {
            Console.WriteLine($"Ders Adı: {DersAdi}, Kredi: {Kredi}, Öğretim Görevlisi: {Ogretmen.Ad} {Ogretmen.Soyad}");
            Console.WriteLine("Kayıtlı Öğrenciler:");
            foreach (var ogrenci in KayitliOgrenciler)
            {
                Console.WriteLine($"- {ogrenci.Ad} {ogrenci.Soyad}");
            }
        }
    }
    private static void Main(string[] args)
    {
        // Öğretim Görevlisi Oluşturma
        var ogretimGorevlisi = new OgretimGorevlisi
        {
            ID = 1,
            Ad = "Ahmet",
            Soyad = "Yılmaz",
            UzmanlikAlani = "Matematik"
        };

        // Öğrenci Oluşturma
        var ogrenci1 = new Ogrenci
        {
            ID = 101,
            Ad = "Ali",
            Soyad = "Kaya",
            Bolum = "Bilgisayar Mühendisliği"
        };

        var ogrenci2 = new Ogrenci
        {
            ID = 102,
            Ad = "Ayşe",
            Soyad = "Demir",
            Bolum = "Bilgisayar Mühendisliği"
        };

        // Ders Oluşturma
        var ders = new Ders
        {
            DersAdi = "Programlama 101",
            Kredi = 4,
            Ogretmen = ogretimGorevlisi
        };

        // Öğrencileri derse ekleme
        ders.KayitliOgrenciler.Add(ogrenci1);
        ders.KayitliOgrenciler.Add(ogrenci2);

        // Bilgileri Gösterme
        Console.WriteLine("=== Öğretim Görevlisi Bilgisi ===");
        ogretimGorevlisi.BilgiGoster();

        Console.WriteLine("\n=== Öğrenci Bilgileri ===");
        ogrenci1.BilgiGoster();
        ogrenci2.BilgiGoster();

        Console.WriteLine("\n=== Ders Bilgisi ===");
        ders.DersBilgisiGoster();

        Console.WriteLine("\n=== Login Testi ===");
        ogretimGorevlisi.Login();
        ogrenci1.Login();
    }
}