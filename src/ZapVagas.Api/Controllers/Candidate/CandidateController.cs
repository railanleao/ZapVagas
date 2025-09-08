using ZapVagas.Application.Dtos.Candidate.Request;

namespace ZapVagas.API.Controllers.Candidate
{
    public static class CandidateController
    {
        public static void CandidateRoutes(this WebApplication app)
        {
            var routesCandidate = app.MapGroup("api/candidate");

            routesCandidate.MapGet("", (CandidateCreateDto request) =>
            {

            });
        }
    }
}
