using System;

namespace Adochitei_Alexandru_3131A_Lab5
{
    //clasa ce contine punctul de intrare in aplicatie
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //instatierea unui obiect de tipul Window
            using (Window_3D example = new Window_3D())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}