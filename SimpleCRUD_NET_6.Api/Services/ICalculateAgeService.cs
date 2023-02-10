namespace SimpleCRUD_NET_6.Api.Services
{
    public interface ICalculateAgeService
    {

        int CalculateAge(DateTime dateOfBirth);

    }

    public class CalculateAgeService : ICalculateAgeService
    {

        public CalculateAgeService()
        {

        }

        public int CalculateAge(DateTime dateOfBirth)
        {

            int years = DateTime.Now.Year - dateOfBirth.Year;

            dateOfBirth = dateOfBirth.AddYears(years);

            if (dateOfBirth.Date > DateTime.Now.Date)
                years--;
            return years;

        }

    }
}
