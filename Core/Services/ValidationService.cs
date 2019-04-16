using Infrastructure.Interfaces;

namespace Core.Services
{
    public class ValidationService : IValidationService
    {
        //sprawdziæ pooprawnoœæ argumentów
        public bool RepeatingCharsValidator(int zupa, int characterPosition, char[] password)
        {
            var moreThanTwoIdenticalInARow =
                characterPosition > zupa
                && password[characterPosition] == password[characterPosition - 1]
                && password[characterPosition - 1] == password[characterPosition - 2];
            return moreThanTwoIdenticalInARow;
        }
    }
}