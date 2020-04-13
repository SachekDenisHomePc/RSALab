using System;

namespace RSALab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начальная строка: сачек денис николаевич");
            RsaEncoder encoder = new RsaEncoder();
            var keys = encoder.GenerateKeys(3, 19);
            var encodedMessage = encoder.Encode("сачек денис николаевич", keys);
            Console.WriteLine($"Открытый ключ: {keys.EOpenKey} , {keys.NOpenKey}. Секретный ключ: {keys.DSecretKey} , {keys.NSecretKey}");
            Console.WriteLine("Зашифрованая строка:" + encodedMessage);
            var decodedMessage = encoder.Decode(encodedMessage, keys);
            Console.WriteLine("Расшифрованная строка:" + decodedMessage);
        }
    }
}
