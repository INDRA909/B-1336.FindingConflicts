using B_1336.FindingConflicts.Entities;
using System.Linq;
using System.Runtime.CompilerServices;

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
        Dictionary<String,List<DeviceInfo>> conflict = new Dictionary<String,List<DeviceInfo>>();
        //Группироввание записей по бригадам в словарь
        foreach (DeviceInfo device in _devicesInfo)
        {
            //если такая бригада уже есть, то добавить прибор к ней
            if (conflict.ContainsKey(device.Brigade.Code))
            {
                conflict[device.Brigade.Code].Add(device);
            }
            else // Иначе инициализировать новую бригаду и добавить прибор
            {
                conflict.Add(device.Brigade.Code, new List<DeviceInfo>());
                conflict[device.Brigade.Code].Add(device);
            }
        }
        // Удаление бригад не имеющих среди приборов, хотя бы 1 на связи
        foreach (var brigade in conflict.Keys.ToArray())
        {
            if (conflict[brigade].Find(device => device.Device.IsOnline = true) == null)
            {
                conflict.Remove(brigade);
            }
        }
        List<Conflict> result = 
            conflict.Select(x=> new Conflict(){BrigadeCode = x.Key, DevicesSerials = x.Value
                    .Select(z=> z.Device.SerialNumber)
                    .ToArray()})
                    .ToList();
        return result;
    }
}

