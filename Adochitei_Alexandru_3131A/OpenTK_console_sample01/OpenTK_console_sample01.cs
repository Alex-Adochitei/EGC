//Alexandru Adochitei 3131A

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

/*
 * Am modificat proiectul OpenTK_console_sample01 pentru a putea controla
 * obiectul randat prin apasarea a 2 taste, W pentru a-l misca in sus si S
 * pentru a-l misca in jos, si prin miscarea mouse-ului.
 */

namespace OpenTK_console_sample01
{
    class SimpleWindow : GameWindow
    {
        private Vector2 objectPosition = Vector2.Zero; //Pozitia obiectului.
        private float objectSpeed = 0.02f; //Viteza de deplasare a obiectului.

        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
            MouseMove += Mouse_Move; //Apelam metoda Mouse_Move atunci cand miscam mouse-ul in fereastra OpenGL
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();
            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;

            //Inceputul punctul 2 al temei.
            //Am adaugat la metoda deja existenta, Keyboard_KeyDown, secventa de cod de mai jos
            //pentru controlul obiectului cu tastele W (sus) și S (jos).
            if (e.Key == Key.W)
                objectPosition.Y += objectSpeed;
            if (e.Key == Key.S)
                objectPosition.Y -= objectSpeed;
        }

        //Am adaugat metoda Mouse_Move pentru a putea controla obiectul prin miscarea mouse-ului.
        void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            objectPosition.X = (2.0f * e.X / Width) - 1.0f;
            objectPosition.Y = -((2.0f * e.Y / Height) - 1.0f);
        }
        //Sfarsitului punctului 2 al temei.

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            /*
             * Punctui 1 al temei:
             * Daca modificam valoarea constantei MatrixMode modificam modul
             * in care este proiectat si afisat obiectul in fereastra OpenGl.
             * Noi folosim valoarea Projection, dupa care apelam GL.Ortho
             * pentru a defini o matrice ortografica. Daca schimbam valoarea 
             * lui MatrixMode cu Modelview utilizam matricea de modelare
             * si vizualizare in loc de matricea de proiectie.
             */
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(objectPosition.X, objectPosition.Y, -2.0);

            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-0.5f, 0.5f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -0.5f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(0.5f, 0.5f);

            GL.End();

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}