using B_1336.FindingConflicts.DI;

namespace B_1336.FindingConflicts.Entities;
public class DeviceInfo :IDeviceInfo
{
    public IDevice Device { get; set; }
    public IBrigade Brigade { get; set; }
}
public class Device : IDevice
{
    public string SerialNumber { get; set; }
    public bool IsOnline { get; set; }
}

public class Brigade :IBrigade
{
    public string Code { get; set; }
}
public class Conflict : IConflict
{
    public string BrigadeCode { get; set; }
    public string[] DevicesSerials { get; set; }
}
