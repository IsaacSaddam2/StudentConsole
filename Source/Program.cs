namespace Grade.Promoter
{
    using System;
    using Grade.Promoter.Services;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        private static void Main(string[] args)
        {
            var input = "ExamResults.csv";
            var output = @"C:\Temp\Results.txt";
            Console.WriteLine($"Reading exam results data from {input}");

            // Dependency Injection
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IPromotionService, PromotionService>()
            .AddSingleton<IFileService, FileService>()
            .BuildServiceProvider();
            var fileService = serviceProvider.GetService<IFileService>();
            var promotionService = serviceProvider.GetService<IPromotionService>();

            Console.WriteLine($"Processing...");
            GradePromoter gradePromoter = new GradePromoter(fileService, promotionService);
            gradePromoter.CalculatePromotions(input, output);
            Console.WriteLine($"Complete. Promotions have been written to {output}");
            Console.ReadLine();
        }
    }
}
