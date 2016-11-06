using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slab5
{
    class Change : IRSAEncryptor
    {
        BigInteger P, Q, funE;
        Random rand = new Random();       

        public BigInteger GlobalKey { get; set; }

        public BigInteger PrivateKey { get; set; }

        public BigInteger PublicKey { get; set; }      
        
        public void CreateKey()
        {
            P = EncrypRSA.findSimpl(rand);
            Q = EncrypRSA.findSimpl(rand, 100, 200);
            GlobalKey = P * Q;
            funE = (P - 1) * (Q - 1);

            PrivateKey = EncrypRSA.findprKey(funE);
            PublicKey = EncrypRSA.findpubKey(PrivateKey, funE);
        }

        public string Encryp(string str)
        {
            BigInteger[] Input_str = new BigInteger[str.Length];

            for (int i = 0; i < str.Length; i++)               
                Input_str[i] = MyPow(str[i], PublicKey, GlobalKey);

                string Result_str = new string(Input_str.Select(o => (char)o).ToArray());

            return Result_str;            
        }

        public string Decryp(string str)
        {
            BigInteger[] Input_str = new BigInteger[str.Length];

            for (int i = 0; i < str.Length; i++)
                Input_str[i] = MyPow(str[i], PrivateKey, GlobalKey);

            string Result_str = new string(Input_str.Select(o => (char)o).ToArray());

            return Result_str;
        }
        
        private BigInteger MyPow(long x, BigInteger y, BigInteger k)
        {
            BigInteger num = new BigInteger(1);

            for (int i = 0; i < y; i++)
                num *= x % k;

            return num % k;
        }

    }
}
