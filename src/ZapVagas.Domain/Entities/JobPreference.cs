namespace ZapVagas.Domain.Entities
{
    public class JobPreference
    {
        public Guid PreferenceId { get; init; }
        public Guid CandidateId { get; init; }
        public Candidate Candidate { get; private set; }
        public string Area { get; private set; }
        public string Location { get; private set; }

        private JobPreference() { }

        public JobPreference(Guid candidateId, string area, string location)
        {
            PreferenceId = Guid.NewGuid();
            CandidateId = candidateId;
            Area = area;
            Location = location;
        }
        public void UpdateArea(string area)
        {
            if (string.IsNullOrWhiteSpace(area) || area.Equals(Area))
                return;

            Area = area;
        }

        public void UpdateLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location) || location.Equals(Location))
                return;

            Location = location;
        }
    }
}
