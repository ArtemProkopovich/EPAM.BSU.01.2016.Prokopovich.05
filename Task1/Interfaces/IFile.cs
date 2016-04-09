using System.Collections.Generic;





namespace Task1.File
{
    public interface IFile<T>
    {
        string Path { get; }
        void SaveAll(IEnumerable<T> items);
        IEnumerable<T> LoadAll();
    }
}