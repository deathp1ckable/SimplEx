using SimplExModel.Model;
using Newtonsoft.Json;
using System.Text;

namespace SimplExModel.Service
{
    public class ExamSerializationService
    {
        private static ExamSerializationService instance;
        private readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented
        };
        private ExamSerializationService()
        {
        }
        public byte[] Serialize(Exam exam)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(exam, settings));
            return buffer;
        }
        public Exam Deserialize(byte[] data)
        {
            string temp;
            temp = Encoding.Unicode.GetString(data);
            return JsonConvert.DeserializeObject<Exam>(temp, settings);
        }
        public byte[] SerializeEncrypted(Exam exam)
        {
            byte[] buffer = Encoding.Unicode.GetBytes("[Password Header]" + JsonConvert.SerializeObject(exam, settings));
            if (exam.Password != null && exam.Password.Length > 0)
            {
                EncryptionService encryptor = EncryptionService.GetInstance();
                buffer = encryptor.Encrypt((byte[])buffer.Clone(), exam.Password);
            }
            return buffer;
        }
        public Exam DeserializeEncrypted(byte[] data, string password)
        {
            string temp;
            if (password != null && password.Length > 0)
            {
                EncryptionService encryptor = EncryptionService.GetInstance();
                byte[] buffer = encryptor.Decrypt((byte[])data.Clone(), password);
                temp = Encoding.Unicode.GetString(buffer);
                if (temp.Substring(0, 17) != "[Password Header]")
                    throw new InvalidPasswordException();
            }
            else
                temp = Encoding.Unicode.GetString(data);
            temp = temp.Remove(0, 17);
            return JsonConvert.DeserializeObject<Exam>(temp, settings);
        }
        public static ExamSerializationService GetInstance()
        {
            if (instance == null)
                instance = new ExamSerializationService();
            return instance;
        }
    }
}
