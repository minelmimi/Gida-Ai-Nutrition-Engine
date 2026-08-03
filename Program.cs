using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GidaAiProjesi
{
    public class AiReceteYaniti
    {
        public string YemekAdi { get; set; }
        public string Hazirlanis { get; set; }
        public double TahminiKalori { get; set; }
        public double TahminiProtein { get; set; }
    }

    public class GidaAiServisi
    {
        // 1. MOD: Sabit Yulaf Örneği (Demo)
        public async Task<AiReceteYaniti> SabitDemoAnaliziUretAsync()
        {
            Console.WriteLine("\n[AI ENGINE - DEMO] Hazır test verileri işleniyor...");
            await Task.Delay(1500);

            return new AiReceteYaniti
            {
                YemekAdi = "Fit Yulaf & Yumurta Bowl",
                Hazirlanis = "Yulafları sıcak su ile demleyin. Yumurta aklarını haşlayıp üzerine ekleyin.",
                TahminiKalori = 420.0,
                TahminiProtein = 28.5
            };
        }

        // 2. MOD: Kullanıcının Kendi Girdiği Malzemeler (Dinamik)
        public async Task<AiReceteYaniti> DinamikAnalizUretAsync(List<string> malzemeler, string hedefDiyet)
        {
            Console.WriteLine("\n[AI ENGINE - DİNAMİK] Girilen malzemeler ve diyet hedefi analiz ediliyor...");
            await Task.Delay(1500);

            string girdiMetni = string.Join(", ", malzemeler).ToLower();

            if (girdiMetni.Contains("tavuk") || girdiMetni.Contains("kıyma") || girdiMetni.Contains("et"))
            {
                return new AiReceteYaniti
                {
                    YemekAdi = "High-Protein Etli/Tavuklu Sote Bowl",
                    Hazirlanis = "Malzemeleri soteleyin, baharatlarla çeşnilendirip servis edin.",
                    TahminiKalori = 520.0,
                    TahminiProtein = 45.0
                };
            }
            else
            {
                return new AiReceteYaniti
                {
                    YemekAdi = $"Özel {hedefDiyet} Karışım Bowl",
                    Hazirlanis = $"{string.Join(", ", malzemeler)} malzemelerini karıştırarak pratik şekilde hazırlayın.",
                    TahminiKalori = 380.0,
                    TahminiProtein = 22.5
                };
            }
        }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("================================================================");
            Console.WriteLine("   C# .NET 8 & AI POWERED NUTRITION ENGINE                      ");
            Console.WriteLine("================================================================");
            Console.WriteLine("1 - Otomatik Demo Modu (Yulaf & Yumurta Örneği)");
            Console.WriteLine("2 - Canlı Mod (Kendi Malzemelerini Sen Gir)");
            Console.Write("\nLütfen bir mod seçin (1 veya 2 yazıp Enter'a basın): ");

            string secim = Console.ReadLine();
            GidaAiServisi aiEngine = new GidaAiServisi();
            AiReceteYaniti sonuc;

            if (secim == "1")
            {
                sonuc = await aiEngine.SabitDemoAnaliziUretAsync();
                EkranaYazdir("Yulaf, Yumurta Akı, Süt, Muz", "Yüksek Protein (Demo)", sonuc);
            }
            else
            {
                Console.Write("\nElinizdeki Malzemeleri Yazın (Virgülle ayırın): ");
                string girdi = Console.ReadLine();

                Console.Write("Hedef Diyet Tipi (Örn: Yüksek Protein, Ketojenik): ");
                string diyet = Console.ReadLine();

                List<string> malzemeler = new List<string>(girdi.Split(','));
                sonuc = await aiEngine.DinamikAnalizUretAsync(malzemeler, diyet);
                EkranaYazdir(string.Join(", ", malzemeler), diyet, sonuc);
            }

            Console.WriteLine("\nİşlem tamamlandı. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        private static void EkranaYazdir(string malzemeler, string diyet, AiReceteYaniti sonuc)
        {
            Console.WriteLine("\n================================================================");
            Console.WriteLine("                   YAPAY ZEKA ANALİZ SONUCU                     ");
            Console.WriteLine("================================================================");
            Console.WriteLine($"Girdi Verileri  : {malzemeler}");
            Console.WriteLine($"Hedef Diyet     : {diyet}");
            Console.WriteLine($"Önerilen Tarif  : {sonuc.YemekAdi}");
            Console.WriteLine($"Hazırlanış      : {sonuc.Hazirlanis}");
            Console.WriteLine($"Makro / Kalori  : {sonuc.TahminiKalori} kcal");
            Console.WriteLine($"Protein Değeri  : {sonuc.TahminiProtein} g");
            Console.WriteLine("================================================================");
        }
    }
}
