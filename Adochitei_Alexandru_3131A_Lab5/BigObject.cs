using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Adochitei_Alexandru_3131A_Lab5
{
    public class BigObject
    {
        private const String FILENAME = "assets/slime.obj"; //numele fisierului .obj pentru obiectul 3D

        private const int FSI = 100; //factorul de scalare pentru coordonatele citite din fisierul .obj

        private const int GRAVITY_OFFSET = 2; //offsetul de gravitatie aplicat in actualizarea pozitiei

        private List<Vector3> cList; //lista de vectori pentru coordonatele vertexurilor obiectului

        private bool Visibility; //indicator pentru vizibilitatea obiectului
      
        private Color Color; //culoarea obiectului

        private bool Error; //indicator pentru eroare in incarcarea obiectului

        //constructor pentru clasa BigObject
        public BigObject(Color clr)
        {
            try
            {
                cList = LoadFromObjFile(FILENAME); //se incearca incarcarea coordonatelor vertexurilor din fisierul .obj

                //verifica daca exista coordonate valide in lista obiectului
                if (cList.Count == 0)
                {
                    Console.WriteLine("Crearea obiectului a esuat: obiect negasit/coordonate lipsa!");
                    return;
                }

                //starea initiala a obiectului
                Visibility = false;
                Color = clr;
                Error = false;

                Console.WriteLine("\nObiectul 3D a fost incarcat! Acesta are " + cList.Count.ToString() + " vertexuri disponibile!\n"); //afiseaza numarul de vertexuri incarcate cu succes
            }
            //in caz de eroare, este afisat un mesaj corespunzator si setam Error la true
            catch (Exception)
            {
                Console.WriteLine("\nEROARE!!!!\nFiserul <" + FILENAME + "> nu exista!!!\n");
                Error = true;
            }
        }

        //metoda pentru inversarea vizibilitatii obiectului
        public void ToggleVisibility()
        {
            //verifica daca nu a aparut o eroare in timpul incarcarii obiectului
            if (Error == false)
            {
                Visibility = !Visibility;
            }
        }

        //metoda pentru desenarea obiectului
        public void Draw()
        {
            //verifica daca nu a aparut o eroare si obiectul este vizibil
            if (Error == false && Visibility == true)
            {
                GL.Color3(Color);
                GL.Begin(PrimitiveType.Triangles);

                //itereaza prin fiecare vertex si il adauga la desen
                foreach (var vert in cList)
                {
                    GL.Vertex3(vert);
                }

                GL.End();
            }
        }

        //metoda pentru incarcarea coordonatelor din fisierul .obj
        private List<Vector3> LoadFromObjFile(string fname)
        {
            List<Vector3> vector = new List<Vector3>(); //initializeaza o lista pentru coordonatele vertexurilor

            var lines = File.ReadLines(fname); //citeste liniile din fisier

            //itereaza prin fiecare linie
            foreach (var line in lines)
            {
                //verifica daca linia are lungime suficient de mare
                if (line.Trim().Length > 2)
                {
                    //extrage primele doua caractere din linie
                    string ch1 = line.Trim().Substring(0, 1);
                    string ch2 = line.Trim().Substring(1, 1);

                    //verifica daca linia reprezinta un vertex
                    if (ch1 == "v" && ch2 == " ")
                    {
                        string[] block = line.Trim().Split(' '); //impartim linia in blocuri separate

                        //verifica daca blocul are coordonate valide (x, y, z)
                        if (block.Length == 4)
                        {
                            //extrage coordonatele si le adaugam la lista, scalandu-le
                            float x = float.Parse(block[1].Trim()) * FSI;
                            float y = float.Parse(block[2].Trim()) * FSI;
                            float z = float.Parse(block[3].Trim()) * FSI;

                            vector.Add(new Vector3((int)x, (int)y, (int)z));
                        }
                    }
                }
            }
            return vector;
        }

        //metoda pentru detectarea coliziunii cu solul
        public bool GroundCollisionDetected()
        {
            //verifica fiecare vertex pentru coliziune cu solul (Y <= 0)
            foreach (Vector3 v in cList)
            {
                if (v.Y <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        //metoda pentru actualizarea pozitiei obiectului
        public void UpdatePosition(bool gravityStatus)
        {
            //verifica daca obiectul este vizibil, gravitatia este activata si nu exista coliziuni cu solul
            if (Visibility && gravityStatus && !GroundCollisionDetected())
            {
                //actualizeaza pozitia fiecarui vertex pentru simularea gravitatiei
                for (int i = 0; i < cList.Count; i++)
                {
                    cList[i] = new Vector3(cList[i].X, cList[i].Y - GRAVITY_OFFSET, cList[i].Z);
                }
            }
        }
    }
}