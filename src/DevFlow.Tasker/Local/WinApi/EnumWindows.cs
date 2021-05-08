using DevFlow.Tasker.Local.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using UIAutomationClient;

namespace DevFlow.Tasker.Local.WinApi
{
    public class EnumWindows
    {
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        internal static EnumWindows Instance;

        static EnumWindows()
        {
            Instance = new EnumWindows();
        }

        private EnumWindows()
        {
            
        }

        internal List<TaskProgramModel> GetTaskPrograms()
        {
            List<TaskProgramModel> programs = new List<TaskProgramModel>();

            IntPtr hWndTray = FindWindow("Shell_TrayWnd", null);
            IntPtr hWndTrayNotify = FindWindowEx(hWndTray, IntPtr.Zero, "TrayNotifyWnd", null);
            IntPtr hWndSysPager = FindWindowEx(hWndTrayNotify, IntPtr.Zero, "SysPager", null);
            IntPtr hWndToolbar = FindWindowEx(hWndSysPager, IntPtr.Zero, "ToolbarWindow32", null);

            IntPtr hWndRebar = FindWindowEx(hWndTray, IntPtr.Zero, "ReBarWindow32", null);
            IntPtr hWndMSTaskSwWClass = FindWindowEx(hWndRebar, IntPtr.Zero, "MSTaskSwWClass", null);
            IntPtr hWndMSTaskListWClass = FindWindowEx(hWndMSTaskSwWClass, IntPtr.Zero, "MSTaskListWClass", null);

            IUIAutomation pUIAutomation = new CUIAutomation();

            // Taskbar
            IUIAutomationElement windowElement = pUIAutomation.ElementFromHandle(hWndMSTaskListWClass);
            if (windowElement != null)
            {
                IUIAutomationElementArray elementArray = null;
                IUIAutomationCondition condition = pUIAutomation.CreateTrueCondition();
                elementArray = windowElement.FindAll(TreeScope.TreeScope_Descendants | TreeScope.TreeScope_Children, condition);
                if (elementArray != null)
                {
                    Console.WriteLine("Taskbar");
                    int nNbItems = elementArray.Length;
                    for (int nItem = 0; nItem <= nNbItems - 1; nItem++)
                    {
                        IUIAutomationElement element = elementArray.GetElement(nItem);
                        string sName = element.CurrentName;
                        string sAutomationId = element.CurrentAutomationId;
                        tagRECT rect = element.CurrentBoundingRectangle;
                        Console.WriteLine("\tName : {0} - AutomationId : {1}  - Rect({2}, {3}, {4}, {5})", sName, sAutomationId, rect.left, rect.top, rect.right, rect.bottom);
                        programs.Add(new TaskProgramModel { Name = sName, AutomationId = sAutomationId, Left = rect.left, Top = rect.top, Right = rect.right, Bottom = rect.bottom });
                    }
                }
            }

            // Tray icons
            IUIAutomationElement windowElementTray = pUIAutomation.ElementFromHandle(hWndTrayNotify);
            if (windowElementTray != null)
            {
                IUIAutomationElementArray elementArray = null;
                IUIAutomationCondition condition = pUIAutomation.CreateTrueCondition();
                elementArray = windowElementTray.FindAll(TreeScope.TreeScope_Descendants | TreeScope.TreeScope_Children, condition);
                if (elementArray != null)
                {
                    Console.WriteLine("Tray Icons");
                    int nNbItems = elementArray.Length;
                    for (int nItem = 0; nItem <= nNbItems - 1; nItem++)
                    {
                        IUIAutomationElement element = elementArray.GetElement(nItem);
                        string sName = element.CurrentName;
                        string sAutomationId = element.CurrentAutomationId;
                        tagRECT rect = element.CurrentBoundingRectangle;
                        Console.WriteLine("\tName : {0} - AutomationId : {1}  - Rect({2}, {3}, {4}, {5})", sName, sAutomationId, rect.left, rect.top, rect.right, rect.bottom);
                    }
                }
            }

            return programs;
        }
    }
}
