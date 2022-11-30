using System;
namespace lab10
{
    public class SchoolBook : Book, IRandomCreate
    {
        public string Subject = "";
        private static string[] RandomSubjects;

        public override string ToString()
        {
            return "Authors: " + Authors + '\n' +
                    "Subject: " + Subject + '\n' +
                    "Year:    " + Year + '\n';
        }

        public SchoolBook()
        {
            rnd = new Random();
            RandomAuthors = new string[] {
                "Maksimov", "Starikov", "Kulikov", "Limonov", "Ackman",
                "Tverskoy", "Watson", "Sokolov", "Nazarova", "Kuznetsov"
            };

            RandomSubjects = new string[] {
                "Algebra", "English", "Literature", "Physics", "Chemistry",
                "Informatics", "Drawing", "Math Analysis", "Geometry", "Biology"
            };

            CreateRandom();
            Name = Subject;
        }

        public SchoolBook(string authors, string subject, int year)
        {
            Authors = authors;
            Name = subject;
            Subject = subject;
            Year = year;
            font = new Font("Times New Roman", 14);
        }

        public Book Base
        {
            get
            {
                return new Book(this.Authors, this.Name, "Science", this.Year);
            }
        }

        public new void CreateRandom()
        {
            Year = rnd.Next(1800, 2022);
            Subject = RandomSubjects[rnd.Next(RandomSubjects.Length)];

            int qAuthors = rnd.Next(1, 4);
            string _authors = "";
            for (int i = 0; i < qAuthors; i++)
                _authors += RandomAuthors[rnd.Next(RandomAuthors.Length)] + ' ';
            Authors = _authors;
            font = new Font("Times New Roman", 14);
        }

        public new object Clone()
        {
            SchoolBook newBook = new SchoolBook();
            newBook.Name = this.Name;
            newBook.Authors = this.Authors;
            newBook.Subject = this.Subject;
            newBook.Year = this.Year;

            newBook.font.Type = this.font.Type;
            newBook.font.Size = this.font.Size;

            return newBook;
        }

        public new SchoolBook ShallowCopy()
        {
            return (SchoolBook)this.MemberwiseClone();
        }
    }
}

