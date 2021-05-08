using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Tasker.Local.Models
{
    public class TaskProgramModel
    {
        public string Name { get; internal set; }
        public string AutomationId { get; internal set; }
        public int Left { get; internal set; }
        public int Top { get; internal set; }
        public int Right { get; internal set; }
        public int Bottom { get; internal set; }
    }
}
