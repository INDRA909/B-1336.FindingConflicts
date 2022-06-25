using System.Text.Json;
using B_1336.FindingConflicts.DI;

namespace B_1336.FindingConflicts.Data.Json;
public class JsonLoader : IData<IDeviceInfo>, IData<IConflict>
{
    /// <summary>
    /// Десериализовать DeviceInfo.json
    /// </summary>
    public IEnumerable<IDeviceInfo> LoadData()
    {
        using (FileStream file = new FileStream(@"C:\Users\ivanr\OneDrive\Рабочий стол\Devices.json", FileMode.Open))
        {
            var option = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
            List<IDeviceInfo>? devicesInfo = JsonSerializer.Deserialize<List<IDeviceInfo>>(file,option);
            return devicesInfo;
        }
    }
    /// <summary>
    /// Сереализовать список бригад с использованными каждой бригадой приборами(хотя бы 1 "В сети")
    /// </summary>
    public void UploadData(IEnumerable<IConflict> conflicts)
    {
        using (FileStream file = new FileStream("Conflict.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(file, conflicts);
        }
    }
    /// <summary>
    /// Выгрузка данных, например, выгрузить файл "Devices.json"
    /// </summary>
    /// <param name="dataList"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void UploadData(IEnumerable<IDeviceInfo> dataList)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Загрузка данных, например, загрузить "Conflict.json"
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    IEnumerable<IConflict> IData<IConflict>.LoadData()
    {
        throw new NotImplementedException();
    }
}

