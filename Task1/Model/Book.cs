using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    public class Book : IEquatable<Book>
    {
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public int PageNumber { get; set; } = 0;

        public override string ToString()
        {
            return $"{Name} by {Author}. Published: {PublishDate}. PageNumber: {PageNumber}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            Book book = (Book)obj;
            return Equals(book);
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return
                Name?.Equals(other.Name) == true && Author?.Equals(other.Author) == true &&
                PageNumber == other.PageNumber;
        }

        public override int GetHashCode()
        {
            return ((int) Name?.GetHashCode() + (int) Author?.GetHashCode() + PublishDate.GetHashCode()) ^ PageNumber;
        }
    }
}
