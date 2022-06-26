using B_1336.FindingConflicts.Entities;
using System.Text.Json;
using B_1336.FindingConflicts.Application.Interfaces;

namespace B_1336.FindingConflicts.Application;
public class JsonLoader : IDataLoader<DeviceInfo>, IDataUploader<Conflict>
{
    /// <summary>
    /// Десериализовать DeviceInfo.json
    /// </summary>
    public IEnumerable<DeviceInfo> LoadData()
    {
        using (FileStream file = new FileStream(@"..\..\Devices.json", FileMode.Open))
        {
            var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            List<DeviceInfo>? devicesInfo = JsonSerializer.Deserialize<List<DeviceInfo>>(file,option);
            return devicesInfo;
        }
    }
    /// <summary>
    /// Сереализовать список бригад с использованными каждой бригадой приборами(хотя бы 1 "В сети")
    /// </summary>
    public void UploadData(IEnumerable<Conflict> conflicts)
    {
        using (FileStream file = new FileStream("Conflict.json", FileMode.Create))
        {
            JsonSerializer.Serialize(file, conflicts);
        }
    }

}

