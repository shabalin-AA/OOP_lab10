using System;
namespace lab10
{
    public class PrintingComparer : System.Collections.Generic.IComparer<Printing>
    {
        public int Compare(Printing? p1, Printing? p2)
        {
            if (p1 is Printing && p2 is Printing)
                return string.Compare(p1.ToString(), p2.ToString());
            else return -2; ;
        }
    }
}

