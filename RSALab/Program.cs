using System;

namespace RSALab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RsaEncoder encoder = new RsaEncoder();
            var keys = encoder.GenerateKeys(3, 19);
            var encodedMessage = encoder.Encode("сачек денис николаевич", keys);
            var decodedMessage = encoder.Decode(encodedMessage, keys);
        }
    }
}
