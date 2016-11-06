using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slab5
{
    class Change
    {
        BigInteger P, Q, funE;
        Random rand = new Random();       

        public BigInteger glKey { get; set; }

        public BigInteger prKey { get; set; }

        public BigInteger pubKey { get; set; }      
        
        public void CreateKey()
        {
            P = EncrypRSA.findSimpl(rand);
            Q = EncrypRSA.findSimpl(rand, 100, 200);
            glKey = P * Q;
            funE = (P - 1) * (Q - 1);

            prKey = EncrypRSA.findprKey(funE);
            pubKey = EncrypRSA.findpubKey(prKey, funE);
        }

        public string encryp(string str)
        {
            BigInteger[] Input_str = new BigInteger[str.Length];

            for (int i = 0; i < str.Length; i++)               
                Input_str[i] = myPow(str[i], pubKey, glKey);

                string Result_str = new string(Input_str.Select(o => (char)o).ToArray());

            return Result_str;            
        }

        public string decryp(string str)
        {
            BigInteger[] Input_str = new BigInteger[str.Length];

            for (int i = 0; i < str.Length; i++)
                Input_str[i] = myPow(str[i], prKey, glKey);

            string Result_str = new string(Input_str.Select(o => (char)o).ToArray());

            return Result_str;
        }
        
        public BigInteger myPow(long x, BigInteger y, BigInteger k)
        {
            BigInteger num = new BigInteger(1);

            for (int i = 0; i < y; i++)
                num *= x % k;

            return num % k;
        }

    }
}
