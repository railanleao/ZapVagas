using Microsoft.AspNetCore.Mvc;
using ZapVagas.Application.Dtos.Company.Request;
using ZapVagas.Application.Services;

namespace ZapVagas.API.Controllers.Company
{
    public static class CompanyController
    {
        public static void CompanyRoutes(this WebApplication app)
        {
            var routesCompany = app.MapGroup("api/companies");

            routesCompany.MapGet("{id:guid}", async (Guid id, ICompanyService service) =>
            {
                var company = await service.GetByIdAsync(id);

                return company is null ? Results.NotFound() : Results.Ok(company);
            });

            routesCompany.MapPost("", async (CompanyCreateRequest dto, [FromServices] ICompanyService service) =>
            {
                var company = await service.CreateAsync(dto);

                return Results.Created($"/api/companies", company);
            });

            routesCompany.MapPut("{id:guid}", async (Guid id, CompanyUpdateRequest dto, [FromServices] ICompanyService service) =>
            {
                var result = await service.Update(id, dto);

                return result is null ? Results.NotFound() : Results.Ok(result);
            });

            routesCompany.MapDelete("{id:guid}", async (Guid id, [FromServices] ICompanyService service) =>
            {
                bool deleted = await service.DeleteById(id);

                if(!deleted)
                    return Results.NotFound("Empresa não encontrada.");

                return Results.NoContent();
               
            });
        }
    }
}
