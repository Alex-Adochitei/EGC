using OpenTK;
using System;
using System.Drawing;

namespace Adochitei_Alexandru_3131A_Lab5
{
    class Randomizer
    {
        private Random r; //obiectul Random pentru generarea numerelor aleatorii

        //constante pentru limitele valorilor aleatorii
        private const int min_int = -30;
        private const int max_int = 30;
        private const int min_coord = -60;
        private const int max_coord = 60;

        //constructor care initializeaza obiectul Random
        public Randomizer()
        {
            r = new Random();
        }

        //metoda pentru generarea unei culori aleatorii
        public Color RandomColor()
        {
            int R = r.Next(0, 255);
            int G = r.Next(0, 255);
            int B = r.Next(0, 255);

            Color clr = Color.FromArgb(R, G, B);

            return clr;
        }

        //metoda pentru generarea unui punct 3D aleatoriu folosind Vector3 din OpenTK
        public Vector3 Random3DPoint()
        {
            int A = r.Next(min_coord, max_coord);
            int B = r.Next(min_coord, max_coord);
            int C = r.Next(min_coord, max_coord);

            Vector3 Vector = new Vector3(A, B, C);

            return Vector;
        }

        //metoda pentru generarea unui numar intreg aleatoriu intre limitele min_int si max_int
        public int RandomInt()
        {
            int i = r.Next(min_int, max_int);
            return i;
        }

        //metoda pentru generarea unui numar intreg aleatoriu intre valorile min si max
        public int RandomInt(int min, int max)
        {
            int i = r.Next(min, max);
            return i;
        }

        //metoda pentru generarea unui numar intreg aleatoriu intre 0 si max
        public int RandomInt(int max)
        {
            int i = r.Next(max);
            return i;
        }
    }
}