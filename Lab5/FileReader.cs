using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {

        public bool Read(String filename, out string[] outList)
        {
            bool check = true;

            try
            {
                outList = File.ReadAllLines(filename);
                return true;
            }catch (Exception ex)
            {
                outList = null;
                return false;
            }
        }

    }
}
