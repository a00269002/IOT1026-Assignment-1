namespace Assignment
{
    public static class ArrayReplicator
    {
        /// <summary>
        /// Replicates (deep copies) the incoming array
        /// </summary>
        /// <param name="original">The array to be replicated</param>
        /// <returns>A deep copy of the original array</returns>
        public static int[] ReplicateArray(int[] original)
        {
            int[] result = new int[original.Length];
            for (int item = 0; item < original.Length; item++)
            {
                result[item] = original[item];
            }
            return result;
        }

        /// <summary>
        /// Asks the user for a number. Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumber(string text)
        {
            int userInput = 0;
            bool validInput = false;
            //Do-while loop to ensure that the user input is valid, and also catch the exception
            do
            {
                try
                {
                    Console.Write(text);
                    userInput = Convert.ToInt32(Console.ReadLine());
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input...Enter a valid number");
                }
            }
            while (!validInput);
            return userInput;
        }

        /// <summary>
        /// Asks the user for a number within a certain range [min, max]. If the number is not in the range, re-prompt the user for a new number.
        /// Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <param name="min">Smallest permissible value</param>
        /// <param name="max">Largest permissible value</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumberInRange(string text, int min, int max)
        {
            int userInput = 0;
            bool validInput = false;
            //Do-while loop to ensure that the input is inside the defined range, also catch the exception    
            do
            {
                try
                {
                    Console.Write(text);
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (min <= userInput && userInput <= max)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"{userInput} is not in the specific range. Try again");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input...Enter a valid number");
                }
            }
            while (!validInput);
            return userInput;
        }
    }

    static class Program
    {
        static void Main()
        {
            const int Min = 0;
            const int Max = 10;
            const int PrintOffset = 4;

            int size = ArrayReplicator.AskForNumberInRange("Enter the array size: ", Min, Max);
            int[] original = new int[size];

            // Fill the original array with user specified integers
            for (int item = 0; item < size; ++item)
            {
                original[item] = ArrayReplicator.AskForNumber("Enter a number: ");
            }

            int[] copy = ArrayReplicator.ReplicateArray(original);
            // Verify original and replicated array are the same
            for (int index = 0; index < size; ++index)
                Console.WriteLine($"Original {original[index],-PrintOffset}  {copy[index],4} Copy");
        }
    }
}
