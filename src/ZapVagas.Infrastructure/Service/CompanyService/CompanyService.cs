using ZapVagas.Application.Dtos.Company.Request;
using ZapVagas.Application.Dtos.Company.Response;
using ZapVagas.Application.IUnitOfWork;
using ZapVagas.Application.Services;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Infrastructure.Service.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;

        public CompanyService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IEnumerable<CompanyResponse>> GetAllAsync()
        {
            var companies = await _uow.Companies.GetAllAsync();

            if (companies is null) return Enumerable.Empty<CompanyResponse>();

            return companies.Select(company => new CompanyResponse
            {
                Name = company.Name,
                Cnpj = company.Cnpj,
                Email = company.Email,
                Phone = company.Phone
            });
        }

        public async Task<CompanyResponse> CreateAsync(CompanyCreateRequest request)
        {
            var company = new Company(request.name, request.cnpj, request.email, request.phone);

            //foreach (var vacancy in request.vacancies)
            //    company.AddJobVacancy(vacancy.title, vacancy.requirement, vacancy.educationLevel, vacancy.openPosition);

            _uow.Companies.AddAsync(company);
            _uow.CommitAsync();

            return new CompanyResponse
            {
                Name = company.Name,
                Cnpj = company.Cnpj,
                Email = company.Email,
                Phone = company.Phone
            };
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var company = await _uow.Companies.GetByIdAsync(id);
            if (company is null) return false;

            _uow.Companies.Delete(company);

            await _uow.CommitAsync();

            return true;
        }

        public async Task<CompanyResponse> GetByIdAsync(Guid id)
        {
            var company = await _uow.Companies.GetByIdAsync(id);

            if (company is null) return null;

            return new CompanyResponse
            {
                Name = company.Name,
                Cnpj = company.Cnpj,
                Email = company.Email,
                Phone = company.Phone
            };
        }

        public async Task<CompanyResponse> Update(Guid id, CompanyUpdateRequest request)
        {
            var company = await _uow.Companies.GetByIdAsync(id);

            if(company is null) return null;

            company.UpdateName(request.name);
            company.UpdateEmail(request.email);
            company.UpdatePhone(request.phone);

            await _uow.CommitAsync();
            return new CompanyResponse
            {
                Name = company.Name,
                Cnpj = company.Cnpj,
                Email = company.Email,
                Phone = company.Phone
            };
        }
    }
}
