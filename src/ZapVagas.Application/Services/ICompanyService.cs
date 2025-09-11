using ZapVagas.Application.Dtos.Company.Request;
using ZapVagas.Application.Dtos.Company.Response;

namespace ZapVagas.Application.Services
{
    public interface ICompanyService 
    {
        Task<IEnumerable<CompanyResponse>> GetAllAsync();
        Task<CompanyResponse> CreateAsync(CompanyCreateRequest request);
        Task<CompanyResponse> Update(Guid id, CompanyUpdateRequest request);
        Task<CompanyResponse> GetByIdAsync(Guid id);
        Task<bool> DeleteById(Guid id);
    }
}
