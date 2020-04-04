using SimplExServer.Model;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace SimplExServer.Services
{
    static class ExamFileWorker
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented
        };
        public static void SaveExam(Exam exam, string filePath)
        {
            byte[] data = Encoding.Unicode.GetBytes("[Password Header]" + JsonConvert.SerializeObject(exam, settings));
            if (exam.Password != null && exam.Password.Length > 0)
                data = Encryptor.Encrypt((byte[])data.Clone(), exam.Password);
            File.WriteAllText(filePath, string.Empty);
            using (FileStream stream = File.OpenWrite(filePath))
            {
                stream.Write(data, 0, data.Length);
            }
        }
        public static Exam OpenExam(string filePath, string password)
        {
            Exam result = null;
            if (Path.GetExtension(filePath) != ".smpx")
                throw new ArgumentException("Invalid file extension");
            using (FileStream stream = File.OpenRead(filePath))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                string temp = string.Empty;
                if (password != null && password.Length > 0)
                {
                    data = Encryptor.Decrypt((byte[])data.Clone(), password);
                    temp = Encoding.Unicode.GetString(data);
                    if (temp.Substring(0, 17) != "[Password Header]")
                        throw new InvalidPasswordException();
                }
                else
                    temp = Encoding.Unicode.GetString(data);
                temp = temp.Remove(0, 17);
                result = JsonConvert.DeserializeObject<Exam>(temp, settings);
            }
            return result;
        }
    }
}
