using ZapVagas.Domain.Enums;

namespace ZapVagas.Domain.Entities
{
    public class JobVacancy
    {
        public Guid VacancyId { get; init; }
        public Guid CompanyId { get; init; }
        public Company Company { get; init; }
        public string Title { get; private set; }
        public string Requirement { get; private set; }
        public string EducationLevel { get; private set; }
        public int OpenPosition { get; private set; }
        public JobVacancyStatus Status { get; private set; }
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; private set; }

        private JobVacancy() { }

        public JobVacancy(Guid companyId, string title, string requirement, string educationLevel, int openPosition)
        {
            VacancyId = Guid.NewGuid();
            CompanyId = companyId;
            Title = title;
            Requirement = requirement;
            EducationLevel = educationLevel;
            OpenPosition = openPosition;
            Status = JobVacancyStatus.Active;
            StartDate = DateTime.Now;
        }

        public void UpdateName(string title)
        {
            if (string.IsNullOrEmpty(title) || title.Equals(Title))
                return;
            
            Title = title;
        }

        public void UpdateRequirement(string requirement)
        {
            if (string.IsNullOrEmpty(requirement) || requirement.Equals(Requirement))
                return;
            Requirement = requirement;
        }

        public void UpdateEducationLevel(string educationLevel)
        {
            if (string.IsNullOrEmpty(educationLevel) || educationLevel.Equals(EducationLevel))
                return;
            EducationLevel = educationLevel;
        }

        public void UpdateOpenPosition(int openPosition)
        {
            if (openPosition <= 0)
                throw new InvalidOperationException("Minímo 1 vaga por função!");

            if (openPosition == OpenPosition)
                return;

            OpenPosition = openPosition;
        }

        public void Cancel()
        {
            EndDate = DateTime.Now;
            Status = JobVacancyStatus.Canceled;
        }

        public void Finish()
        {
            EndDate = DateTime.Now;
            Status = JobVacancyStatus.Finished;
        }
    }
}
