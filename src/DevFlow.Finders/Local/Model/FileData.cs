using DevFlow.Finders.Local.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Finders.Local.Model
{
    public class FileData
    {
        public string Extension { get; set; }
        public string FileName { get; set; }
        public long? FileSize { get; set; }
        public FileTypes FileType { get; set; }
        public string FullName { get; set; }
        public object IconSource { get; set; }
        public bool IsEditMode { get; set; }
        public bool IsReadOnly { get { return IsEditMode != true; } }
        public string LastAccessTime { get; set; }
        public string LastWriteTime { get; set; }

        public static FileData ParentDir(DirectoryInfo dir)
        {
            var parent = new FileData
            {
                FileType = FileTypes.Parent,
                FileName = "..",
                FullName = dir.FullName,
                FileSize = null
            };
            return parent;
        }
    }
}
