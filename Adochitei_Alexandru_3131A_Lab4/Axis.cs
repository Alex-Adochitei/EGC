using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace Adochitei_Alexandru_3131A_Lab4
{
    internal class Axis
    {
        public const int axis_size = 75;

        //metoda pentru desenarea propriu-zisa a axelor pe ecran
        public void Draw()
        {
            GL.Begin(PrimitiveType.Lines);

            //desenam pozitia axei pozitive X
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(axis_size, 0, 0);

            //desenam pozitia axei negative X
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(-axis_size, 0, 0);

            //desenam pozitia axei pozitive Y
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, axis_size, 0);

            //desenam pozitia axei negative Y
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, -axis_size, 0);

            //desenam pozitia axei pozitive Z
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, axis_size);

            //desenam pozitia axei negative Z
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, -axis_size);

            GL.End();
        }
    }
}