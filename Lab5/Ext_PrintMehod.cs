using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler;

namespace Lab5
{
    static class Ext_PrintMehod
    {
        public static void PrintMatchedWords(this List<MatchedWord> matchedWords)
        {
            Console.WriteLine("The result : ");
            foreach (MatchedWord matchedWord in matchedWords)
            {
                Console.WriteLine($"Scrambled Word: {matchedWord.ScrambledWord}");
                Console.WriteLine($"Matched Word: {matchedWord.Word}");
                Console.WriteLine($"Is Match: {matchedWord.IsMatch}");
                Console.WriteLine(); // Add an empty line for better readability
            }
            Console.WriteLine("");
            
        }

        /*public static void  PrintItem(List<MatchedWord> matchedWords)
        {
            Console.WriteLine("The Matched Words");
            foreach (MatchedWord matchedWord in matchedWords)
            {
                Console.WriteLine("Screamble words : "+matchedWord.ScrambledWord);
                Console.WriteLine("The matched Word : " + matchedWord.Word);
            }
        }*/
    }
}
