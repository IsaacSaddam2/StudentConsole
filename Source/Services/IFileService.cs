namespace Grade.Promoter.Services
{
    using System.Collections.Generic;
    using Grade.Promoter.Models;
    using Grade.Promoter.ViewModels;

    public interface IFileService
    {
        List<ExamResult> ParseExamResultsFromCsv(string filepath);

        string WritePromotionResults(List<Pupil> pupils, string outputPath);
    }
}