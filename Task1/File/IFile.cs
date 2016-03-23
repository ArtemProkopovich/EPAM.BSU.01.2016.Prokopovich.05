using System.Collections.Generic;





namespace Task1.File
{
    public interface IFile<T>
    {
        void Write(T item);
        void Write(IEnumerable<T> items);
        void Append(T item);
        void AppendAll(IEnumerable<T> items);
        IEnumerable<T> ReadAll();
        T ReadIndex(int index);
    }
}