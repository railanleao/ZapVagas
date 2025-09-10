namespace ZapVagas.Application.Dtos.Candidate.Request;
    //Adicionar jobPreference futuro
    public record CandidateCreateRequest(string name, string phone, string education, List<JobPreferenceRequest> preference);
