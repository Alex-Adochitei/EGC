using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Adochitei_Alexandru_3131A_Lab4
{
    internal class Camera_3D
    {
        private const int VISUAL_EDGE = 40;
        private Vector3 eye = new Vector3(0, 20, 40);
        private Vector3 target = new Vector3(0, 0, 0);
        private Vector3 up = new Vector3(0, 1, 0);
        private const int MOVEMENT_UNIT = 1;

        //initializare camera
        public void SetCamera()
        {
            Matrix4 camera = Matrix4.LookAt(eye, target, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        //verifica pozitia camerei si o muta cu o unitate la dreapta
        public void RotateRight()
        {
            if(eye.X < VISUAL_EDGE && eye.Z >= VISUAL_EDGE)
                eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            else if(eye.X >= VISUAL_EDGE && eye.Z > -VISUAL_EDGE)
                eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            else if(eye.X > -VISUAL_EDGE && eye.Z <= VISUAL_EDGE)
                eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            else
                eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            SetCamera();
        }

        //verifica pozitia camerei si o muta cu o unitate la stanga
        public void RotateLeft()
        {
            if(eye.X < -VISUAL_EDGE && eye.Z >= VISUAL_EDGE)
                eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            else if(eye.X <= -VISUAL_EDGE && eye.Z > -VISUAL_EDGE)
                eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            else if(eye.X < VISUAL_EDGE && eye.Z <= -VISUAL_EDGE)
                eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            else
                eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            SetCamera();
        }

        //verifica starea camerei
        public void ControlCamera(MouseState mouse)
        {
            if(mouse[MouseButton.Left] && mouse.X > 100)
            {
                this.RotateRight();
            }
            else if(mouse[MouseButton.Left] && mouse.X < 100)
            {
                this.RotateLeft();
            }
        }
    }
}