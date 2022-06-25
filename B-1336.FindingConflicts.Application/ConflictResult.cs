using B_1336.FindingConflicts.DI;
using B_1336.FindingConflicts.Settings;

namespace B_1336.FindingConflicts.Application;
public class ConflictResult 
{
    private readonly IEnumerable<IDeviceInfo> _devicesInfo;
    private static Configuration _configuration;
    public ConflictResult(IEnumerable<IDeviceInfo> devicesInfo)
    {
        _devicesInfo = devicesInfo;
    }
    /// <summary>
    /// Группировка по бригадам с хотя бы 1 прибором на связи
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IConflict> FindingConflicts()
    {
        Dictionary<string,List<IDeviceInfo>> brigadesConflicts = new Dictionary<string,List<IDeviceInfo>>();
        //Группироввание записей по бригадам в словарь
        foreach (IDeviceInfo device in _devicesInfo)
        {
            //если такая бригада уже есть, то добавить прибор к ней
            if (brigadesConflicts.ContainsKey(device.Brigade.Code))
            {
                brigadesConflicts[device.Brigade.Code].Add(device);
            }
            else // Иначе инициализировать новую бригаду и добавить прибор
            {
                brigadesConflicts.Add(device.Brigade.Code, new List<IDeviceInfo>());
                brigadesConflicts[device.Brigade.Code].Add(device);
            }
        }
        // Удаление бригад не имеющих среди приборов, хотя бы 1 на связи
        foreach (var brigade in brigadesConflicts.Keys.ToArray())
        {
            if (brigadesConflicts[brigade].Find(device => device.Device.IsOnline = true) == null && brigadesConflicts[brigade].Count<=1)
            {
                brigadesConflicts.Remove(brigade);
            }
        }
        //Конвертирование словаря в список
        var conflict = _configuration.Container.GetInstance<IConflict>();
        conflict.BrigadeCode = "2345235";


        IEnumerable<IConflict> result = 
            brigadesConflicts.Select(x=> new Conflict {BrigadeCode = x.Key, DevicesSerials = x.Value
                    .Select(z=> z.Device.SerialNumber)
                    .ToArray()} as IConflict)
                    .ToList();
        return result;
    }
}

