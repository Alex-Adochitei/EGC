using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Adochitei_Alexandru_3131A_Lab5
{
    internal class Camera_3D
    {

        private Vector3 eye; //pozitia camere in spatiul 3D
        private Vector3 target; //punctul catre care se indreapta camera
        private Vector3 up; //vectorul care indica orientarea sus a camerei

        private const int MOVEMENT_UNIT = 3; //unitatea de deplasare a camerei
        private const int ZOOM_UNIT = 3; //unitatea de zoom a camerei

        //constructorul implicit al camerei
        public Camera_3D()
        {
            eye = new Vector3(125, 75, 25);
            target = new Vector3(0, 25, 0);
            up = new Vector3(0, 1, 0);
        }

        //constructor care primeste pozitii specifice pentru camera, punctul de vizare si vectorul sus
        public Camera_3D(int _eyeX, int _eyeY, int _eyeZ, int _targetX, int _targetY, int _targetZ, int _upX, int _upY, int _upZ)
        {
            eye = new Vector3(_eyeX, _eyeY, _eyeZ);
            target = new Vector3(_targetX, _targetY, _targetZ);
            up = new Vector3(_upX, _upY, _upZ);
        }

        //constructor care primeste pozitia, punctul de vizare si vectorul sus sub forma de Vector3
        public Camera_3D(Vector3 _eye, Vector3 _target, Vector3 _up)
        {
            eye = _eye;
            target = _target;
            up = _up;
        }

        //metoda pentru a seta camera in OpenGL folosind functia LookAt
        public void SetCamera()
        {
            Matrix4 camera = Matrix4.LookAt(eye, target, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        //metode pentru miscarea camerei in dreapta si stanga
        public void MoveRight()
        {
            eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            target = new Vector3(target.X, target.Y, target.Z - MOVEMENT_UNIT);
            SetCamera();
        }
        public void MoveLeft()
        {
            eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            target = new Vector3(target.X, target.Y, target.Z + MOVEMENT_UNIT);
            SetCamera();
        }

        //metode pentru miscarea camerei in fata si spate
        public void MoveForward()
        {
            eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X - MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }
        public void MoveBackward()
        {
            eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X + MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }

        //metode pentru miscarea camerei in sus si jos
        public void MoveUp()
        {
            eye = new Vector3(eye.X, eye.Y + MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y + MOVEMENT_UNIT, target.Z);
            SetCamera();
        }
        public void MoveDown()
        {
            eye = new Vector3(eye.X, eye.Y - MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y - MOVEMENT_UNIT, target.Z);
            SetCamera();
        }

        //metode pentru a apropia sau indeparta camera
        public void ZoomOut()
        {
            eye = new Vector3(eye.X + ZOOM_UNIT, eye.Y + ZOOM_UNIT, eye.Z);
            target = new Vector3(target.X + ZOOM_UNIT, target.Y + ZOOM_UNIT, target.Z);
            SetCamera();
        }
        public void ZoomIn()
        {
            eye = new Vector3(eye.X - ZOOM_UNIT, eye.Y - ZOOM_UNIT, eye.Z);
            target = new Vector3(target.X - ZOOM_UNIT, target.Y - ZOOM_UNIT, target.Z);
            SetCamera();
        }

        //metode pentru a seta distanta fata de obiecte
        public void Near()
        {
            eye = new Vector3(125, 100, 25);
            target = new Vector3(0, 25, 0);
            SetCamera();
        }
        public void Far()
        {
            eye = new Vector3(200, 175, 25);
            target = new Vector3(0, 25, 0);
            SetCamera();
        }

        //metode pentru a roti camera in jurul puctului de vizare
        public void RotateRight()
        {
            Matrix3 rotationMatrix = Matrix3.CreateRotationY(MathHelper.DegreesToRadians(MOVEMENT_UNIT));
            eye = Vector3.Transform(eye - target, rotationMatrix) + target;
            SetCamera();
        }
        public void RotateLeft()
        {
            Matrix3 rotationMatrix = Matrix3.CreateRotationY(MathHelper.DegreesToRadians(-MOVEMENT_UNIT));
            eye = Vector3.Transform(eye - target, rotationMatrix) + target;
            SetCamera();
        }
    }
}