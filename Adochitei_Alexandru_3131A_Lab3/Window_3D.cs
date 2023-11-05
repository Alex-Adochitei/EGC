using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace Adochitei_Alexandru_3131A_Lab3
{
    //clasa care reprezinta fereastra 3D
    class Window_3D : GameWindow
    {
        KeyboardState previousKeyboard;

        //initializarea componentelor pentru culorile triunghiului
        private double r = 1;
        private double g = 1;
        private double b = 1;
        private double a = 1;

        //constanta marimii pentru axe
        public const int axis_size = 75;

        //vector pentru stocarea coordonatelor triunghiului
        private Vector3[] crd = new Vector3[3];

        private Camera_3D cmr;
        private Color_Handler ch;

        //culori pentru coordonatele triunghiului
        private Color clr1;
        private Color clr2;
        private Color clr3;

        //constructor pentru fereastra 3D
        public Window_3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            //citeste coodronatele triunghiului dintr-un fisier txt
            string text = System.IO.File.ReadAllText(@"./../../coordonate.txt");
            string[] lines = text.Split('\n');

            for(int i = 0; i < lines.Length; i++)
            {
                string[] textCoord = lines[i].Split(' ');
                crd[i][0] = int.Parse(textCoord[0]);
                crd[i][1] = int.Parse(textCoord[1]);
                crd[i][2] = int.Parse(textCoord[2]);
            }

            VSync = VSyncMode.On;
            cmr = new Camera_3D();
            ch = new Color_Handler();

            //genereaz o culoarea aleatorie pentru coordonatele triunghiului
            clr1 = ch.GenerateRandomColor();
            clr2 = ch.GenerateRandomColor();
            clr3 = ch.GenerateRandomColor();

            displayHelp();
        }

        //metoda pentru incarcarea ferestrei
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.LightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        //metoda pentru modificarea dimensiunii ferestrei
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //seteaza viewport si matricea de proiectie bazata pe dimensiunile ferestrei
            GL.Viewport(0, 0, this.Width, this.Height);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            //seteaza pozitia si orientarea camerei
            cmr.SetCamera();
        }

        //metoda pentru updatarea frame-ului
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            //utilizeaza inputul tastaturii si mouse-ului
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMouse = Mouse.GetState();

            //controleaza camera folosind input de la mouse
            cmr.ControlCamera(thisMouse);

            //modifica culorile triunghiului in functie de inputul tastelor
            ch.SetColor(thisKeyboard, ref a, ref r, ref b, ref g);

            //modifica culorile vortexisor triunghiului in functie de inputul tastelor
            ch.SetVertexColors(thisKeyboard, ref clr1, ref clr2, ref clr3);

            //verifica daca o tasta a fost apasata si executa comanda
            if(thisKeyboard[Key.Escape])
            {
                Exit();
                return;
            }
            if(thisKeyboard[Key.X] && !previousKeyboard[Key.X])
               ch.SetTriangleToWhite(thisKeyboard, ref clr1, ref clr2, ref clr3);

            previousKeyboard = thisKeyboard;
        }

        //metoda pentru randarea frame-ului
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            DrawAxes();
            DrawObjects();
            SwapBuffers();
        }

        //metoda pentru desenarea axelor
        private void DrawAxes()

        {
            //exercitiul 1, desenarea axelor folosind un singur apel GL.Begin()
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

        //metoda pentru desenarea celor doua triunghiuri
        private void DrawObjects()
        {
            //desenam triunghiul din dreapta utilizand coordonatele din fisierul txt
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(a, r, g, b);
            GL.Vertex3(crd[0][0], crd[0][1], crd[0][2]);
            GL.Vertex3(crd[1][0], crd[1][1], crd[1][2]);
            GL.Vertex3(crd[2][0], crd[2][1], crd[2][2]);
            GL.End();

            //desenam triunghiul din stanga
            GL.Begin(PrimitiveType.TriangleStrip);
            GL.Color3(clr1);
            GL.Vertex3(0, 0, 10);
            GL.Color3(clr2);
            GL.Vertex3(-10, 0, 0);
            GL.Color3(clr3);
            GL.Vertex3(0, 10, 0);
            GL.End();
        }

        //metoda ce afiseaza un meniu in consola
        private void displayHelp()
        {
            Console.WriteLine("\n|--------------------------------------------------------------------------|");
            Console.WriteLine("| Meniu de utilizare                                                       |");
            Console.WriteLine("|--------------------------------------------------------------------------|");
            Console.WriteLine("| Pentru a iesi din aplicatie apasati: ESC                                 |");
            Console.WriteLine("| Pentru a seta culoarea triunghiului la alb apasati: X                    |");
            Console.WriteLine("| Pentru a roti camera apasati: Click Stanga                               |");
            Console.WriteLine("|--------------------------------------------------------------------------|");
            Console.WriteLine("| Pentru a seta culoarea vortexului din dreapta jos la rosu apasati: 1     |");
            Console.WriteLine("| Pentru a seta culoarea vortexului din dreapta jos la verde apasati: 2    |");
            Console.WriteLine("| Pentru a seta culoarea vortexului din dreapta jos la albastru apasati: 3 |");
            Console.WriteLine("| Pentru a seta culoarea vortexului din stanga jos la rosu apasati: 4      |");
            Console.WriteLine("| Pentru a seta culoarea vortexului din stanga jos la verde apasati: 5     |");
            Console.WriteLine("| Pentru a seta culoarea vortexului din stanga jos la albastru apasati: 6  |");
            Console.WriteLine("| Pentru a seta culoarea vortexului din dreapta sus la rosu apasati: 7     |");
            Console.WriteLine("| Pentru a seta culoarea vortexului din dreapta sus la verde apasati: 8    |");
            Console.WriteLine("| Pentru a seta culoarea vortexului din dreapta sus la albastru apasati: 9 |");
            Console.WriteLine("|--------------------------------------------------------------------------|");
            Console.WriteLine("| Pentru a creste componenta rosie apasati: Sageata sus + R                |");
            Console.WriteLine("| Pentru a scadea componenta rosie apasati: Sageata jos + R                |");
            Console.WriteLine("| Pentru a creste componenta albastra apasati: Sageata sus + A             |");
            Console.WriteLine("| Pentru a scadea componenta albastra apasati: Sageata jos + A             |");
            Console.WriteLine("| Pentru a creste componenta verde apasati: Sageata sus + V                |");
            Console.WriteLine("| Pentru a scadea componenta verde apasati: Sageata jos + V                |");
            Console.WriteLine("| Pentru a creste transparenta apasati: Sageata sus + T                    |");
            Console.WriteLine("| Pentru a scadea transparenta apasati: Sageata jos + T                    |");
            Console.WriteLine("|--------------------------------------------------------------------------|");
            Console.WriteLine("\n");
        }
    }
}