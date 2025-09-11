namespace ZapVagas.Application.Dtos.JobVacancy.Request;

public record JobVacancyUpdateRequest(string title, string requirement, string educationLevel, int openPosition, string status);
