using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Adochitei_Alexandru_3131A_Lab5
{
    class Grid
    {
        private readonly Color Color; //culoarea grilei
        private bool Visibility; //variabila pentru vizibilitatea grilei

        private readonly Color GC = Color.White; //culoarea implicita a grilei
        private const int GS = 10; //dimensiunea unei celule din grila
        private const int UNITS = 100; //numarul de celule in fiecare directie
        private const int POINT_OFFSET = GS * UNITS; //offset pentru desenarea grilei
        private const int MICRO_OFFSET = 1; //offset pentru a evita suprapunerea axelor pe grila

        public Grid()
        {
            Color = GC; //seteaza culoarea implicita
            Visibility = true; //grila este initial vizibila
        }

        //metoda pentru comutarea vizibilitatii grilei
        public void ToggleVisibility()
        {
            Visibility = !Visibility;
        }

        //metoda pentru afisarea grilei
        public void Show()
        {
            Visibility = true;
        }

        //metoda pentru ascunderea grilei
        public void Hide()
        {
            Visibility = false;
        }

        public void Draw()
        {
            if (Visibility) //verifica daca grila este vizibila
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color);

                //deseneaza linii in planul XZ, paralel cu Oz
                for (int i = -1 * GS * UNITS; i <= GS * UNITS; i += GS)
                {
                    //linii paralele cu Oz
                    GL.Vertex3(i + MICRO_OFFSET, 0, POINT_OFFSET);
                    GL.Vertex3(i + MICRO_OFFSET, 0, -1 * POINT_OFFSET);

                    //linii paralele cu Ox
                    GL.Vertex3(POINT_OFFSET, 0, i + MICRO_OFFSET);
                    GL.Vertex3(-1 * POINT_OFFSET, 0, i + MICRO_OFFSET);
                }
                GL.End();
            }
        }
    }
}