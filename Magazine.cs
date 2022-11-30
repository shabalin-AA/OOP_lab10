using System;
namespace lab10
{
    public class Magazine : Printing, IRandomCreate, ICloneable
    {
        public string Theme = "";
        private static string[] RandomThemes;

        public override string ToString()
        {
            return "Authors: " + Authors + '\n' +
                   "Theme:   " + Theme + '\n' +
                   "Year:    " + Year + '\n';
        }

        public Magazine()
        {
            rnd = new Random();
            RandomThemes = new string[] {
                "Sport", "Interier", "Psychology", "Science", "Forbes",
                "TV Program", "Comics", "Humour", "Cooking", "Housekeeping"
            };

            RandomAuthors = new string[] {
                "Fisk", "Adi", "Amonpur", "Shuli", "Woodvort",
                "Cooper", "Soyer", "Bhan", "Greenwald", "Stuart"
            };

            CreateRandom();
            Name = Theme;
        }

        public Magazine(string authors, string theme, int year)
        {
            Authors = authors;
            Theme = theme;
            Name = theme;
            Year = year;
            font = new Font("Times New Roman", 14);
        }

        public void CreateRandom()
        {
            Year = rnd.Next(1800, 2022);
            Theme = RandomThemes[rnd.Next(RandomThemes.Length)];

            int qAuthors = rnd.Next(3, 5);
            string _authors = "";
            for (int i = 0; i < qAuthors; i++)
                _authors += RandomAuthors[rnd.Next(RandomAuthors.Length)] + ' ';
            Authors = _authors;

            font = new Font("Times New Roman", 14);
        }

        public object Clone()
        {
            Magazine newMagazine = new Magazine();
            newMagazine.Name = this.Name;
            newMagazine.Authors = this.Authors;
            newMagazine.Theme = this.Theme;
            newMagazine.Year = this.Year;

            newMagazine.font = new Font(this.font.Type, this.font.Size);

            return newMagazine;
        }

        public Magazine ShallowCopy()
        {
            return (Magazine)this.MemberwiseClone();
        }
    }
}

