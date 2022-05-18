namespace Grade.Promoter.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using Grade.Promoter.Models;
    using Grade.Promoter.ViewModels;

    public class FileService : IFileService
    {
        public List<ExamResult> ParseExamResultsFromCsv(string filepath)
        {
            using (TextReader fileReader = File.OpenText(filepath))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
                csv.Read();
                var examResult = csv.GetRecords<ExamResult>().ToList();
                return examResult;
            }
        }

        public string WritePromotionResults(List<Pupil> pupils, string outputPath)
        {
            if (pupils == null || pupils.Count == 0)
            {
                throw new ArgumentNullException(nameof(pupils));
            }

            var path = Path.Combine(outputPath);

            using (var writer = File.CreateText(path))
            {
                var promotedPupils = pupils.Where(x => x.Promoted);
                var promotedNotPupils = pupils.Where(x => !x.Promoted);

                writer.WriteLine("Promoted:");

                foreach (var pupil in promotedPupils)
                {
                    Console.WriteLine("{0} {1}", pupil.PupilId,pupil.PupilName);
                    writer.WriteLine($"{pupil.PupilId},{pupil.PupilName}");
                }

                writer.WriteLine(string.Empty);
                writer.WriteLine("Not Promoted:");
                foreach (var pupil in promotedNotPupils)
                {
                    writer.WriteLine($"{pupil.PupilId},{pupil.PupilName}");
                }

                writer.WriteLine(string.Empty);

                return writer.ToString();
            }
        }
    }
}
