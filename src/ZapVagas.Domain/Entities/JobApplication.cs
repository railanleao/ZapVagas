using ZapVagas.Domain.Enums;

namespace ZapVagas.Domain.Entities
{
    public class JobApplication
    {
        public Guid ApplicationId { get; init; }
        public Guid CandidateId { get; init; }
        public Candidate Candidate { get; init; }
        public Guid VacancyId { get; init; }
        public JobVacancy Vacancy { get; init; }
        public DateTime ApplicationDate { get; init; }
        public JobApplicationStatus Status { get; private set; }

        private JobApplication() { }

        public JobApplication(Guid candidateId, Guid vacancyId)
        {
            ApplicationId = Guid.NewGuid();
            CandidateId = candidateId;
            VacancyId = vacancyId;
            ApplicationDate = DateTime.Now;
            Status = JobApplicationStatus.Pending;

        }
    }
}