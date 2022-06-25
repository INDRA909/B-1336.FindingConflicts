using B_1336.FindingConflicts.Data.Json;
using B_1336.FindingConflicts.DI;
using B_1336.FindingConflicts.Entities;
using SimpleInjector;

namespace B_1336.FindingConflicts.Settings;
public class Configuration
{
    public Container Container { get; }

    public Configuration()
    {
        Container = new Container();
        Setup();
    }

    private void Setup()
    {
        Container.Register<IBrigade, Brigade>(Lifestyle.Transient);
        Container.Register<IConflict, Conflict>(Lifestyle.Transient);
        Container.Register<IDevice, Device>(Lifestyle.Transient);
        Container.Register<IDeviceInfo, DeviceInfo>(Lifestyle.Transient);
        Container.Register<IData<IConflict>, JsonLoader>(Lifestyle.Singleton);
    }
}

