using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GidaAiProjesi
{
    // 1. Veri Şablonu (Model)
    public class AiReceteYaniti
    {
        public string YemekAdi { get; set; }
        public string Hazirlanis { get; set; }
        public double TahminiKalori { get; set; }
        public double TahminiProtein { get; set; }
    }

    // 2. Yapay Zeka Servis Katmanı
    public class GidaAiServisi
    {
        public async Task<AiReceteYaniti> ReceteVeBesinAnaliziUretAsync(List<string> malzemeler)
        {
            Console.WriteLine("\n[AI ENGINE] Malzemeler analiz ediliyor ve yapay zeka modeli tetikleniyor...");
            
            // Simüle edilmiş asenkron yapay zeka yanıtı
            await Task.Delay(2000); 

            return new AiReceteYaniti
            {
                YemekAdi = "Fit Yulaf & Yumurta Bowl",
                Hazirlanis = "Yulafları sıcak su ile demleyin. Yumurta aklarını haşlayıp üzerine ekleyin.",
                TahminiKalori = 420.0,
                TahminiProtein = 28.5
            };
        }
    }

    // 3. Ana Çalıştırma Programı
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("================================================================");
            Console.WriteLine("   C# .NET 8 & AI POWERED NUTRITION ENGINE (GIDA AI SERVİSİ)    ");
            Console.WriteLine("================================================================\n");

            List<string> elimdekiMalzemeler = new List<string> { "Yulaf", "Yumurta Akı", "Süt", "Muz" };

            Console.WriteLine("Girdi Yapılan Malzemeler: " + string.Join(", ", elimdekiMalzemeler));

            GidaAiServisi aiEngine = new GidaAiServisi();
            
            AiReceteYaniti sonuc = await aiEngine.ReceteVeBesinAnaliziUretAsync(elimdekiMalzemeler);

            Console.WriteLine("\n================================================================");
            Console.WriteLine("                   YAPAY ZEKA ANALİZ SONUCU                     ");
            Console.WriteLine("================================================================");
            Console.WriteLine($"Önerilen Tarif  : {sonuc.YemekAdi}");
            Console.WriteLine($"Hazırlanış      : {sonuc.Hazirlanis}");
            Console.WriteLine($"Makro / Kalori  : {sonuc.TahminiKalori} kcal");
            Console.WriteLine($"Protein Değeri  : {sonuc.TahminiProtein} g (Yüksek Protein)");
            Console.WriteLine("================================================================");

            Console.WriteLine("\nİşlem başarıyla tamamlandı. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
