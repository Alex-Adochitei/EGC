using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;

namespace Adochitei_Alexandru_3131A_Lab4
{
    //clasa pentru gestionarea unui cub in spatiul 3D
    class Cube
    {
        //vectorul de Vector3 in care vor fi citite coordonatele cubului din fisier
        private List<Vector3> vertices;

        //variabile pentru canalele de culoare
        private double r = 1;
        private double g = 1;
        private double b = 1;
        private double a = 1;

        //culori pentru coordonatele triunghiului
        private Color clr1;
        private Color clr2;
        private Color clr3;

        //declarare variabila controller pentru mofidicarea culorilor triunghiurilor
        private Color_Handler ch;

        private Random_Color_Generator cg;

        public Cube(string caleFisier)
        {
            vertices = new List<Vector3>();

            //citirea din fisierul "coordonate.txt" a coordonatelor cubului
            string text = System.IO.File.ReadAllText(@caleFisier);
            string[] lines = text.Split('\n');

            for (int i = 0; i < 36; i++)
            {
                string[] cb = lines[i].Split(' ');
                vertices.Add(new Vector3(int.Parse(cb[0]), int.Parse(cb[1]), int.Parse(cb[2])));
            }

            //instantierea unor obiecte pentru controller-ul de culori si pentru generatorul de culori random
            ch = new Color_Handler();
            cg = new Random_Color_Generator();
        }

        //metoda pentru setarea culorii cubului si a unui triunghi din componenta acestuia
        public void SetColorCub()
        { 
            //definire obiecte pentru starea tastaturii si mouse-ului
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            //setare culoare cub in functie de tastele apasate
            ch.SetColor(keyboard, ref r, ref g, ref b, ref a);

            //setare culoare triunghi din componenta cubului in fucntie de tastele apasate
            ch.SetVertexColors(keyboard, ref clr1, ref clr2, ref clr3);
        }

        //metoda pentru desenarea propriu-zisa a cubului pe ecran 
        public void Draw()
        {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 36; i = i + 3)
            {
                //exercitiul 1: setarea culorii unei suprafete a cubului
                if (i > 28)
                    GL.Color4(a, r, g, b);
                else
                    GL.Color3(Color.White);

                //exercitiul 2: blocuri pentru setarea unei culori generata random pentru fiecare vertex al unui triunghi din componenta cubului
                if (i == 18) 
                    GL.Color3(clr1);
                GL.Vertex3(vertices[i]);
                if (i == 18) 
                    GL.Color3(clr2);
                GL.Vertex3(vertices[i + 1]);
                if (i == 18) 
                    GL.Color3(clr3);
                GL.Vertex3(vertices[i + 2]);
            }
            GL.End();
        }
    }
}