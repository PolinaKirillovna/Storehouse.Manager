using Storehouse.Manager.Models;
using Storehouse.Manager.Services;

namespace Storehouse.Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание объектов паллет и коробок
            var box1 = new Box(10, 10, 10, 5, new DateTime(2023, 5, 1));
            var box2 = new Box(10, 10, 10, 5, new DateTime(2023, 5, 10));
            var box3 = new Box(10, 10, 10, 5, new DateTime(2023, 5, 15));
            
            var pallet1 = new Pallet(100, 50, 50);
            pallet1.AddBox(box1);
            pallet1.AddBox(box2);
            
            var pallet2 = new Pallet(100, 50, 50);
            pallet2.AddBox(box3);
            
            var pallets = new List<Pallet> { pallet1, pallet2 };

            // Сохранение коллекции паллет в файл
            var service = new StorehouseService();
            var filePath = "pallets.json";
            service.SavePalletsToFile(pallets, filePath);
            Console.WriteLine("Pallets saved to file.");


            var loadedPallets = service.LoadPalletsFromFile(filePath);
            Console.WriteLine("Pallets loaded from file.");
            
            var sortedPallets = service.SortPalletsByExpiryDateAndWeight(loadedPallets);
            Console.WriteLine("Pallets sorted by expiry date and weight:");
            foreach (var pallet in sortedPallets)
            {
                Console.WriteLine($"Pallet Expiry Date: {pallet.ExpiryDate}, Weight: {pallet.Weight}");
            }
            
            var topPallets = service.GetPalletsWithLongestExpiryBoxes(loadedPallets);
            Console.WriteLine("Top 3 pallets with longest expiry boxes sorted by volume:");
            foreach (var pallet in topPallets)
            {
                Console.WriteLine($"Pallet Volume: {pallet.Volume}, Expiry Date: {pallet.ExpiryDate}");
            }
        }
    }
}
