using ZapVagas.Domain.Enums;

namespace ZapVagas.Application.Dtos.JobVacancy.Response
{
    public class JobVacancyResponse
    {
        public string Title { get; set; }
        public string Requirement { get; set; }
        public string EducationLevel { get; set; }
        public int OpenPosition { get; set; }
        public JobVacancyStatus Status { get; set; }
    }
}
