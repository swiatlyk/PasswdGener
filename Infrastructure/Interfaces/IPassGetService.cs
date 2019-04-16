using System;

namespace Infrastructure.Interfaces
{
    public interface IPassGetService
    {
        void AskPassword(Random random);

        string GeneratePassword(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial,
            bool includeSpaces, int lengthOfPassword, Random random);
    }
}