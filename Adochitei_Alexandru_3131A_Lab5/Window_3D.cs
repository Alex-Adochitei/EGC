using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Adochitei_Alexandru_3131A_Lab5
{
    class Window_3D : GameWindow
    {
        //starea tastaturii si mouse-ului anterior
        private KeyboardState previousKeyboard;
        private MouseState previousMouse;

        private readonly Randomizer r; //generatorul de numere aleatorii
        private readonly Axis xyz; //obiectul pentru axele de coordonate
        private readonly Grid grid; //obiectul pentru grila
        private readonly Camera_3D cam; //obiectul pentru camera
        private bool displayMarker; //indicator pentru afisarea marcarilor
        private ulong updatesCounter; //contor pentru actualizari
        private ulong framesCounter; //contor pentru cadre
        private BigObject obj; //obiectul 3D principal

        private List<Object> ObjList; //lista de obiecte
        private List<Vector3> Ver; //lista de vectori de coordonate
        private List<BigObject> bigObjList; //lista de obiecte BigObject

        private readonly Color Background_Color = Color.FromArgb(84, 195, 234); //culoare de fundal implicita

        //constructor pentru fereastra 3D
        public Window_3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On; //activarea VSync

            r = new Randomizer();
            xyz = new Axis();
            grid = new Grid();
            cam = new Camera_3D();
            obj = new BigObject(Color.Yellow);

            Ver = readVerticesFromFile(@"./../../coordonate.txt"); //citeste coordonatele din fisier

            ObjList = new List<Object>(); //initializeaza lista de obiecte

            bigObjList = new List<BigObject>(); //initializeaza lista de obiecte BigObject

            displayHelp();

            displayMarker = false; //initializeaza indicatorul pentru marcari
            updatesCounter = 0; //initializeaza contorulul pentru actualizari
            framesCounter = 0; //initializeaza contorulul pentru cadre
        }

        //metoda de incarcare a ferestrei
        protected override void OnLoad(EventArgs e)
        {
            //configureaza OpenGL la incarcarea ferestrei
            base.OnLoad(e);
            GL.ClearColor(Color.LightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        //metoda de redimensionare a ferestrei
        protected override void OnResize(EventArgs e)
        {
            //redimensioneaza si seteaza perspectiva
            base.OnResize(e);
            GL.Viewport(0, 0, this.Width, this.Height);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            cam.SetCamera();
        }

        //metoda de actualizare a ferestrei
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            //actualizeaza starea
            base.OnUpdateFrame(e);
            updatesCounter++; //incrementeaza contorulul pentru actualizari

            //afiseaza marca daca este activa
            if (displayMarker)
            {
                TimeStampIt("Update", updatesCounter.ToString());
            }

            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMouse = Mouse.GetState();

            //verifica tastele apasate pentru diferite actiuni
            if (thisKeyboard[Key.Escape])
            {
                Exit();
                return;
            }
            if (thisKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(Background_Color);
                xyz.Show();
                grid.Show();
                ObjList.Clear();
            }
            if (thisKeyboard[Key.T] && !previousKeyboard[Key.T])
            {
                xyz.ToggleVisibility();
            }
            if (thisKeyboard[Key.F] && !previousKeyboard[Key.F])
            {
                GL.ClearColor(r.RandomColor());
            }
            if (thisKeyboard[Key.G] && !previousKeyboard[Key.G])
            {
                grid.ToggleVisibility();
            }
            if (thisKeyboard[Key.Y] && !previousKeyboard[Key.Y])
            {
                obj.ToggleVisibility();
            }

            //misca camera
            if (thisKeyboard[Key.W])
            {
                cam.MoveForward();
            }
            if (thisKeyboard[Key.S])
            {
                cam.MoveBackward();
            }
            if (thisKeyboard[Key.A])
            {
                cam.MoveLeft();
            }
            if (thisKeyboard[Key.D])
            {
                cam.MoveRight();
            }
            
            //zoom
            if (thisKeyboard[Key.E])
            {
                cam.ZoomOut();
            }
            if (thisKeyboard[Key.Q])
            {
                cam.ZoomIn();
            }

            //pozitie prestabilita a camerei
            if (thisKeyboard[Key.Number1])
            {
                cam.Far();
            }
            if (thisKeyboard[Key.Number2])
            {
                cam.Near();
            }

            //adauga obiecte
            if (thisMouse[MouseButton.Left] && !previousMouse[MouseButton.Left])
            {
                ObjList.Add(new Object(true, Ver));
            }

            //actualizeaza pozitia obiectelor
            foreach (Object obj in ObjList)
            {
                obj.UpdatePosition(true);
            }
            foreach (BigObject obj in bigObjList)
            {
                obj.UpdatePosition(true);
            }

            previousKeyboard = thisKeyboard;
            previousMouse = thisMouse;
        }

        //metoda de randare a ferestrei
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //deseneaza elementelor
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            grid.Draw();
            xyz.Draw();
            obj.Draw();

            foreach (Object obj in ObjList)
            {
                obj.Draw();
            }

            foreach (BigObject obj in bigObjList)
            {
                obj.Draw();
            }

            SwapBuffers();
        }

        //functie pentru citirea vertexilor din fisier
        public List<Vector3> readVerticesFromFile(string numeFisier)
        {
            //citeste si parseaza coordonate din fisier
            List<Vector3> file = new List<Vector3>();

            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    var no = linie.Split(',');
                    int i = 0;
                    float[] coordonate = new float[3];
                    foreach (var nr in no)
                    {
                        coordonate[i++] = float.Parse(nr);

                        if (coordonate[i - 1] < 0 || coordonate[i - 1] > 250)
                        {
                            throw new ArithmeticException("Invalid vertex!");
                        }
                    }
                    file.Add(new Vector3(coordonate[0], coordonate[1], coordonate[2]));
                }
            }
            return file;
        }

        //functie pentru marcarea momentului in cod
        private void TimeStampIt(String source, String counter)
        {
            //afiseaza unui marcaj de timp
            String dt = DateTime.Now.ToString("hh:mm:ss.ffff");
            Console.WriteLine("\tTSTAMP from <" + source + "> on iteration <" + counter + ">: " + dt);
        }

        //functie pentru afisarea informatiilor de ajutor
        private void displayHelp()
        {
            //afiseaza instructiuni de utilizare
            Console.WriteLine("\n____________________________________________________________________");
            Console.WriteLine("| MENIU                                                            |");
            Console.WriteLine("|------------------------------------------------------------------|");
            Console.WriteLine("| Pentru a iesi din aplicatie apasati: ESC                         |");
            Console.WriteLine("| Pentru a comuta vizibilitatea grilelor apasati: G                |");
            Console.WriteLine("| Pentru a reseta scena la valorile initiale apasati :R            |");
            Console.WriteLine("| Pentru a schimba culoarea de fundal apasati: F                   |");
            Console.WriteLine("| Pentru a comuta vizibilitatea axelor apasati: T                  |");
            Console.WriteLine("| Pentru a muta camera apasati: W, A, S, D                         |");
            Console.WriteLine("| Pentru a seta camera la pozitii predefinite apasati: 1, 2        |");
            Console.WriteLine("| Pentru zoom apasati: Q pentru a apropia si E pentru a indeparta  |");
            Console.WriteLine("| Pentru a genera un obiect aleatoriu apasati: Click dreapta       |");
            Console.WriteLine("|__________________________________________________________________|\n");
        }
    }
}