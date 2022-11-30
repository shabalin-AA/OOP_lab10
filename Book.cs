using System;
namespace lab10
{
    public class Book : Printing, IRandomCreate, ICloneable
    {
        public string Genre = "";
        private static string[] RandomGenres;

        public override string ToString()
        {
            return "Authors: " + Authors + '\n' +
                    "Name:    " + Name    + '\n' +
                    "Genre:   " + Genre   + '\n' +
                    "Year:    " + Year + '\n';
        }

        public Book()
        {
            rnd = new Random();
            RandomNames = new string[] {
                "The Story of Doctor Dolittle", "The Red House Mystery",
                "The Secret Garden", "Treasure Island",
                "Black Beauty", "Heidi", "My Man Jeeves", "Wuthering Heights",
                "The Adventures of Robin Hood", "The Red Badge of Courage"
            };

            RandomGenres = new string[] {
                "Fiction", "Chick lit", "Science-fiction", "Fantasy", "Politics",
                "Travel Book", "Autobiography", "History", "Thriller", "Horror"
            };

            RandomAuthors = new string[] {
                "Lofting", "Milne", "Burnett", "Stevenson", "Sewell",
                "Spyri", "Wodehouse", "Bronte", "Pyle", "Crane"
            };

            CreateRandom();
        }

        public Book(string authors, string name, string genre, int year)
        {
            Authors = authors;
            Name = name;
            Genre = genre;
            Year = year;
            font = new Font("Times New Roman", 14);
        }

        public void CreateRandom()
        {
            Year = rnd.Next(1800, 2022);
            Name = RandomNames[rnd.Next(RandomNames.Length)];
            Genre = RandomGenres[rnd.Next(RandomGenres.Length)];

            int qAuthors = rnd.Next(1, 3);
            string _authors = "";
            for (int i = 0; i < qAuthors; i++)
                _authors += RandomAuthors[rnd.Next(RandomAuthors.Length)] + ' ';
            Authors = _authors;
            font = new Font("Times New Roman", 14);
        }

        public object Clone()
        {
            Book newBook = new Book();
            newBook.Name = this.Name;
            newBook.Genre = this.Genre;
            newBook.Year = this.Year;
            newBook.Authors = this.Authors;

            newBook.font.Type = this.font.Type;
            newBook.font.Size = this.font.Size;

            return newBook;
        }

        public Book ShallowCopy()
        {
            return (Book)this.MemberwiseClone();
        }
    }
}

