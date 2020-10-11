using System;

namespace RSALab
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "сачек денис";
            Console.WriteLine(str);
            RsaEncoder encoder = new RsaEncoder();
            var keys = encoder.GenerateKeys(7, 17);
            var encodedMessage = encoder.Encode(str, keys);
            Console.WriteLine($"Открытый ключ: {keys.EOpenKey} , {keys.NOpenKey}. Секретный ключ: {keys.DSecretKey} , {keys.NSecretKey}");
            Console.WriteLine("Зашифрованая строка:" + encodedMessage);
            var decodedMessage = encoder.Decode(encodedMessage, keys);
            Console.WriteLine("Расшифрованная строка:" + decodedMessage);
        }
    }
}
