﻿using System;

namespace SimplExServer.View
{
    public interface IEditPropertiesView : IIntegrableView
    {
        string ExamName { get; set; }
        string Discipline { get; set; }
        string Password { get; set; }
        string RepeatPassword { get; set; }
        string CreatorName { get; set; }
        string CreatorSurname { get; set; }
        string CreatorPatronimyc { get; set; }
        double ExaminationTime { get; set; }
        int FirstNumber { get; set; }
        string Description { get; set; }
        bool Saved { get; set; }

        void MessageWrongExamName(string reason);
        void MessageWrongDiscipline(string reason);
        void MessageWrongCreatorName(string reason);
        void MessageWrongCreatorSurname(string reason);
        void MessageWrongCreatorPatronimyc(string reason);
        void MessageWrongPassword(string reason);
        void MessageWrongRepeat(string reason);
        event ViewActionHandler<IEditPropertiesView> SaveChanges;
        event ViewActionHandler<IEditPropertiesView> CancelChanges;
        event ViewActionHandler<IEditPropertiesView> Changed;
    }
}