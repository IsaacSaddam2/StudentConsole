namespace Grade.Promoter.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Grade.Promoter.Models;
    using Grade.Promoter.ViewModels;

    public class PromotionService : IPromotionService
    {
        public List<Pupil> GetPromotionResults(List<ExamResult> examResults)
        {
            var pupils = examResults
                .GroupBy(x => x.PupilId)
                .Select(y => this.CheckIfPromoted(y.ToList()))
                .ToList();
            return pupils;
        }

        private Pupil CheckIfPromoted(List<ExamResult> examResults)
        {
            return new Pupil
            {
                PupilName = examResults.First().PupilName,
                Grade = examResults.First().Grade,
                PupilId = examResults.First().PupilId,
                Promoted = examResults.Average(x => x.Result) > 50,
            };
        }
    }
}
