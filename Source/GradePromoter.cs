namespace Grade.Promoter
{
    using System.Linq;
    using Grade.Promoter.Services;

    public class GradePromoter
    {
        private readonly IFileService fileService;
        private readonly IPromotionService promotionService;

        public GradePromoter(
          IFileService fileService,
          IPromotionService promotionService)
        {
            this.fileService = fileService;
            this.promotionService = promotionService;
        }

        public void CalculatePromotions(string input, string output)
        {
            // Read csv file and transform them into ExamResult objects
            var examResults = this.fileService.ParseExamResultsFromCsv(input);

            // Process the exam results data
            var pupils = this.promotionService.GetPromotionResults(examResults);

            // Write the promotion results to a file
            System.Console.WriteLine("result {0}",this.fileService.WritePromotionResults(pupils, output)); 
        }
    }
}