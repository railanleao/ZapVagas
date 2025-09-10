using Microsoft.AspNetCore.Mvc;
using ZapVagas.Application.Dtos.Candidate.Request;
using ZapVagas.Application.Services;

namespace ZapVagas.API.Controllers.Candidate
{
    public static class CandidateController
    {
        public static void CandidateRoutes(this WebApplication app)
        {
            var routesCandidate = app.MapGroup("api/candidates");

            routesCandidate.MapGet("{id:guid}", async (Guid id, ICandidateService service) =>
            {
                var result = await service.GetByIdAsync(id);
                return result is null ? Results.NotFound() : Results.Ok(result);
            });

            routesCandidate.MapPost("", async (CandidateCreateRequest dto, [FromServices] ICandidateService service) =>
            {
                var candidate = await service.CreateAsync(dto);

                return Results.Created($"/api/candidates", candidate);
            });

            routesCandidate.MapPut("{id:guid}", async (Guid id, CandidateUpdateRequest dto, [FromServices] ICandidateService service) =>
            {
                var result = await service.Update(id, dto);
                return result is null ? Results.NotFound() : Results.Ok(result);
            });

            routesCandidate.MapDelete("{id:guid}", async (Guid id, [FromServices] ICandidateService service) =>
            {
                bool deleted = await service.DeleteById(id);

                if(!deleted)
                    return Results.NotFound("Usuário não encontrado.");

                return Results.NoContent();
               
            });
        }
    }
}
