using Microsoft.AspNetCore.Mvc;
using ZapVagas.Application.Dtos.JobPreference.Request;
using ZapVagas.Application.Services;

namespace ZapVagas.API.Controllers.JobPreference
{
    public static class JobPreferenceController
    {
        public static void JobPreferenceRoutes(this WebApplication app)
        {
            var routesPreference = app.MapGroup("api/preferences");

            routesPreference.MapGet("", async ([FromServices] IJobPreferenceService service) =>
            {
                var preferences = await service.GetAllAsync();

                return preferences.Any() ? Results.Ok(preferences) : Results.NotFound(new { error = "Não foram encontradas preferências de trabalho." });
            });

            routesPreference.MapGet("{id:guid}", async (Guid id, [FromServices] IJobPreferenceService service) =>
            {
                var preferences = await service.GetPreferencesByCandidateIdAsync(id);

                return preferences.Any() ? Results.Ok(preferences) : Results.NotFound(new { error = "Não foram encontradas preferências de trabalho para esse candidato." });
            });

            routesPreference.MapPost("{id:guid}", async (Guid id, JobPreferenceCreateRequest dto, [FromServices] IJobPreferenceService service) =>
            {
                try
                {
                    var result = await service.CreateAsync(id, dto);
                    return  Results.Created($"/api/preferences", result);
                }
                catch (InvalidOperationException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
            });

            routesPreference.MapPut("{id:guid}", (Guid id, JobPreferenceUpdateRequest request, [FromServices] IJobPreferenceService serive) =>
            {
                var preference = serive.Update(id, request);
                return preference is null ? Results.NotFound(new { error = "Preferência de trabalho não encontrada." }) : Results.Ok(preference);
            });
        }
    }
}
