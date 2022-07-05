using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.SanalBebek.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] satirlar = File.ReadAllLines("D:\\deneme.txt");
            
            string[] parcalar = satirlar[0].Split(' ');

            File.AppendAllText("«D:\\deneme.txt", "Ad:Ali Soyad:Çokçalışkan No:10" + Environment.NewLine);
            //string[] satirlar = File.ReadAllLines("D:\\deneme.txt");



            Console.WriteLine("Sanal Bebek");
            Console.Write("Bebeğin adı:");
            string ad = Console.ReadLine();
            Bebek b = new Bebek(ad);
            while (true)
            {
                Console.WriteLine(b.BilgileriGetir());
                Console.WriteLine("----------------------------------------------------------");
                //Karıştır
                //Console.WriteLine(b.BilgileriGetir());
                if (b.Hayatta)
                {
                    Console.WriteLine("1-Yemek Ye\n2-Duş al\n3-Oyun oyna\n4-Uyu\n5-Çıkış");
                    char c = Console.ReadKey(true).KeyChar;
                    if (c == '1')
                    {
                        b.YemekYe();
                    }
                    else if (c == '2')
                    {
                        b.DusAl();
                    }
                    else if (c == '3')
                    {
                        b.ParkaGitOyna();
                    }
                    else if (c == '4')
                    {
                        b.Uyu(b.Yorgunluk / 10);
                    }
                    else if (c == '5')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Yanlış bir seçim yaptınız.");
                    }
                }
                else
                {
                    Console.WriteLine("Bebek öldü");
                    break;
                }
                Console.WriteLine("----------------------------------------------------------");
            }
            Console.ReadKey();
        }
    }
    class Bebek
    {
        private Random rnd = new Random();
        public Bebek(string ad)
        {
            Ad = ad;
            Hayatta = true;
            Tokluk = 50;
            Yorgunluk = 50;
            Eglence = 50;
            Hijyen = 50;
        }
        public bool Hayatta { get; private set; }

        public bool Acikti { get; private set; }

        private string ad;

        public string Ad
        {
            get { return ad; }
            set { ad = value.ToUpper(); }
        }
        private int yorgunluk;
        public int Yorgunluk
        {
            get
            {
                return yorgunluk;
            }

            set
            {
                if (value < 0)
                {
                    Hayatta = false;
                    yorgunluk = 0;
                }
                else if (value > 100)
                    yorgunluk = 100;
                else
                    yorgunluk = value;
            }
        }
        private int eglence;
        public int Eglence
        {
            get { return eglence; }
            set
            {
                if (value <= 0)
                {
                    eglence = 0;
                    Tokluk -= 10;
                }
                else if (value >= 100)
                    eglence = 100;
                else
                    eglence = value;
            }
        }
        private int tokluk;
        public int Tokluk
        {
            get { return tokluk; }
            set
            {
                if (value > 0 && value <= 30)
                {
                    Acikti = true;
                    tokluk = value;
                }
                else if (value <= 0)
                {
                    Hayatta = false;
                    tokluk = 0;
                }
                else if (value > 30 && value < 100)
                {
                    Acikti = false;
                    tokluk = value;
                }
                else
                {
                    tokluk = 100;
                }
            }
        }

        private int hijyen;

        public int Hijyen
        {
            get { return hijyen; }
            set
            {

                if (value <= 0)
                {
                    int random = rnd.Next(5);
                    if (random == 0)
                    {
                        Hayatta = false;
                    }
                    else
                    {
                        hijyen = 5;
                    }
                }
                else if (value >= 100)
                {
                    hijyen = 100;
                }
                else
                {
                    hijyen = value;
                }
            }
        }

        public void YemekYe()
        {
            if (Acikti)
            {
                Tokluk += 50;
                Hijyen -= 20;
                Eglence += 10;
                Yorgunluk += 10;
            }
        }

        public void Uyu(int saat)
        {
            Yorgunluk -= saat*rnd.Next(5,10);
            Hijyen -= 30;
            Tokluk -= 40;
            Eglence -= 20;
        }

        public void DusAl()
        {
            Hijyen += 60;
            Tokluk -= 30;
            Eglence += 10;
            Yorgunluk += 20;
        }

        public void ParkaGitOyna()
        {
            Eglence += 30;
            Yorgunluk += 30;
            Hijyen -= 20;
            Tokluk -= 20;
        }

        public string BilgileriGetir()
        {
            return $"Ad:{Ad} Hijyen:{Hijyen} Yorgunluk:{Yorgunluk} Tokluk:{Tokluk} Eğlence:{Eglence}";
        }
    }
}
