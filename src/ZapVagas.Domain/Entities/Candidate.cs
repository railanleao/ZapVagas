namespace ZapVagas.Domain.Entities
{
    internal class Candidate
    {
        public Guid CandidateId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Education { get; set; }
        public string SenhaHaash { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
