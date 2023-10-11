using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] target, string[] word)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string targets in target)
            {
                char[] targetsChar = targets.Trim().ToCharArray();
                Array.Sort(targetsChar);

                foreach (string words in word)
                {
                    char[] wordsChar = words.Trim().ToCharArray();
                    Array.Sort(wordsChar);

                    bool isMatch = targetsChar.SequenceEqual(wordsChar); //to verify if they are in the same order

                    if (isMatch)
                    {
                        // Add matched word to the list
                        matchedWords.Add(new MatchedWord
                        {
                            ScrambledWord = targets,
                            Word = words,
                            IsMatch = true
                        });
                    }
                }
            }

            return matchedWords;






            // Implement code here.
            // Work with "scrambledWords" and "matchedWords".

            MatchedWord BuildMatchedWord(string scrambledWord, string wording)
            {
                // Build a matched-word object here, so that you can return it.
                MatchedWord matchedWord = new MatchedWord();



                //return matchedWord;
                return new MatchedWord();  // Delete this line when done.
            }



            return matchedWords;
        }
    }
}





