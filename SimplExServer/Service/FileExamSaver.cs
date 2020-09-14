using SimplExModel.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace SimplExServer.Service
{
    class FileExamSaver : IExamSaver
    {
        private Exam openedExam;
        private string filePath;
        private string password;
        public string LastExceptionMessage { get; private set; }
        public string SaverName { get; private set; }

        public FileExamSaver(string filePath, string password, string name)
        {
            this.filePath = filePath;
            this.password = password;
            SaverName = name;
        }
        public Exam GetExam()
        {
            if (openedExam != null)
                return openedExam;
            Exam exam;
            try
            {
                ExamFileService fileService = ExamFileService.GetInstance();
                exam = fileService.OpenExam(filePath, password);
                password = exam.Password;
                SaverName = exam.Name;
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                exam = null;
            }
            openedExam = exam;
            return exam;
        }
        public IList<Question> GetQuestions()
        {
            List<Question> result;
            if (openedExam != null)
            {
                result = new List<Question>();
                for (int i = 0; i < openedExam.Tickets.Count; i++)
                    result.AddRange(openedExam.Tickets[i].GetQuestions());
                return result;
            }
            Exam exam;
            try
            {
                result = new List<Question>();
                ExamFileService fileService = ExamFileService.GetInstance();
                exam = fileService.OpenExam(filePath, password);
                password = exam.Password;
                SaverName = exam.Name;
                openedExam = exam;
                for (int i = 0; i < openedExam.Tickets.Count; i++)
                    result.AddRange(openedExam.Tickets[i].GetQuestions());
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                result = null;
                exam = null;
            }
            openedExam = exam;
            return result;
        }
        public bool SaveResult(ExecutionResult executionResults)
        {
            Exam exam = GetExam();
            if (exam is null)
                return false;
            exam.ExecutionResults.Add(executionResults);
            try
            {
                password = exam.Password;
                SaverName = exam.Name;
                ExamFileService fileService = ExamFileService.GetInstance();
                fileService.SaveExam(exam, filePath);
                return true;
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                return false;
            }
        }
        public bool Save(Exam exam)
        {
            try
            {
                password = exam.Password;
                SaverName = exam.Name;
                ExamFileService fileService = ExamFileService.GetInstance();
                fileService.SaveExam(exam, filePath); 
                openedExam = exam;
                return true;
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                return false;
            }
        }
        public bool DeleteResult(ExecutionResult executionResult)
        {
            Exam exam = GetExam();
            if (exam is null)
                return false;
            exam.ExecutionResults.Remove(executionResult);
            try
            {
                password = exam.Password;
                SaverName = exam.Name;
                ExamFileService fileService = ExamFileService.GetInstance();
                fileService.SaveExam(exam, filePath);
                return true;
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
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
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                return false;
            }
        }
        public override bool Equals(object obj) => obj is FileExamSaver saver && saver.filePath == filePath;
        public override int GetHashCode() => 120506532 + EqualityComparer<string>.Default.GetHashCode(filePath);

    }
}
