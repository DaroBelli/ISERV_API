using ISERV_API.Context;
using ISERV_API.Models;

namespace ISERV_API.Controllers
{
    public static class EducationalInstitutionConroller
    {
        /// <summary>
        /// Получает список EducationalInstitution отфильтрованных по country и name. Если какой-то из параметров null, то фильтрует без него.
        /// </summary>
        /// <param name="country">Название страны.</param>
        /// <param name="name">Название учебного заведения.</param>
        /// <returns></returns>
        public static List<EducationalInstitution> GetByCountryAndName(string? country, string? name)
        {
            using var db = new IservContext();

            IQueryable<EducationalInstitution> educationalInstitutions = db.EducationalInstitutions;

            if (!string.IsNullOrWhiteSpace(country))
            {
                educationalInstitutions = educationalInstitutions.Where(x => x.Country == country);
            }

            if (!string.IsNullOrEmpty(name))
            {
                educationalInstitutions = educationalInstitutions.Where(x => x.Name == name);
            }

            return [.. educationalInstitutions];
        }
    }
}
