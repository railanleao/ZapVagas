using ZapVagas.API.Controllers.Candidate;
using ZapVagas.Application.IRepository;
using ZapVagas.Application.IUnitOfWork;
using ZapVagas.Application.Services;
using ZapVagas.Infrastructure.DataContext;
using ZapVagas.Infrastructure.Repository;
using ZapVagas.Infrastructure.Service.CandidateService;
using ZapVagas.Infrastructure.UoW;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ZapVagasDbContext>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Routes
app.CandidateRoutes();

app.Run();
