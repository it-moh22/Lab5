using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    struct MatchedWord
    {
        public string ScrambledWord { get; set; }
        public string Word { get; set; }

        public bool IsMatch { get; set; } // added this tho get a result of true/false for our display
    }
}
