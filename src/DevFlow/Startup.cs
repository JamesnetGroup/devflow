using System;

namespace DevFlow
{
    public class Startup
    {
        [STAThread]
        public static void Main(string[] args)
        {
            _ = new App().Run();
        }
    }
}
