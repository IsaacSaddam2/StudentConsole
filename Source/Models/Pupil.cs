namespace Grade.Promoter.Models
{
    public class Pupil
    {
        public int PupilId { get; set; }

        public string PupilName { get; set; }

        public string Grade { get; set; }

        public bool Promoted { get; set; }
    }
}