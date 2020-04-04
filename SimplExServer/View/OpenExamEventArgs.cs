using System;

namespace SimplExServer.View
{
    public class OpenExamEventArgs : EventArgs
    {
        public string FilePath { get; private set; }
        public string Password { get; private set; }
        public OpenExamEventArgs(string filePath, string password)
        {
            FilePath = filePath;
            Password = password;
        }
    }
}
