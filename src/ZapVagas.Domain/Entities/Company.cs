using System.ComponentModel.DataAnnotations;

namespace ZapVagas.Domain.Entities
{
    public class Company
    {
        public Guid CompanyId { get; init; }
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        [EmailAddress]
        public string Email { get; private set; }
        [Phone]
        public string Phone { get; private set; }
        public ICollection<JobVacancy> Vacancies { get; private set; }
        public DateTime StartDate { get; init; }

        private Company() { }

        public Company(string name, string cnpj, string email, string phone)
        {
            CompanyId = Guid.NewGuid();
            Name = name;
            Cnpj = cnpj;
            Email = email;
            Phone = phone;
            StartDate = DateTime.Now;
        }

        public void UpdateName(string name)
        {
            if (!ValidationHelper.ShouldUpdate(Name, name)) return;

            Name = name;
        }

        public void UpdatePhone(string phone)
        {
            if (!ValidationHelper.ShouldUpdate(Phone, phone)) return;

            Phone = phone;
        }

        public void UpdateEmail(string email)
        {
            if(!ValidationHelper.ShouldUpdate(Email, email)) return;

            Email = email;
        }

        public void AddJobVacancy(string title, string requirement, string education, int openPosition)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new InvalidOperationException("Função é obrigatória!");

            if (string.IsNullOrWhiteSpace(requirement))
                throw new InvalidOperationException("Requisitos são necessários!");

            if (string.IsNullOrWhiteSpace(education))
                throw new InvalidOperationException("Nível de escolaridade é obrigatório!");

            if (openPosition <= 0)
                throw new InvalidOperationException("Minímo 1 vaga por função!");
            Vacancies.Add(new JobVacancy(CompanyId, title, requirement, education, openPosition));
        }

        public void UpdateJobVacancy(Guid vacancyId, string title, string requirement, string education, int openPosition)
        {
            var vacancy = Vacancies?.FirstOrDefault(jv => jv.VacancyId == vacancyId);

            if (vacancy == null)
                throw new InvalidOperationException("Vaga não encontrada!");


        }
    }
}
