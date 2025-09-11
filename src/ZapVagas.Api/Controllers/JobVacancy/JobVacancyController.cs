using Microsoft.AspNetCore.Mvc;
using ZapVagas.Application.Dtos.JobVacancy.Request;
using ZapVagas.Application.Services;

namespace ZapVagas.API.Controllers.JobVacancy
{
    public static class JobVacancyController
    {
        public static void MapJobVacancyEndpoints(this WebApplication app)
        {
            var routesJobVacancy = app.MapGroup("/api/jobvacancies");

            routesJobVacancy.MapGet("", ([FromServices] IJobVacancyService service) =>
            {
                var jobVacancies = service.GetAllAsync();

                return Results.Ok(jobVacancies);
            });

            routesJobVacancy.MapGet("{id:guid}", async (Guid id, [FromServices] IJobVacancyService service) =>
            {
                var jobVacancy = await service.GetByIdAsync(id);

                return jobVacancy is null ? Results.NotFound() : Results.Ok(jobVacancy);
            });

            routesJobVacancy.MapPost("", async (JobVacancyCreateRequest request, [FromServices] IJobVacancyService service) =>
            {
                var jobVacancy = await service.CreateAsync(request);

                return Results.Created($"/api/jobvacancies", jobVacancy);
            });

            routesJobVacancy.MapPut("{id:guid}", async (Guid id, JobVacancyUpdateRequest request, [FromServices] IJobVacancyService service) =>
            {
                var updatedJobVacancy = await service.Update(id, request);

                return updatedJobVacancy is null ? Results.NotFound() : Results.Ok(updatedJobVacancy);
            });

            routesJobVacancy.MapDelete("{id:guid}", async (Guid id, [FromServices] IJobVacancyService service) =>
            {
                bool deleted = await service.DeleteById(id);

                if (!deleted)
                    return Results.NotFound("Vaga não encontrada.");

                return Results.NoContent();
            });
        }
    }
}
