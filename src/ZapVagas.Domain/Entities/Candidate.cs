namespace ZapVagas.Domain.Entities
{
    public class Candidate
    {
        public Guid CandidateId { get; init; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Education { get; private set; }
        public DateTime StartDate { get; init; }

        private Candidate() { }

        public Candidate(Guid candidateId, string name, string phone, string education, DateTime startDate)
        {
            CandidateId = Guid.NewGuid();
            Name = name;
            Phone = phone;
            Education = education;
            StartDate = DateTime.Now;
        }
    }
}
