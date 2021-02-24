using System;

namespace HW._07.Task2
{
    class Program
    {
        static void MaxWordReplace(string line)
        {
            int indexOfMaxLengthWord = 0, lengthOfMaxWord = 0;

            string[] wordsArray = line.Split(' ');
            for (int i = 0; i<wordsArray.Length; i++)
            {
                if (wordsArray[i].Length > lengthOfMaxWord)
                {
                    indexOfMaxLengthWord = i;
                    lengthOfMaxWord = wordsArray[i].Length;
                }
            }
            string[] wordsArrayWthoutMaxValue = Array.FindAll(wordsArray, word => word != wordsArray[indexOfMaxLengthWord]);
            string lineWithoutMaxValue = String.Join(' ',wordsArrayWthoutMaxValue);

            Console.WriteLine(lineWithoutMaxValue + "\n");
        }

        static void MaxMinWordsChange(string line)
        {
            int indexOfMaxLengthWord = 0, indexOfMinLengthWord = 0, lengthOfMaxWord = 0, lengthOfMinWord = 0;
            
            string[] wordsArray = line.Split(' ');
            lengthOfMinWord = wordsArray[0].Length;
            for (int i = 0; i < wordsArray.Length; i++)
            {
                switch (wordsArray[i])
                {
                    case string word when word.Length < lengthOfMinWord:
                        lengthOfMinWord = word.Length;
                        indexOfMinLengthWord = i;
                        break;
                    case string word when word.Length > lengthOfMaxWord:
                        lengthOfMaxWord = word.Length;
                        indexOfMaxLengthWord = i;
                        break;
                }
            }
            string wordStorage = wordsArray[indexOfMinLengthWord];
            wordsArray[indexOfMinLengthWord] = wordsArray[indexOfMaxLengthWord];
            wordsArray[indexOfMaxLengthWord] = wordStorage;
            string lineWithChangedWords = String.Join(' ', wordsArray);

            Console.WriteLine(lineWithChangedWords + "\n");
        }

        static void LettersAndPunctuatorCount(string line)
        {
            int punctuatorCounter = 0, letterCounter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case char symbol when symbol >= 'a' && symbol <= 'z':
                        letterCounter++;
                        break;
                    case char symbol when symbol >= 'A' && symbol <= 'Z':
                        letterCounter++;
                        break;
                    case char symbol when symbol >= 'а' && symbol <= 'я':
                        letterCounter++;
                        break;
                    case char symbol when symbol >= 'А' && symbol <= 'Я':
                        letterCounter++;
                        break;
                    case char symbol when symbol == '\'' || symbol == '\"' || symbol == ',' || symbol == '.'
                                          || symbol == '?' || symbol == '!' || symbol == ':' || symbol == '-'
                                          || symbol == ';' || symbol == '(' || symbol == ')':
                        punctuatorCounter++;
                        break;
                }
            }

            Console.WriteLine($"In line \"{line}\" there are {punctuatorCounter} punctuators and {letterCounter} letters of Slavic or/and Latin alphabeat\n");
        }

        static void SortArray(string line)
        {
            string[] wordsArray = line.Split(' ');
            Array.Sort(wordsArray, (x, y) => y.Length.CompareTo(x.Length));
            Console.WriteLine("\nSorted array:");
            foreach (var item in wordsArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            Console.Write($"Input string in one line with ' ' separator: ");
            string inputtedString = Console.ReadLine();
            Program.MaxWordReplace(inputtedString);
            Program.MaxMinWordsChange(inputtedString);
            Program.LettersAndPunctuatorCount(inputtedString);
            Program.SortArray(inputtedString);
        }
    }
}