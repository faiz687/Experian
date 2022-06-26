namespace MarketPlaces.Entity.Models
{
    public class ApplicantCard
    {
        public int Id { get; set; }
        public int? ApplicantId { get; set; }
        public virtual Applicant ApplicantDetail { get; set; }
        public int? CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}