using System;
using System.Text;

namespace VirinMockServices
{

    public class VirinGenerator
    {
        int _howManyToCreate;

        /// <summary>
        /// Creates a random VIRIN string
        /// </summary>
        /// <returns>Random VIRIN string</returns>
        public string CreateVirin()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();

            // Generate date in format yyMMdd
            builder.Append(GenerateDate());

            // Generate the service affiliation or status of the acquirer or originator; a single character from "AFMNGDOHSXZ"
            builder.Append('-');
            builder.Append(GenerateCharacter("AFMNGDOHSXZ"));

            // Generate VISION ID
            builder.Append('-');
            builder.Append(GenerateAlphanumeric(5));

            // Generate indicators for the sequence of scenes, locations, or assignments; five alphanumeric characters 
            builder.Append('-');
            builder.Append(GenerateDigits(3));
            if (random.Next(0, 2) == 1) // 50% chance of an extra digit
            {
                builder.Append(GenerateDigits(1));
            }

            // Generate optional letter (unkown purpose)
            if (random.Next(0, 2) == 1) // 50% chance of an optional letter
            {
                builder.Append(GenerateCharacter("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"));
            }

            // Generate optional characters representing the nation the photographer (Foreign photographers only) 
            if (random.Next(0, 2) == 1) // 50% chance of optional suffix
            {
                builder.Append('-');
                builder.Append(GenerateAlphabetic(2));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Generates a random date between 10 years ago and today
        /// </summary>
        /// <returns>Date string in format yyMMdd</returns>
        private string GenerateDate()
        {            
            DateTime currentDate = DateTime.Now;
            
            DateTime startDate = currentDate.AddYears(-10);

            // Generate a random date between startDate and currentDate
            Random random = new Random();
            int daysDifference = (currentDate - startDate).Days;
            DateTime randomDate = startDate.AddDays(random.Next(daysDifference));
           
            return randomDate.ToString("yyMMdd");
        }

        /// <summary>
        /// Generate specified number of digits
        /// </summary>
        /// <param name="digitsToCreate"></param>
        /// <returns>a string of digits</returns>
        private string GenerateDigits(int digitsToCreate)
        {
            Random _random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < digitsToCreate; i++)
            {
                builder.Append(_random.Next(0, 10)); // Adds a digit from 0 to 9
            }
            return builder.ToString();
        }

        /// <summary>
        /// Generate specified number of alphanumeric characters
        /// </summary>
        /// <param name="alphanumericsToCreate"></param>
        /// <returns>string of alphanumberic characters</returns>
        private string GenerateAlphanumeric(int alphanumericsToCreate)
        {
            Random _random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < alphanumericsToCreate; i++)
            {
                builder.Append(chars[_random.Next(chars.Length)]);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Generate alphabetic characters only
        /// </summary>
        /// <param name="alphabeticsToCreate"></param>
        /// <returns>string of alphabetic only characters</returns>
        private string GenerateAlphabetic(int alphabeticsToCreate)
        {
            Random _random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < alphabeticsToCreate; i++)
            {
                builder.Append(chars[_random.Next(chars.Length)]);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Generate a single character from a given set
        /// </summary>
        /// <param name="characterSet"></param>
        /// <returns>random char</returns>
        private char GenerateCharacter(string characterSet)
        {
            Random _random = new Random();
            return characterSet[_random.Next(characterSet.Length)];
        }


    }
}
