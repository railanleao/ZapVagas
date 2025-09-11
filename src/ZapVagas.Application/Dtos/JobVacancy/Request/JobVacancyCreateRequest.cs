namespace ZapVagas.Application.Dtos.JobVacancy.Request;
public record JobVacancyCreateRequest(string title, string requirement, string educationLevel, int openPosition);
