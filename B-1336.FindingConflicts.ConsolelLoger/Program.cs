using B_1336.FindingConflicts.Application;

var jsonConverter = new JsonConverter();
var devicesInfo = jsonConverter.DeserializeDevices();

ConflictResult result = new ConflictResult(devicesInfo);

jsonConverter.SerializeToConflicts(result.FindingConflicts());