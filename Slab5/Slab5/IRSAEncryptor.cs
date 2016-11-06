using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Slab5
{
    public interface IRSAEncryptor
    {
        string Encryp(string str);
        string Decryp(string str);
        void CreateKey();

        BigInteger GlobalKey { get; set; }
        BigInteger PrivateKey { get; set; }
        BigInteger PublicKey { get; set; }

    }
}
