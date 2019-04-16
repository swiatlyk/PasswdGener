using Infrastructure.Interfaces;

namespace Core.Services
{
    public class ValidationService : IValidationService
    {
        //sprawdzi� pooprawno�� argument�w
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