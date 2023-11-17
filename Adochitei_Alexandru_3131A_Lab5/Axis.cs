using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace Adochitei_Alexandru_3131A_Lab5
{
    internal class Axis
    {
        public const int axis_size = 75;
        private bool Visibility;

        public Axis()
        {
            Visibility = true;
        }

        //metoda pentru desenarea propriu-zisa a axelor pe ecran
        public void Draw()
        {
            GL.Begin(PrimitiveType.Lines);

            //deseneaza pozitia axei pozitive X
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(axis_size, 0, 0);

            //deseneaza pozitia axei negative X
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(-axis_size, 0, 0);

            //deseneaza pozitia axei pozitive Y
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, axis_size, 0);

            //deseneaza pozitia axei negative Y
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, -axis_size, 0);

            //deseneaza pozitia axei pozitive Z
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, axis_size);

            //deseneaza pozitia axei negative Z
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, -axis_size);

            GL.End();
        }

        //metoda pentru comutarea vizibilitatii axelor
        public void ToggleVisibility()
        {
            Visibility = !Visibility;
        }

        //metoda pentru afisarea axelor
        public void Show()
        {
            Visibility = true;
        }

        //metoda pentru ascunderea axelor
        public void Hide()
        {
            Visibility = false;
        }
    }
}