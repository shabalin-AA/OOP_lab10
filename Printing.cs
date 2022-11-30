using System;
namespace lab10
{
    public class Font
    {
        public string Type = "Times New Roman";
        public int Size = 14;

        public Font(string type, int size)
        {
            Type = type;
            Size = size;
        }
    }



    public abstract class Printing : IComparable, IEquatable<Printing>
    {
        protected Random rnd;

        private List<string> authors = new List<string>();
        public string Authors
        {
            get
            {
                string authorsConcat = authors[0];
                for (int i = 1; i < authors.Count(); i++)
                    authorsConcat += (" " + authors[i]);
                return authorsConcat;
            }
            set
            {
                string[] authorsArray = value.Split(' ');
                authors = new List<string>();
                for (int i = 0; i < authorsArray.Length; i++)
                    authors.Add(authorsArray[i]);
            }
        }

        public int CompareTo(object? another)
        {
            if (another is Printing)
                return string.Compare(this.Name, ((Printing)another).Name);
            else return -2;
        }

        public bool Equals(Printing other)
        {
            if (other == null) return false;
            return (this.ToString().Equals(other.ToString()));
        }

        public override bool Equals(object obj) => Equals(obj as Printing);

        public string Name = "";
        public int Year = 0;
        public abstract override string ToString();

        public Font font;

        protected static string[] RandomNames;
        protected static string[] RandomAuthors;
    }
}

