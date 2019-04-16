namespace Infrastructure.Interfaces
{
    public interface IValidationService
    {
        bool RepeatingCharsValidator(int zupa, int characterPosition, char[] password);
    }
}