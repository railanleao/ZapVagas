using System.ComponentModel.DataAnnotations;

namespace ZapVagas.Domain.Entities
{
    public class Candidate
    {
        public Guid CandidateId { get; init; }
        public string Name { get; private set; }
        [Phone]
        public string Phone { get; private set; }
        public string Education { get; private set; }
        public ICollection<JobPreference> JobPreferences { get; private set; }
        public DateTime StartDate { get; init; }

        private Candidate() { }

        public Candidate(string name, string phone, string education)
        {
            CandidateId = Guid.NewGuid();
            Name = name;
            Phone = phone;
            Education = education;
            StartDate = DateTime.Now;
        }
        public void UpdateName(string name)
        {
            if (!ValidationHelper.ShouldUpdate(Name, name))
                return;

            Name = name;
        }

        public void UpdatePhone(string phone)
        {
            if (!ValidationHelper.ShouldUpdate(Phone, phone))
                return;

            Phone = phone;
        }
        public void UpdateEducation(string education)
        {
            if (!ValidationHelper.ShouldUpdate(Education, education))
                return;

            Education = education;
        }

        public void AddJobPreference(string area, string location)
        {
            JobPreferences ??= new List<JobPreference>();

            if (JobPreferences.Count >= 3)
                throw new InvalidOperationException("Candidato só pode ter até 3 preferência de trabalhos!");

            JobPreferences.Add(new JobPreference(CandidateId, area, location));
        }
        public void UpdateJobPreference(Guid preferenceId, string area, string location)
        {
            var preference = JobPreferences?.FirstOrDefault(jp => jp.PreferenceId == preferenceId);

            if (preference is null)
                throw new InvalidOperationException("Preferência de trabalho não encontrada!");

            preference.UpdateArea(area);
            preference.UpdateLocation(location);
        }
        public void ClearJobPreferences() => JobPreferences.Clear();
    }

    internal static class ValidationHelper
    {
        public static bool ShouldUpdate(string currentValue, string newValue)
        {
            return !string.IsNullOrWhiteSpace(newValue) &&
                   !string.Equals(currentValue, newValue, StringComparison.OrdinalIgnoreCase);
        }
    }
}
