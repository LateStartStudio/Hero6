namespace LateStartStudio.Hero6
{
    using System;
    using System.Diagnostics;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            const string Renderer = "DirectX";
            //const string Renderer = "OpenGL";

            if (Renderer.Equals("DirectX"))
            {
                Process.Start(@"bin\Hero6.WindowsDX.exe");
            }
            else if (Renderer.Equals("OpenGL"))
            {
                Process.Start(@"bin\Hero6.DesktopGL.exe");
            }
        }
    }
}
