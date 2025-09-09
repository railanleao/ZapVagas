namespace ZapVagas.Domain.Entities
{
    public class Candidate
    {
        public Guid CandidateId { get; init; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Education { get; private set; }
        public List<JobPreference> JobPreferences { get; private set; }
        public DateTime StartDate { get; init; }

        private Candidate() { }

        public Candidate(string name, string phone, string education)
        {
            CandidateId = Guid.NewGuid();
            Name = name;
            Phone = phone;
            Education = education;
            StartDate = DateTime.Now;
        }
        public void UpdateName(string name) => Name = name;

        public void UpdatePhone(string phone) => Phone = phone;
        public void UpdateEducation(string education) => Education = education;

        public void AddJobPreference(string cargo, string location)
        {
            if (JobPreferences.Count >= 3)
                throw new InvalidOperationException("Candidato só pode ter até 3 preferência de trabalhos!");

            JobPreferences.Add(new JobPreference(CandidateId, cargo, location));
        }
        public void ClearJobPreferences() => JobPreferences.Clear();
    }
}
