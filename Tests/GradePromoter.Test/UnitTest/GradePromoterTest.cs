namespace Grade.Promoter.Test.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Grade.Promoter.Models;
    using Grade.Promoter.Services;
    using Grade.Promoter.ViewModels;
    using Moq;
    using Xunit;

    public class GradePromoterTest : IDisposable
    {
        private readonly Mock<IPromotionService> promotionsServiceMock;
        private readonly Mock<IFileService> fileServiceMock;
        private readonly GradePromoter gradePromoter;

        public GradePromoterTest()
        {
            this.promotionsServiceMock = new Mock<IPromotionService>(MockBehavior.Strict);
            this.fileServiceMock = new Mock<IFileService>(MockBehavior.Strict);
            this.gradePromoter = new GradePromoter(this.fileServiceMock.Object, this.promotionsServiceMock.Object);
        }

        [Fact]
        public void GradePromoter_Returns()
        {
            var input = "input.txt";
            var output = "output.txt";
            var grade = "grade1";
            var subject = "subject";
            var pupilName = "name";
            var examResults = new List<ExamResult>()
            {
                new ExamResult()
                {
                    Grade = grade,
                    Subject = subject,
                    PupilName = pupilName,
                },
            };
            var pupils = new List<Pupil>()
            {
                new Pupil()
                {
                    PupilId = 0,
                    PupilName = pupilName,
                    Grade = grade,
                    Promoted = false,
                },
            };

            this.fileServiceMock
                .Setup(x => x.ParseExamResultsFromCsv(It.IsAny<string>()))
                .Returns(examResults);
            this.promotionsServiceMock
                .Setup(x => x.GetPromotionResults(examResults))
                .Returns(pupils);
            this.fileServiceMock.Setup(x => x.WritePromotionResults(pupils, output))
                .Returns(string.Empty);

            this.gradePromoter.CalculatePromotions(input, output);
        }

        public void Dispose() =>

            Mock.VerifyAll(
                this.promotionsServiceMock,
                this.fileServiceMock);
    }
}
