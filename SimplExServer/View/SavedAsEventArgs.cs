using System;

namespace SimplExServer.View
{
    public class SaveExamEventArgs : EventArgs
    {
        public string FilePath { get; set; }
        public SaveExamEventArgs(string filePath)
        {
            FilePath = filePath;
        }
    }
}
