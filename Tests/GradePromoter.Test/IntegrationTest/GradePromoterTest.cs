namespace Grade.Promoter.IntegrationTest
{
    using System.IO;
    using System.Threading.Tasks;
    using Grade.Promoter.Services;
    using Shouldly;
    using Xunit;

    public class GradePromoterTest
    {
        [Fact]
        public async Task GradePromoter_ProducesExpectedOutput()
        {
            var outfile = @"Output.txt";
            var gradePromoter = new GradePromoter(new FileService(), new PromotionService());
            var input = Path.Combine("IntegrationTest", "ExamResults.csv");
            gradePromoter.CalculatePromotions(input, outfile);

            var output = await File.ReadAllLinesAsync(outfile);
            output.Length.ShouldBe(13);
            output[0].ShouldBe("Promoted:");
            output[1].ShouldBe("9,Semaj Lawson");
            output[2].ShouldBe("8,Aedan Weaver");
            output[3].ShouldBe("2,Cierra Hendrix");
            output[4].ShouldBe("5,Thaddeus Fitzpatrick");
            output[5].ShouldBe("7,Francis Knight");
            output[6].ShouldBe("6,Roderick Morales");
            output[7].ShouldBe("1,Gisselle Haley");
            output[8].ShouldBe("4,Elise Larsen");
            output[9].ShouldBe(string.Empty);
            output[10].ShouldBe("Not Promoted:");
            output[11].ShouldBe("3,Jon Rojas");
        }
    }
}
