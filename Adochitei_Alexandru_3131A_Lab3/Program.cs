namespace Adochitei_Alexandru_3131A_Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(Window_3D ex = new Window_3D())
            {
                ex.Run(100.0, 100.0);
            }
        }
    }
}