namespace B_1336.FindingConflicts.DI;
public interface IData<T>
{
    IEnumerable<T> LoadData();
    void UploadData(IEnumerable<T> dataList);
}

