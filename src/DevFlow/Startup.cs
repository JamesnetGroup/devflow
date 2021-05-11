using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow
{
    public class Startup
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new DevFlowApp().Run();
        }

    }
}
