using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using Lab5;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");

                String option = Console.ReadLine() ?? throw new Exception("String is empty");

                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter full path including the file name: ");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        Console.WriteLine("Enter word(s) manually (separated by commas if multiple): ");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine("The entered option was not recognized.");
                        break;
                }

                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine("The program will be terminated." + ex.Message);

            }
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            try
            {
                var filename = Console.ReadLine();
                Console.WriteLine("enter the name of the file where to find the matching word" );
                var filematch = Console.ReadLine();

                string[] target;
                string[] word;
                bool readSuccess = _fileReader.Read(filename, out target);
                bool readSuccess2= _fileReader.Read(filematch, out word);

                if (readSuccess && readSuccess2)
                {
                    //DisplayMatchedUnscrambledWords(target, word);
                    WordMatcher wordMatcher = new WordMatcher();
                    wordMatcher.Match(target, word);
                }
                else
                {
                    Console.WriteLine("Unable to read the specified file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            try
            {
   
                string input = Console.ReadLine();
                Console.WriteLine("Enter a matching word: ");
                string matched = Console.ReadLine();

                string[] inputWords = input.Split(',');
                string[] matchedArray = matched.Split(); 

               
                 WordMatcher wordMatcher = new WordMatcher();
                 wordMatcher.Match(inputWords,matchedArray);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing manual input: " + ex.Message);
            }

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            // Call the extension method to display matched words
            matchedWords.PrintMatchedWords();
        }


        /*private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)

        {
            string[] wordList;
            bool readSuccess = _fileReader.Read("words.txt", out wordList);

            if (readSuccess)
            {
                List<MatchedWord> matchedWord = _wordMatcher.Match(scrambledWords, wordList);

                // Extension method to display
                Ext_PrintMehod.PrintMatchedWords(matchedWord);
            }
            else
            {
                Console.WriteLine("Unable to read the word list file.");
            }

        }*/
    }
}
