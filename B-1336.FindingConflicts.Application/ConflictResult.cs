using B_1336.FindingConflicts.Entities;
namespace B_1336.FindingConflicts.Application;
public class ConflictResult
{
    private readonly List<DeviceInfo> _devicesInfo;

    public ConflictResult(List<DeviceInfo> devicesInfo)
    {
        _devicesInfo = devicesInfo;
    }
    /// <summary>
    /// Группировка по бригадам с хотя бы 1 прибором на связи
    /// </summary>
    /// <returns></returns>
    public List<Conflict> FindingConflicts()
    {
        Dictionary<string,List<DeviceInfo>> brigadesConflicts = new Dictionary<string,List<DeviceInfo>>();
        //Группироввание записей по бригадам в словарь
        foreach (DeviceInfo device in _devicesInfo)
        {
            //если такая бригада уже есть, то добавить прибор к ней
            if (brigadesConflicts.ContainsKey(device.Brigade.Code))
            {
                brigadesConflicts[device.Brigade.Code].Add(device);
            }
            else // Иначе инициализировать новую бригаду и добавить прибор
            {
                brigadesConflicts.Add(device.Brigade.Code, new List<DeviceInfo>());
                brigadesConflicts[device.Brigade.Code].Add(device);
            }
        }
        // Удаление бригад не имеющих среди приборов, хотя бы 1 на связи
        foreach (var brigade in brigadesConflicts.Keys.ToArray())
        {
            if (brigadesConflicts[brigade].Find(device => device.Device.IsOnline = true) == null)
            {
                brigadesConflicts.Remove(brigade);
            }
        }
        //Конвертирование словаря в список
        List<Conflict> result = 
            brigadesConflicts.Select(x=> new Conflict(){BrigadeCode = x.Key, DevicesSerials = x.Value
                    .Select(z=> z.Device.SerialNumber)
                    .ToArray()})
                    .ToList();
        return result;
    }
}

