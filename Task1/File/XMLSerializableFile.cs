using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using NLog;
using Task1.Exceptions;

namespace Task1.File
{
    public class XMLSerializableFile : IFile<Book>
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private XMLSerializableFile() { }
        public static XMLSerializableFile Instance { get; } = new XMLSerializableFile();
        public string Path { get; } = "books.xml";

        public IEnumerable<Book> LoadAll()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read);
                if (fs.Position != fs.Length)
                {
                    XmlSerializer xs = new XmlSerializer(typeof (List<Book>), new Type[] {typeof (Book)});
                    IEnumerable<Book> result = (List<Book>) xs.Deserialize(fs);
                    return result;
                }
                return new Book[0];
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
                XmlSerializer xs = new XmlSerializer(items.GetType(), new Type[] { typeof(Book) });
                xs.Serialize(fs, items);
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
