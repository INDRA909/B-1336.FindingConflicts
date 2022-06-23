using B_1336.FindingConflicts.Entities;
using System.Text.Json;

namespace B_1336.FindingConflicts.Application;
public class JsonConverter
{
    /// <summary>
    /// Десериализовать DeviceInfo.json
    /// </summary>
    public List<DeviceInfo> DeserializeDevices()
    {
        using (FileStream file = new FileStream(@"C:\Users\ivanr\OneDrive\Рабочий стол\Devices.json", FileMode.Open))
        {
            //List<DeviceInfo>? deviceInfo = JsonSerializer.Deserialize<List<DeviceInfo>>(file);
            var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            List<DeviceInfo>? deviceInfo = JsonSerializer.Deserialize<List<DeviceInfo>>(file,option);
            return deviceInfo;
        }
    }
    /// <summary>
    /// Сереализовать список бригад с использованными каждой бригадой приборами(хотя бы 1 "В сети")
    /// </summary>
    public void SerializeToConflicts(List<Conflict> conflicts)
    {
        using (FileStream file = new FileStream("Conflict.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<List<Conflict>>(file, conflicts);
        }
    }

}

