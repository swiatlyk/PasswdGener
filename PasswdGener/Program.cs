using System;

namespace PasswdGener
{
    public static class PasswordGenerator
    {
        public static string GeneratePassword(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, int lengthOfPassword)
        {
            const int MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS = 2;
            const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
            const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMERIC_CHARACTERS = "0123456789";
            const string SPECIAL_CHARACTERS = @"!#$%&*@\";
            const string SPACE_CHARACTER = " ";
            const int PASSWORD_LENGTH_MIN = 8;
            const int PASSWORD_LENGTH_MAX = 128;

            if (lengthOfPassword < PASSWORD_LENGTH_MIN || lengthOfPassword > PASSWORD_LENGTH_MAX)
            {
                return "Password length must be between 8 and 128.";
            }

            string characterSet = "";

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

            char[] password = new char[lengthOfPassword];
            int characterSetLength = characterSet.Length;

            System.Random random = new System.Random();
            for (int characterPosition = 0; characterPosition < lengthOfPassword; characterPosition++)
            {
                password[characterPosition] = characterSet[random.Next(characterSetLength - 1)];

                bool moreThanTwoIdenticalInARow =
                    characterPosition > MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS
                    && password[characterPosition] == password[characterPosition - 1]
                    && password[characterPosition - 1] == password[characterPosition - 2];

                if (moreThanTwoIdenticalInARow)
                {
                    characterPosition--;
                }
            }

            return string.Join(null, password);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<-------          Password Generator          ------->");
            Console.WriteLine("<-------          Generates password          ------->");
            Console.WriteLine("<-------Generate password from 8 to 128 chars ------->");
            AskPassword();
            Console.ReadKey();
        }

        private static void AskPassword()
        {
            bool LOWERCASE_CHARACTERS = true;
            bool UPPERCASE_CHARACTERS = true;
            bool NUMERIC_CHARACTERS = true;
            bool SPECIAL_CHARACTERS = true;
            bool SPACE_CHARACTER = true;
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
                Console.WriteLine();
                input = char.ToLower(Console.ReadKey().KeyChar);
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
                Console.WriteLine();
                input = char.ToLower(Console.ReadKey().KeyChar);
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

            } while (LOWERCASE_CHARACTERS == false && UPPERCASE_CHARACTERS == false && NUMERIC_CHARACTERS == false && SPECIAL_CHARACTERS == false && SPACE_CHARACTER == false);

            do
            {
                Console.Write("How many characters, at least 8 and max 128: ");
                lengthOfPassword = int.Parse(Console.ReadLine());
            } while (lengthOfPassword < 8);

            Console.WriteLine("Generating password");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Your password is: " + PasswordGenerator.GeneratePassword(LOWERCASE_CHARACTERS, UPPERCASE_CHARACTERS, NUMERIC_CHARACTERS, SPECIAL_CHARACTERS, SPACE_CHARACTER, lengthOfPassword));
        }
    }
}
