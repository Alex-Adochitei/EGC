using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;

namespace Adochitei_Alexandru_3131A_Lab5
{
    public class Object
    {
        private bool Visibility; //indicator pentru vizibilitatea obiectului
        private bool GB; //indicator care arata daca obiectul este afectat de gravitatie
        private Color Color; //culorile obiectului
        private List<Vector3> cList; //lista de coordonate pentru obiect
        private Randomizer r; //generatorul de numere aleatorii

        private const int GRAVITY_OFFSET = 1; //offset-ul pentru gravitatie

        //constructor pentru obiectul 3D
        public Object(bool gravityStatus, List<Vector3> vertexuri)
        {
            r = new Randomizer();
            Visibility = true;
            GB = gravityStatus;
            Color = r.RandomColor();

            cList = new List<Vector3>();

            //se genereaza coordonatele obiectului folosind niste offset-uri si coordonate pre-existente
            int size_offset = r.RandomInt(3, 7);
            int height_offset = r.RandomInt(40, 75);
            int radial_offset = r.RandomInt(-40, 40);
            int rad_offset = r.RandomInt(-40, 40);

            for (int i = 0; i < 10; i++)
            {
                cList.Add(new Vector3(vertexuri[i].X * size_offset + radial_offset, vertexuri[i].Y * size_offset + height_offset, vertexuri[i].Z * size_offset + rad_offset));
            }
        }

        //metoda pentru desenarea obiectului in OpenGL
        public void Draw()
        {
            if (Visibility)
            {
                GL.Color3(Color);
                GL.Begin(PrimitiveType.QuadStrip);

                foreach (Vector3 v in cList)
                {
                    GL.Vertex3(v);
                }
                GL.End();
            }
        }

        //metoda pentru actualizarea pozitiei obiectului, luand in considerare gravitatia
        public void UpdatePosition(bool gravityStatus)
        {
            if (Visibility && gravityStatus && !GroundCollisionDetected())
            {
                for (int i = 0; i < cList.Count; i++)
                {
                    cList[i] = new Vector3(cList[i].X, cList[i].Y - GRAVITY_OFFSET, cList[i].Z);
                }
            }
        }

        //metoda pentru a detecta coliziunea cu solul pentru obiect
        public bool GroundCollisionDetected()
        {
            foreach (Vector3 v in cList)
            {
                if (v.Y <= 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}