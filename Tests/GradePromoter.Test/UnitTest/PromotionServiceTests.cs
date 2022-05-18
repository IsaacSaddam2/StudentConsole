namespace Grade.Promoter.Test.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Grade.Promoter.Services;
    using Grade.Promoter.ViewModels;
    using Shouldly;
    using Xunit;

    public class PromotionServiceTests
    {
        private readonly PromotionService promotionService;

        public PromotionServiceTests()
        {
            this.promotionService = new PromotionService();
        }

        [Fact]
        public void PupilWithGreaterThan50PercentAverage_ReturnsPromoted()
        {
            var examResults = new List<ExamResult>
            {
                new ExamResult
                {
                    PupilId = 1,
                    Grade = "Standard 1",
                    AssesmentDate = default(DateTime),
                    AssessmentType = "End-Term",
                    PupilName = "Joe Bloggs",
                    Result = 70,
                    Subject = "Verbal Reasoning",
                },
                new ExamResult
                {
                    PupilId = 1,
                    Grade = "Standard 1",
                    AssesmentDate = default(DateTime),
                    AssessmentType = "End-Term",
                    PupilName = "Joe Bloggs",
                    Result = 45,
                    Subject = "Maths",
                },
            };

            var results = this.promotionService.GetPromotionResults(examResults);
            results.Count.ShouldBe(1);
            var result = results.Single();
            result.Promoted.ShouldBeTrue();
        }

        [Fact]
        public void PupilWithLessThan50PercentAverage_ReturnsNotPromoted()
        {
            var examResults = new List<ExamResult>
            {
                new ExamResult
                {
                    PupilId = 1,
                    Grade = "Standard 1",
                    AssesmentDate = default(DateTime),
                    AssessmentType = "End-Term",
                    PupilName = "Joe Bloggs",
                    Result = 51,
                    Subject = "Maths",
                },
                new ExamResult
                {
                    PupilId = 1,
                    Grade = "Standard 1",
                    AssesmentDate = default(DateTime),
                    AssessmentType = "End-Term",
                    PupilName = "Joe Bloggs",
                    Result = 49,
                    Subject = "Verbal Reasoning",
                },
            };

            var results = this.promotionService.GetPromotionResults(examResults);
            results.Count.ShouldBe(1);
            var result = results.Single();
            result.Promoted.ShouldBeFalse();
        }
    }
}
