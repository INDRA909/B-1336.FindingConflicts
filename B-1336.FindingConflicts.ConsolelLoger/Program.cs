using B_1336.FindingConflicts.Application;

var jsonLoader = new JsonLoader();
//Получить данные о используемых приборах
var devicesInfo = jsonLoader.LoadData();
Console.WriteLine("Данные успешно считаны из Devices.json");
ConflictResult result = new ConflictResult(devicesInfo.ToList());
//Выгрузить данные о конфликтах
jsonLoader.UploadData(result.FindingConflicts());
Console.WriteLine("Данные успешно записаны в Conflicts.json");

