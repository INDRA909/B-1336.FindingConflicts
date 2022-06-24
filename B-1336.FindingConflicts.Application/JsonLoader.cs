using B_1336.FindingConflicts.Entities;
using System.Text.Json;
using B_1336.FindingConflicts.Application.Interfaces;

namespace B_1336.FindingConflicts.Application;
public class JsonLoader : IDataLoader<DeviceInfo>, IDataUploader<Conflict>
{
    /// <summary>
    /// Десериализовать DeviceInfo.json
    /// </summary>
    public List<DeviceInfo> LoadData()
    {
        using (FileStream file = new FileStream(@"C:\Users\ivanr\OneDrive\Рабочий стол\Devices.json", FileMode.Open))
        {
            var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            List<DeviceInfo>? devicesInfo = JsonSerializer.Deserialize<List<DeviceInfo>>(file,option);
            return devicesInfo;
        }
    }
    /// <summary>
    /// Сереализовать список бригад с использованными каждой бригадой приборами(хотя бы 1 "В сети")
    /// </summary>
    public void UploadData(List<Conflict> conflicts)
    {
        using (FileStream file = new FileStream("Conflict.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<List<Conflict>>(file, conflicts);
        }
    }

}

