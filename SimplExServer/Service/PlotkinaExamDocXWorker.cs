using Microsoft.Office.Interop.Word;
using SimplExModel.Model;
using SimplExModel.Model.Inherited;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace SimplExServer.Service
{
    class PlotkinaExamDocXWorker : IExamDocXWorker
    {
        private object path = Path.GetFullPath("temp.doc");
        private object missingObj = Missing.Value;
        private object trueObj = true;
        private object falseObj = false;
        private _Application application;
        private _Document document;

        public PlotkinaExamDocXWorker() { }
        public void OpenTask(Exam exam, Ticket ticket, bool markAnswers)
        {
            CloseWord();
            OneAnswerQuestion[] questions = ticket.GetQuestions().Cast<OneAnswerQuestion>().ToArray();
            using (DocX docXdocument = DocX.Create(path.ToString()))
            {
                int i, j;
                docXdocument.AddFooters();
                docXdocument.SetDefaultFont(new Xceed.Document.NET.Font("Times New Roman"));
                Xceed.Document.NET.Paragraph headerParagraph = docXdocument.InsertParagraph();
                Xceed.Document.NET.Paragraph paragraph = docXdocument.InsertParagraph();
                headerParagraph.Append($"Перегляд завдання")
                   .Bold()
                   .FontSize(28);
                paragraph.Append($"Завдання білету \"{ticket.TicketName}\":")
                    .FontSize(24);
                Xceed.Document.NET.Table table = docXdocument.AddTable(questions.Length, 2);
                table.SetWidthsPercentage(new[] { 50f, 50 }, docXdocument.PageWidth - docXdocument.PageWidth / 5);
                table.SetBorder(TableBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.Left, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.InsideV, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                for (i = 0; i < questions.Length; i++)
                {
                    table.Rows[i].Cells[0]
                        .InsertParagraph()
                        .Append($"{questions[i].QuestionNumber + exam.FirstQuestionNumber}) {questions[i].QuestionContent.Text}")
                        .FontSize(12);
                    Xceed.Document.NET.Paragraph tableParagraph = table.Rows[i].Cells[1].InsertParagraph();
                    for (j = 0; j < questions[i].QuestionContent.Answers.Count; j++)
                    {
                        Xceed.Document.NET.Paragraph tempParagraph = tableParagraph.Append($"{(j < questions[i].QuestionContent.Letters.Length ? questions[i].QuestionContent.Letters[j].ToString() : "*")}{questions[i].QuestionContent.Devider} { questions[i].QuestionContent.Answers[j]};{Environment.NewLine}");
                        if (markAnswers && questions[i].Answer.Content == questions[i].QuestionContent.Answers[j])
                            tempParagraph.Bold()
                                .FontSize(12);
                    }
                }
                docXdocument.InsertTable(table);
                docXdocument.Footers.Odd.InsertParagraph()
                      .Append("Створено за допомогою SimplEx Program")
                      .FontSize(10)
                      .UnderlineStyle(UnderlineStyle.singleLine)
                      .Alignment = Alignment.right;
                docXdocument.Save();
            }
            OpenWord();
        }

        public void OpenBlank(Exam exam, Ticket ticket, bool markAnswers)
        {
            CloseWord();
            using (DocX docXdocument = DocX.Create(path.ToString()))
            {
                int i, j;
                docXdocument.AddFooters();
                docXdocument.SetDefaultFont(new Xceed.Document.NET.Font("Times New Roman"), 14);
                Xceed.Document.NET.Paragraph headerParagraph = docXdocument.InsertParagraph();
                Xceed.Document.NET.Paragraph paragraph = docXdocument.InsertParagraph();
                headerParagraph.Append($"Виконання завдань")
                   .Bold()
                   .FontSize(16);
                paragraph = docXdocument.InsertParagraph();
                paragraph.Append($"Здобувач освіти")
                    .Bold()
                    .Append("\t\t\t\t\t\t\t")
                    .UnderlineStyle(UnderlineStyle.singleLine)
                    .Append("білет №")
                    .Bold()
                    .Append("\t\t")
                    .UnderlineStyle(UnderlineStyle.singleLine);
                paragraph = docXdocument.InsertParagraph();
                paragraph.Append($"{Environment.NewLine}I частина")
                    .Bold()
                    .Alignment = Alignment.center;
                paragraph = docXdocument.InsertParagraph();
                paragraph.Append($"\tОзнайомтесь з тестовим завданням. Дайте відповіді на тестові завдання в таблиці" +
                    $"(поряд із номером запитання зазначте номер правильної відповіді){Environment.NewLine}")
                    .Alignment = Alignment.left;
                List<OneAnswerQuestion[]> questionLists = new List<OneAnswerQuestion[]>();
                for (i = 0; i < exam.Themes.Count; i++)
                {
                    OneAnswerQuestion[] questions = exam.Themes[i].GetQuestions(ticket).Cast<OneAnswerQuestion>().ToArray();
                    Array.Sort(questions,
                    (Question a, Question b) =>
                     {
                         if (a.QuestionNumber > b.QuestionNumber)
                             return 1;
                         else if (a.QuestionNumber < b.QuestionNumber)
                             return -1;
                         return 0;
                     });
                    questionLists.Add(questions);
                }
                int max = questionLists.Max(a => a.Length);
                Xceed.Document.NET.Table table = docXdocument.AddTable(max + 1, questionLists.Count * 2);
                table.SetBorder(TableBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.Left, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                List<float> percentages = new List<float>();
                float pa = 30 / (table.ColumnCount / 2);
                float pb = 70 / (table.ColumnCount / 2);
                for (i = 0; i < table.ColumnCount / 2; i += 2)
                {
                    table.Rows[0].MergeCells(i, i + 1);
                    percentages.Add(pa);
                    percentages.Add(pb);
                    i--;
                }
                table.SetWidthsPercentage(percentages.ToArray(), docXdocument.PageWidth - docXdocument.PageWidth / 5);
                for (i = 0; i < exam.Themes.Count; i++)
                    table.Rows[0].Cells[i].InsertParagraph()
                        .Append(exam.Themes[i].ThemeName)
                        .Alignment = Alignment.center;
                for (i = 0; i < table.ColumnCount / 2; i ++)
                {
                    for (j = 0; j < questionLists[i].Length; j++)
                    {
                        table.Rows[1 + j].Cells[i * 2].InsertParagraph()
                              .Append($"{questionLists[i][j].QuestionNumber + exam.FirstQuestionNumber}");
                        if (markAnswers)
                        {
                            int index = questionLists[i][j].QuestionContent.Answers.IndexOf(questionLists[i][j].Answer.Content);
                            table.Rows[1 + j].Cells[i * 2 + 1].InsertParagraph()
                                .Append(index >= 0 && index < questionLists[i][j].QuestionContent.Letters.Length ? questionLists[i][j].QuestionContent.Letters[index].ToString() : "*");
                        }
                    }
                }
                docXdocument.InsertTable(table);
                paragraph = docXdocument.InsertParagraph();
                paragraph.Append($"{Environment.NewLine}{Environment.NewLine}Балл: ")
                    .Bold()
                    .Alignment = Alignment.right;
                if (!markAnswers)
                {
                    paragraph.Append("\t\t")
                    .UnderlineStyle(UnderlineStyle.singleLine)
                    .Alignment = Alignment.right;
                }
                else
                {
                    paragraph.Append($"{ticket.MaxPoints:F2}")
                   .UnderlineStyle(UnderlineStyle.singleLine)
                   .Alignment = Alignment.right;
                }
                docXdocument.Footers.Odd.InsertParagraph()
                      .Append("Створено за допомогою SimplEx Program")
                      .FontSize(10)
                      .UnderlineStyle(UnderlineStyle.singleLine)
                      .Alignment = Xceed.Document.NET.Alignment.right;
                docXdocument.Save();
            }
            OpenWord();
        }
        public void OpenResult(Exam exam, ExecutionResult executionResult)
        {
            CloseWord();
            Ticket ticket = executionResult.Ticket;
            using (DocX docXdocument = DocX.Create(path.ToString()))
            {
                int i, j;
                docXdocument.AddFooters();
                docXdocument.SetDefaultFont(new Xceed.Document.NET.Font("Times New Roman"), 14);
                Xceed.Document.NET.Paragraph headerParagraph = docXdocument.InsertParagraph();
                Xceed.Document.NET.Paragraph paragraph = docXdocument.InsertParagraph();
                headerParagraph.Append($"Виконання завдань")
                   .Bold()
                   .FontSize(16);
                paragraph = docXdocument.InsertParagraph();
                paragraph.Append($"Здобувач освіти")
                    .FontSize(14)
                    .Bold()
                    .Append($"  {executionResult.ExecutorSurname} {executionResult.ExecutorName} {executionResult.ExecutorPatronymic}  ")
                    .UnderlineStyle(UnderlineStyle.singleLine)
                    .Append("білет №")
                    .Bold()
                    .Append($"{ticket.TicketName}")
                    .UnderlineStyle(UnderlineStyle.singleLine);
                paragraph = docXdocument.InsertParagraph();
                paragraph.Append($"{Environment.NewLine}I частина")
                    .Bold()
                    .Alignment = Alignment.center;
                paragraph = docXdocument.InsertParagraph();
                paragraph.Append($"\tОзнайомтесь з тестовим завданням. Дайте відповіді на тестові завдання в таблиці" +
                    $"(поряд із номером запитання зазначте номер правильної відповіді){Environment.NewLine}")
                    .Alignment = Alignment.left;
                List<OneAnswerQuestion[]> questionLists = new List<OneAnswerQuestion[]>();
                for (i = 0; i < exam.Themes.Count; i++)
                {
                    OneAnswerQuestion[] questions = exam.Themes[i].GetQuestions(ticket).Cast<OneAnswerQuestion>().ToArray();
                    Array.Sort(questions,
                    (Question a, Question b) =>
                    {
                        if (a.QuestionNumber > b.QuestionNumber)
                            return 1;
                        else if (a.QuestionNumber < b.QuestionNumber)
                            return -1;
                        return 0;
                    });
                    questionLists.Add(questions);
                }
                int max = questionLists.Max(a => a.Length);
                Xceed.Document.NET.Table table = docXdocument.AddTable(max + 1, questionLists.Count * 2);
                table.SetBorder(TableBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.Left, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                table.SetBorder(TableBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_double, BorderSize.two, 0, Color.Black));
                List<float> percentages = new List<float>();
                float pa = 30 / (table.ColumnCount / 2);
                float pb = 70 / (table.ColumnCount / 2);
                for (i = 0; i < table.ColumnCount / 2; i += 2)
                {
                    table.Rows[0].MergeCells(i, i + 1);
                    percentages.Add(pa);
                    percentages.Add(pb);
                    i--;
                }
                table.SetWidthsPercentage(percentages.ToArray(), docXdocument.PageWidth - docXdocument.PageWidth / 5);
                for (i = 0; i < exam.Themes.Count; i++)
                    table.Rows[0].Cells[i].InsertParagraph()
                        .Append(exam.Themes[i].ThemeName)
                        .Alignment = Alignment.center;
                for (i = 0; i < table.ColumnCount / 2; i ++)
                {
                    for (j = 0; j < questionLists[i].Length; j++)
                    {
                        table.Rows[1 + j].Cells[i * 2].InsertParagraph()
                              .Append($"{questionLists[i][j].QuestionNumber + exam.FirstQuestionNumber}");
                        ExecutorAnswer[] answers = executionResult.Answers.Where(a => a.Question.QuestionNumber == questionLists[i][j].QuestionNumber).ToArray();
                        if (answers.Length > 0)
                        {
                            int index = questionLists[i][j].QuestionContent.Answers.IndexOf(answers[0].Content);
                            table.Rows[1 + j].Cells[i * 2 + 1].InsertParagraph()
                                .Append(index >= 0 && index < questionLists[i][j].QuestionContent.Letters.Length ? questionLists[i][j].QuestionContent.Letters[index].ToString() : "*");
                        }
                    }
                }
                docXdocument.InsertTable(table);
                paragraph = docXdocument.InsertParagraph();
                paragraph.Append($"{Environment.NewLine}{Environment.NewLine}Балл: ")
                    .FontSize(14)
                    .Bold()
                    .Append($"{executionResult.Points:F2}")
                    .FontSize(14)
                    .UnderlineStyle(UnderlineStyle.singleLine)
                    .Alignment = Alignment.right;
                docXdocument.Footers.Odd.InsertParagraph()
                      .Append("Створено за допомогою SimplEx Program")
                      .FontSize(10)
                      .UnderlineStyle(UnderlineStyle.singleLine)
                      .Alignment = Xceed.Document.NET.Alignment.right;
                docXdocument.Save();
            }
            OpenWord();
        }
        private void CloseWord()
        {
            if (application != null)
            {
                document.Close(ref falseObj, ref missingObj, ref missingObj);
                application.Quit(ref missingObj, ref missingObj, ref missingObj);
                document = null;
                application = null;
            }
        }
        private void OpenWord()
        {
            _Application application = new Application();
            _Document document = new Microsoft.Office.Interop.Word.Document();
            try
            {
                document = application.Documents.Add(ref path, ref missingObj, ref missingObj, ref missingObj);
            }
            catch
            {
                document.Close(ref falseObj, ref missingObj, ref missingObj);
                application.Quit(ref missingObj, ref missingObj, ref missingObj);
                document = null;
                application = null;
                throw;
            }
            application.Visible = true;
        }
    }
}
