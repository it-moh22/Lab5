﻿using System;
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
        public static void  PrintItem(List<MatchedWord> matchedWords)
        {
            Console.WriteLine("The Matched Words");
            foreach (MatchedWord matchedWord in matchedWords)
            {
                Console.WriteLine("Screamble words : "+matchedWord.ScrambledWord);
                Console.WriteLine("The matched Word : " + matchedWord.Word);
            }
        }
    }
}
