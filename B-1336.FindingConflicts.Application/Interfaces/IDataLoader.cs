namespace B_1336.FindingConflicts.Application.Interfaces;
public interface IDataLoader<T>
{
    public IEnumerable<T> LoadData();
}
public interface IDataUploader<T>
{
    public void UploadData(IEnumerable<T> dataList);
}


