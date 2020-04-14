using SimplExModel.Model;
using System.Collections.Generic;
using System.IO;

namespace SimplExServer.Service
{
    class FileExamSaver : IExamSaver
    {
        private string filePath;
        private string password;
        public string SaverName { get; private set; }
        public FileExamSaver(string filePath, string password, string name)
        {
            this.filePath = filePath;
            this.password = password;
            SaverName = name;
        }
        public Exam GetExam()
        {
            Exam exam;
            try
            {
                ExamFileService fileService = ExamFileService.GetInstance();
                exam = fileService.OpenExam(filePath, password);
                password = exam.Password;
                SaverName = exam.Name;
            }
            catch
            {
                exam = null;
            }
            return exam;
        }
        public bool Save(Exam exam)
        {
            try
            {
                password = exam.Password;
                SaverName = exam.Name;
                ExamFileService fileService = ExamFileService.GetInstance();
                fileService.SaveExam(exam, filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                File.Delete(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override bool Equals(object obj) => obj is FileExamSaver saver && saver.filePath == filePath;
        public override int GetHashCode() => 120506532 + EqualityComparer<string>.Default.GetHashCode(filePath);
    }
}
