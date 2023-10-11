using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using Lab5;
using System.Runtime.Remoting.Channels;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            bool confirmation = false; // the validation for the while loop

            while (!confirmation)
            {
                Console.WriteLine("Choose a language between the following: 'en' for english or 'fr' for french ");
                String lang = Console.ReadLine();

                switch (lang.ToUpper())
                {
                    case "EN":
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-CA");
                        confirmation = true; // Set confirmation to true to exit the loop
                        break;
                    case "FR":
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-CA");
                        confirmation = true; // Set confirmation to true to exit the loop
                        break;
                    default:
                        Console.WriteLine("This is not a valid language. Please try again.");
                        confirmation= false;
                        break;
                }
            }

            try
            {
                bool validation = false; // Initialize to false initially
                while (!validation)
                {
                    Console.WriteLine(Lab5.Properties.strings.Options);
                    
                    String option = Console.ReadLine() ?? throw new Exception("String is empty");

                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine(Lab5.Properties.strings.OptionF);
                            ExecuteScrambledWordsInFileScenario();
                            validation = true; 
                            break;
                        case "M":
                            Console.WriteLine(Lab5.Properties.strings.OptionM);
                            ExecuteScrambledWordsManualEntryScenario();
                            validation = true; 
                            break;
                        default:
                            Console.WriteLine(Lab5.Properties.strings.FalseOption);
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
                bool fileValidation = false;
                while (!fileValidation)
                {
                    if (!fileValidation)
                    {
                        var filename = Console.ReadLine();
                      
                      

                        string[] target;
                        string[] word;
                        bool readSuccess = _fileReader.Read(filename, out target);
                        while(!(readSuccess))
                        {
                            Console.WriteLine(Lab5.Properties.strings.NotFoundFile);
                            Console.WriteLine(Lab5.Properties.strings.ReenterFiles);
                            filename = Console.ReadLine();
                            readSuccess = _fileReader.Read(filename, out target);
                        }

                        
                        Lab5.Properties.strings.OptionF2.AskUser();  // extenstion method 
                        var filematch = Console.ReadLine();
                        bool readSuccess2 = _fileReader.Read(filematch, out word);
                        while (!(readSuccess2))
                        {

                            Console.WriteLine(Lab5.Properties.strings.NotFoundFile);
                            Lab5.Properties.strings.OptionF2.AskUser();
                            filematch = Console.ReadLine();


                            
                            readSuccess2 = _fileReader.Read(filematch, out word);
                        }
                        WordMatcher wordMatcher = new WordMatcher();
                        wordMatcher.Match(target, word);
                        DisplayMatchedUnscrambledWords(target, word);

                        Console.WriteLine(Lab5.Properties.strings.Redo);
                        String answer2 = Console.ReadLine();

                        if (answer2 == "y")
                        {
                            fileValidation = false;
                            Console.WriteLine(Lab5.Properties.strings.OptionF);

                        }
                    
                    else 
                    {

                        Environment.Exit(0);

                    }
                  }

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
                bool manualValidation = false;
                while (!manualValidation) {
                    if (!manualValidation)
                    {

                        string input = Console.ReadLine();
                        while(input== string.Empty) {
                            Console.WriteLine(Lab5.Properties.strings.emptyString);
                            input = Console.ReadLine();
                        }
                        Console.WriteLine(Lab5.Properties.strings.WordsToMatch + input.ToString());
                        Console.WriteLine(Lab5.Properties.strings.Continuation);
                        string answer = Console.ReadLine();

                        while (answer == "n")
                        {
                            Console.WriteLine(Lab5.Properties.strings.ReenterWords);
                            input = Console.ReadLine();
                            Console.WriteLine(Lab5.Properties.strings.Continuation);
                            answer = Console.ReadLine();

                        }
                        Console.WriteLine(Lab5.Properties.strings.OptionM2);
                        string matched = Console.ReadLine();
                        while (matched == string.Empty)
                        {
                            Console.WriteLine(Lab5.Properties.strings.emptyString);
                            matched = Console.ReadLine();
                        }

                        string[] inputWords = input.Split(',');
                        string[] matchedArray = matched.Split(',');

                        WordMatcher wordMatcher = new WordMatcher();
                        wordMatcher.Match(inputWords, matchedArray);
                        DisplayMatchedUnscrambledWords(inputWords, matchedArray);

                        Console.WriteLine(Lab5.Properties.strings.Redo);
                        String answer2 = Console.ReadLine();

                        if (answer2 == "y")
                        {
                            manualValidation = false;
                            Console.WriteLine(Lab5.Properties.strings.OptionM);
                        }


                        else
                        {
                            Environment.Exit(0);

                        }
                    }

                }

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

            foreach (MatchedWord matchedWord in matchedWords)
            {
                Console.WriteLine(Lab5.Properties.strings.ScrambledWord + matchedWord.ScrambledWord);
                Console.WriteLine(Lab5.Properties.strings.MatchedWord + matchedWord.Word);
                Console.WriteLine(Lab5.Properties.strings.IsMatch +  matchedWord.IsMatch);
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
