namespace Grade.Promoter.ViewModels
{
    using System;

    public class ExamResult
    {
        public int PupilId { get; set; }

        public string PupilName { get; set; }

        public string Subject { get; set; }

        public string AssessmentType { get; set; }

        public string Grade { get; set; }

        public int Result { get; set; }

        public DateTime AssesmentDate { get; set; }
    }
}