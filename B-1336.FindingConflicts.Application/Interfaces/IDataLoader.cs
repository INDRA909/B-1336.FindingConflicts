namespace B_1336.FindingConflicts.Application.Interfaces;
public interface IDataLoader<T>
{
    public List<T> LoadData();
}
public interface IDataUploader<T>
{
    public void UploadData(List<T> dataList);
}


