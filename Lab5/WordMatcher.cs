using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWords2 in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    if (scrambledWords2.Equals(word))
                    {
                        MatchedWord matchedWord = BuildMatchedWord(scrambledWords2, word);
                        matchedWords.Add(matchedWord);
                    }

                    return matchedWords;

                }




                // Implement code here.
                // Work with "scrambledWords" and "matchedWords".

                MatchedWord BuildMatchedWord(string scrambledWord, string word)
                {
                    // Build a matched-word object here, so that you can return it.
                    MatchedWord matchedWord = new MatchedWord();



                    //return matchedWord;
                    return new MatchedWord();  // Delete this line when done.
                }


            }
            return matchedWords;
        }
       
    }
}



