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

            Console.WriteLine("Choose a language between the following: en for english or fr for french ");
            String lang = Console.ReadLine();

            if (lang.Equals("en"))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-CA");
            }
            if (lang.Equals("fr"))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-CA");
            }
            else
            {
                Console.WriteLine("This is not a valid language. Please try again.");
                Environment.Exit(0);
            }

            try
            {
                bool validation = false; // Initialize to false initially
                while (!validation)
                {
                    Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");
                    
                    String option = Console.ReadLine() ?? throw new Exception("String is empty");

                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine("Enter full path including the file name: ");
                            ExecuteScrambledWordsInFileScenario();
                            validation = true; 
                            break;
                        case "M":
                            Console.WriteLine("Enter word(s) manually (separated by commas if multiple): ");
                            ExecuteScrambledWordsManualEntryScenario();
                            validation = true; 
                            break;
                        default:
                            Console.WriteLine("The entered option was not recognized.");
                            validation = false;
                     
                            break;
                    }
                    


                    Console.ReadLine();
                }
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
                "Enter a file to try the matching: ".AskUser();
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
                    DisplayMatchedUnscrambledWords(target, word);
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
                DisplayMatchedUnscrambledWords(inputWords, matchedArray);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing manual input: " + ex.Message);
            }

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords, string[] wordList)
        {
            WordMatcher wordMatcher = new WordMatcher();
            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            Console.WriteLine("Matched Words:");

            foreach (MatchedWord matchedWord in matchedWords)
            {
                Console.WriteLine($"Scrambled Word: {matchedWord.ScrambledWord}");
                Console.WriteLine($"Matched Word: {matchedWord.Word}");
                Console.WriteLine($"Is Match: {matchedWord.IsMatch}");
                Console.WriteLine();
            }



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
