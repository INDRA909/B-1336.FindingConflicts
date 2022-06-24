using B_1336.FindingConflicts.Application;
using Microsoft.EntityFrameworkCore;

var jsonLoader = new JsonLoader();
//Получить данные о используемых приборах
var devicesInfo = jsonLoader.LoadData();
ConflictResult result = new ConflictResult(devicesInfo);
//Выгрузить данные о конфликтах
jsonLoader.UploadData(result.FindingConflicts());

