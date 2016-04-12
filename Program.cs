using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemAz
{
    class Program
    {
        static void Main(string[] args)
        {
        Hopp:
            Console.Write("Kérem írja be a személyazonosító jel első 10 számjegyét!: ");
            string Be = Console.ReadLine();
            if (!JoE(Be)) goto Hopp;


            DateTime ido = DateTime.Now;


            Console.Write("Neme: ");

            if (Convert.ToInt32(Be[0].ToString()) % 2 == 1)
            {
                Console.WriteLine("Férfi");
            }
            else
            {
                Console.WriteLine("Nő");
            }

            Console.Write("Születési sorszám: ");
            Console.WriteLine("{0}{1}{2}",Be[7],Be[8],Be[9]);

            string ev1 = "";

            if (Convert.ToInt32(Be[0].ToString()) < 3)
            {
                ev1 = "19" + Be[1] + Be[2];
            }
            else
            {
                ev1 = "20" + Be[1] + Be[2];
            }

            Console.WriteLine("Ebben az évben van a(z) {0}-ik születésnapja!", ido.Year - Convert.ToInt32(ev1));

            Console.Write("Kérem írjaon be egy másik személyazonosító jel első 10 számjegyét!: ");

            Hopp2:
            string Be2 = Console.ReadLine();
            if (!JoE(Be2)) goto Hopp2;

            string ev2 = "";

            if (Convert.ToInt32(Be2[0].ToString()) < 3)
            {
                ev2 = "19" + Be2[1] + Be2[2];
            }
            else
            {
                ev2 = "20" + Be2[1] + Be2[2];
            }

            int ev1_int = Convert.ToInt32(ev1);
            int ev2_int = Convert.ToInt32(ev2);

            if (ev1_int - ev2_int == 0)
            {
                if (Convert.ToInt32(Be[7] + Be[8] + Be[9]) - Convert.ToInt32(Be2[7] + Be2[8] + Be2[9]) < 0)
                {
                    Console.WriteLine("1. idősebb");
                }
                else
                {
                    Console.WriteLine("2. idősebb");
                }
            }
            else if (ev1_int - ev2_int < 0)
            {
                Console.WriteLine("1. idősebb");
            }
            else 
            {
                Console.WriteLine("2. idősebb");
            }

            int ossz = 0;

            for (int i = 0; i < 10; i++)
            {
                ossz += (Convert.ToInt32(Be2[0].ToString()) * (10-i));
            }

            int maradek = ossz % 11;

            if (maradek == 10)
            {
                Console.WriteLine("HIBÁS SZÜLETÉSI SORSZÁM!");
            }
            else 
            {
                Console.WriteLine("2. ember teljes személyazonosító jele: {0}",Be2 + maradek);
            }


            using (StreamWriter SW = new StreamWriter("szemszam.txt"))
            {
                SW.WriteLine(Be);
                SW.WriteLine(Be2);
            }

            Console.ReadKey();
        }

        static bool JoE(string Bemenet)
        {
            string szabad = "0123456789";
            bool vissza = true;

            if (Bemenet.Length != 10) vissza = false;
            if (Convert.ToInt32(Bemenet[0].ToString()) < 1) vissza = false;
            if (Convert.ToInt32(Bemenet[0].ToString()) > 4) vissza = false;
            if (Convert.ToInt32(Bemenet[3].ToString() + Bemenet[4].ToString()) > 12) vissza = false;
            if (Convert.ToInt32(Bemenet[3].ToString() + Bemenet[4].ToString()) < 0) vissza = false;
            if (Convert.ToInt32(Bemenet[5].ToString() + Bemenet[6].ToString()) > 31) vissza = false;
            if (Convert.ToInt32(Bemenet[5].ToString() + Bemenet[6].ToString()) < 0) vissza = false;

            for (int i = 0; i < Bemenet.Length; i++)
            {
                bool tartalmaz = false;

                for (int j = 0; j < szabad.Length; j++)
                {
                    if (Bemenet[i] == szabad[j])
                    {
                        tartalmaz = true;
                    }
                }

                if (!tartalmaz)
                {
                    vissza = false;
                    break;
                }
            }

            return vissza;
        }
    }
}
