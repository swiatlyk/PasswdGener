using Infrastructure.DTO;
using Infrastructure.Interfaces;

namespace Core.Services
{
    public class CharacterSetGenerator : ICharacterSetGenerator
    {
        public string LowerCaseCharacters => "abcdefghijklmnopqrstuvwxyz";
        public string UpperCaseCharacters => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string NumericalCharacters => "0123456789";
        public string SpecialCharacters => @"!#$%&*@\";
        public string SpaceCharacter => " ";

        public string Generate(GeneratorConfig dto)
        {
            var result = "";

            if (dto.UseLowerCase)
            {
                result += LowerCaseCharacters;
            }

            if (dto.UseUpperCase)
            {
                result += UpperCaseCharacters;
            }

            if (dto.UseNumerical)
            {
                result += NumericalCharacters;
            }


            if (dto.UseSpecial)
            {
                result += SpecialCharacters;
            }

            if (dto.UseSpace)
            {
                result += SpaceCharacter;
            }
            return result;
        }
    }
}