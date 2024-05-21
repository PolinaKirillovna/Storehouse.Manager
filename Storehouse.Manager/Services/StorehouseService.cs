using System.Text.Json;
using Storehouse.Manager.Exceptions;
using Storehouse.Manager.Models;

namespace Storehouse.Manager.Services;

public class StorehouseService
{
    //Группировка всех паллетов по сроку годности
    //Сортировка по возрастанию срока годности
    //Сортировка в каждой группе по весу
    public IEnumerable<Pallet> SortPalletsByExpiryDateAndWeight(IEnumerable<Pallet> pallets)
    {
        if (!pallets.Any())
        {
            throw ServiceException.EmptyPallet();
        }

        return pallets
            .GroupBy(p => p.ExpiryDate)
            .OrderBy(g => g.Key)
            .SelectMany(g => g.OrderBy(p => p.Weight));
    }
    
    //Сортировка паллет по убыванию срока годности 
    //Сортировка по объему 
    //Выбор трех
    public IEnumerable<Pallet> GetPalletsWithLongestExpiryBoxes(IEnumerable<Pallet> pallets)
    {
        if (!pallets.Any())
        {
            throw ServiceException.EmptyPallet();
        }
        
        return pallets
            .Where(p => p.Boxes.Any())
            .OrderByDescending(p => p.Boxes.Max(b => b.ExpiryDate))
            .ThenBy(p => p.Volume)
            .Take(3);
    }

    public void SavePalletsToFile(IEnumerable<Pallet> pallets, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(pallets, options);
        File.WriteAllText(filePath, jsonString);
    }


    public IEnumerable<Pallet> LoadPalletsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The specified file does not exist.", filePath);
        }

        var jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<IEnumerable<Pallet>>(jsonString);
    }
}

