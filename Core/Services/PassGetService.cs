using System;
using System.Threading;
using Infrastructure.Interfaces;

namespace Core.Services
{
    public class PassGetService : IPassGetService
    {
        private readonly IValidationService _validationService;
        public string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        public int MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS = 2;
        public string NUMERIC_CHARACTERS = "0123456789";
        public string SPACE_CHARACTER = " ";
        public string SPECIAL_CHARACTERS = @"!#$%&*@\";
        public string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public PassGetService()
        {
            _validationService = new ValidationService();
        }

        public void AskPassword(Random random)
        {
            var LOWERCASE_CHARACTERS = true;
            var UPPERCASE_CHARACTERS = true;
            var NUMERIC_CHARACTERS = true;
            var SPECIAL_CHARACTERS = true;
            var SPACE_CHARACTER = true;
            int lengthOfPassword;
            char input;

            do
            {
                Console.Write("Do you want lowercase characters? y/n :  ");
                input = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (input == 'y')
                {
                    LOWERCASE_CHARACTERS = true;
                }
                else if (input == 'n')
                {
                    LOWERCASE_CHARACTERS = false;
                }
                else
                {
                    Console.WriteLine("Unrecognized char, using default value: using lowercase");
                }

                Console.Write("Do you want UPPERCASE characters? y/n :  ");
                input = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (input == 'y')
                {
                    UPPERCASE_CHARACTERS = true;
                }
                else if (input == 'n')
                {
                    UPPERCASE_CHARACTERS = false;
                }
                else
                {
                    Console.WriteLine("Unrecognized char, using default value: using UPPERCASE");
                }

                Console.Write("Do you want numeric characters? y/n :  ");
                input = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (input == 'y')
                {
                    NUMERIC_CHARACTERS = true;
                }
                else if (input == 'n')
                {
                    NUMERIC_CHARACTERS = false;
                }
                else
                {
                    Console.WriteLine("Unrecognized char, using default value: using numeric");
                }

                Console.Write("Do you want special characters? y/n :  ");
                input = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (input == 'y')
                {
                    SPECIAL_CHARACTERS = true;
                }
                else if (input == 'n')
                {
                    SPECIAL_CHARACTERS = false;
                }
                else
                {
                    Console.WriteLine("Unrecognized char, using default value: using special");
                }

                Console.Write("Do you want space characters? y/n :  ");
                input = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (input == 'y')
                {
                    SPACE_CHARACTER = true;
                }
                else if (input == 'n')
                {
                    SPACE_CHARACTER = false;
                }
                else
                {
                    Console.WriteLine("Unrecognized char, using default value: using space");
                }
            } while (LOWERCASE_CHARACTERS == false && UPPERCASE_CHARACTERS == false && NUMERIC_CHARACTERS == false &&
                     SPECIAL_CHARACTERS == false && SPACE_CHARACTER == false);

            bool zupa;
            do
            {
                //How to prevent from chars or strings?
                Console.Write("How many characters, at least 8 and max 128: ");
                zupa = int.TryParse(Console.ReadLine(), out int result);

                lengthOfPassword = result;
            } while (lengthOfPassword < 8 || lengthOfPassword > 128 || !zupa);

            Console.WriteLine("Generating password");
            Thread.Sleep(1000);
            Console.WriteLine("Your password is: " +
                              GeneratePassword(LOWERCASE_CHARACTERS, UPPERCASE_CHARACTERS, NUMERIC_CHARACTERS,
                                  SPECIAL_CHARACTERS, SPACE_CHARACTER, lengthOfPassword, random));
        }

        public string GeneratePassword(bool includeLowercase, bool includeUppercase, bool includeNumeric,
            bool includeSpecial, bool includeSpaces, int lengthOfPassword, Random random)
        {
            var characterSet = "";

            if (includeLowercase)
            {
                characterSet += LOWERCASE_CHARACTERS;
            }

            if (includeUppercase)
            {
                characterSet += UPPERCASE_CHARACTERS;
            }

            if (includeNumeric)
            {
                characterSet += NUMERIC_CHARACTERS;
            }

            if (includeSpecial)
            {
                characterSet += SPECIAL_CHARACTERS;
            }

            if (includeSpaces)
            {
                characterSet += SPACE_CHARACTER;
            }

            var password = new char[lengthOfPassword];
            var characterSetLength = characterSet.Length;

            for (var characterPosition = 0; characterPosition < lengthOfPassword; characterPosition++)
            {
                password[characterPosition] = characterSet[random.Next(characterSetLength - 1)];

                var moreThanTwoIdenticalInARow =
                    _validationService.RepeatingCharsValidator(MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS, characterPosition,
                        password);

                if (moreThanTwoIdenticalInARow)
                {
                    characterPosition--;
                }
            }

            return string.Join(null, password);
        }
    }
}