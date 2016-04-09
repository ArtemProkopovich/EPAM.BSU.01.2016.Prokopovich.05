using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NLog;
using Task1.Exceptions;

namespace Task1.File
{
    public class BinarySerializableFile : IFile<Book>
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private BinarySerializableFile() { }
        public static BinarySerializableFile Instance { get; } = new BinarySerializableFile();
        public string Path { get; } = "books_s.bin";

        public IEnumerable<Book> LoadAll()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read);
                if (fs.Position != fs.Length)
                {
                    BinaryFormatter f = new BinaryFormatter();
                    IEnumerable<Book> result = (List<Book>) f.Deserialize(fs);
                    return result;
                }
                else return new Book[0];
            }
            catch (IOException ex)
            {
                throw new StorageIOException("", ex);
            }
            catch (Exception ex)
            {
                throw new StorageException("", ex);
            }
            finally
            {
                fs?.Dispose();
            }
        }

        public void SaveAll(IEnumerable<Book> items)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(Path, FileMode.Create, FileAccess.Write);
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(fs, items);
            }
            catch (IOException ex)
            {
                throw new StorageIOException("", ex);
            }
            catch (Exception ex)
            {
                throw new StorageException("", ex);
            }
            finally
            {
                fs?.Dispose();
            }
        }
    }
}
