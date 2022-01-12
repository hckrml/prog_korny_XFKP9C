using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XFKP9C
{
    public partial class Form1 : Form
    {
        static List<Egyszam> egyszamLista = new List<Egyszam>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("egyszamjatek1.txt", Encoding.UTF8);
            string sor = "";
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                Egyszam esz = new Egyszam(sor);
                egyszamLista.Add(esz);
            }
            sr.Close();
        }

        private void txTippek_TextChanged(object sender, EventArgs e)
        {
            string tippek = txTippek.Text;
            string[] d = tippek.Split(' ');
            int tippSzam = d.Length;
            label3.Text = tippSzam + " db";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nev = txNev.Text;
            bool vanIlyen = false;
            int index = 0;
            while(vanIlyen == false && index < egyszamLista.Count)
            {
                if(egyszamLista[index].Nev == nev)
                {
                    vanIlyen = true;
                }
                else
                {
                    index++;
                }
            }

            if (vanIlyen == true)
            {
                MessageBox.Show("Már van ilyen játékos!");
            }
            else
            {
                if(txTippek.Text.Split(' ').Length == 4)
                {
                    Egyszam esz = new Egyszam(nev + " " + txTippek.Text);
                    egyszamLista.Add(esz);
                    MessageBox.Show(egyszamLista.Count.ToString());

                    FileStream fs = new FileStream("egyszamjatek1.txt", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);

                    for(int i=0;i<egyszamLista.Count;i++)
                    {
                        sw.Write(egyszamLista[i].Nev + " ");
                        sw.Write(egyszamLista[i].Fordulok[0] + " ");
                        sw.Write(egyszamLista[i].Fordulok[1] + " ");
                        sw.Write(egyszamLista[i].Fordulok[2] + " ");
                        sw.WriteLine(egyszamLista[i].Fordulok[3]);
                    }
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("Az adatokat kiírtam!");
                }
                else
                {
                    MessageBox.Show("Tippek száma nem megfelelő!");
                }
            }
        }
    }
}
