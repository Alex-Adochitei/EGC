using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace Adochitei_Alexandru_3131A_Lab4
{
    //clasa care reprezinta fereastra 3D
    class Window_3D : GameWindow
    {
        private Camera_3D cmr;
        private Cube cube;
        private Axis axis;

        //constructor pentru fereastra 3D
        public Window_3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            //afisarea versiunii de OpenTK
            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            Title = "OpenGl versiunea: " + GL.GetString(StringName.Version);

            //instantierea unui cub folosind coordonatele din fisierul trimis ca parametru
            cube = new Cube("./../../coordonate.txt");

            VSync = VSyncMode.On;
            cmr = new Camera_3D();
            axis = new Axis();

            displayHelp();
        }

        //metoda pentru incarcarea ferestrei
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Aqua);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        //metoda pentru modificarea dimensiunii ferestrei
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            cmr.SetCamera();
        }

        //metoda pentru updatarea frame-ului
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            //instantiere obiecte pentru preluarea starii tastaturii si mouse-ului
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            //setarea culorilor si a pozitiei camerei la detectarea anumitor inputuri de la mouse sau tastatura
            cmr.ControlCamera(mouse);
            cube.SetColorCub();

            //verificare daca este apasata tasta Escape si parasirea aplicatiei
            if (keyboard[Key.Escape])
            {
                Exit();
            }
        }

        //metoda pentru randarea frame-ului
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            axis.Draw();
            cube.Draw();
            SwapBuffers();
        }       

        //metoda ce afiseaza un meniu in consola
        private void displayHelp()
        {
            Console.WriteLine("\n|-------------------------------------------------------------|");
            Console.WriteLine("| Meniu de utilizare                                            |");
            Console.WriteLine("|---------------------------------------------------------------|");
            Console.WriteLine("| Pentru a iesi din aplicatie apasati: ESC                      |");
            Console.WriteLine("| Pentru a roti camera apasati: Click Stanga                    |");
            Console.WriteLine("|---------------------------------------------------------------|");
            Console.WriteLine("| Pentru a seta culoarea vortexului 1 la rosu apasati: 1        |");
            Console.WriteLine("| Pentru a seta culoarea vortexului 1 la verde apasati: 2       |");
            Console.WriteLine("| Pentru a seta culoarea vortexului 1 la albastru apasati: 3    |");
            Console.WriteLine("| Pentru a seta culoarea vortexului 2 la rosu apasati: 4        |");
            Console.WriteLine("| Pentru a seta culoarea vortexului 2 la verde apasati: 5       |");
            Console.WriteLine("| Pentru a seta culoarea vortexului 2 la albastru apasati: 6    |");
            Console.WriteLine("| Pentru a seta culoarea vortexului 3 la rosu apasati: 7        |");
            Console.WriteLine("| Pentru a seta culoarea vortexului 3 la verde apasati: 8       |");
            Console.WriteLine("| Pentru a seta culoarea vortexului 3 la albastru apasati: 9    |");
            Console.WriteLine("|---------------------------------------------------------------|");
            Console.WriteLine("| Pentru a creste componenta rosie apasati: Sageata sus + R     |");
            Console.WriteLine("| Pentru a scadea componenta rosie apasati: Sageata jos + R     |");
            Console.WriteLine("| Pentru a creste componenta albastra apasati: Sageata sus + A  |");
            Console.WriteLine("| Pentru a scadea componenta albastra apasati: Sageata jos + A  |");
            Console.WriteLine("| Pentru a creste componenta verde apasati: Sageata sus + V     |");
            Console.WriteLine("| Pentru a scadea componenta verde apasati: Sageata jos + V     |");
            Console.WriteLine("| Pentru a creste transparenta apasati: Sageata sus + T         |");
            Console.WriteLine("| Pentru a scadea transparenta apasati: Sageata jos + T         |");
            Console.WriteLine("|---------------------------------------------------------------|");
            Console.WriteLine("\n");
        }
    }
}