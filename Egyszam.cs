using System;
using System.Collections.Generic;
using System.Text;

namespace XFKP9C
{
    class Egyszam
    {
        private string nev;

        List<int> fordulok = new List<int>();

        public Egyszam(string sor)
        {
            string[] d = sor.Split(' ');
            nev = d[0];
            for(int i = 1; i < d.Length; i++)
            {
                fordulok.Add(Convert.ToInt32(d[i]));
            }
        }

        public string Nev { get => nev; set => nev = value; }

        public List<int> Fordulok { get => fordulok; set => fordulok = value; }
    }
}
