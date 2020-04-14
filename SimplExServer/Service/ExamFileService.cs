using SimplExModel.Model;
using System;
using System.IO;
using Newtonsoft.Json;
using SimplExModel.Service;

namespace SimplExServer.Service
{
    class ExamFileService
    {
        private static ExamFileService instance;
        private readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented
        };
        private ExamFileService()
        {
        }
        public void SaveExam(Exam exam, string filePath)
        {
            ExamSerializationService examSerializationService = ExamSerializationService.GetInstance();
            byte[] data = examSerializationService.SerializeEncrypted(exam);
            File.WriteAllText(filePath, string.Empty);
            using (FileStream stream = File.OpenWrite(filePath))
            {
                stream.Write(data, 0, data.Length);
            }
        }
        public Exam OpenExam(string filePath, string password)
        {
            Exam result = null;
            if (Path.GetExtension(filePath) != ".smpx")
                throw new ArgumentException("Invalid file extension");
            using (FileStream stream = File.OpenRead(filePath))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                ExamSerializationService examSerializationService = ExamSerializationService.GetInstance();
                result = examSerializationService.DeserializeEncrypted(data, password);
            }
            return result;
        }
        public static ExamFileService GetInstance()
        {
            if (instance == null)
                instance = new ExamFileService();
            return instance;
        }
    }
}
