namespace ZapVagas.Domain.Entities
{
    public class JobPreference
    {
        public Guid PreferenceId { get; init; }
        public Guid CandidateId { get; init; }
        public Candidate Candidate { get; private set; }
        public string Cargo { get; private set; }
        public string Location { get; private set; }

        private JobPreference() { }

        public JobPreference(Guid candidateId, string cargo, string location)
        {
            PreferenceId = Guid.NewGuid();
            CandidateId = candidateId;
            Cargo = cargo;
            Location = location;
        }
    }
}
