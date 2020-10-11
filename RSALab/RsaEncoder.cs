using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSALab
{
    class RsaEncoder
    {
        public Keys GenerateKeys(int p, int q)
        {
            int n = p * q;

            int euler = (p - 1) * (q - 1);

            int e = 0;

            int d = 11;

            e = FindInverseElement(d, euler);

            return new Keys
            {
                DSecretKey = d,
                EOpenKey = e,
                NOpenKey = n,
                NSecretKey = n
            };
        }

        public string Encode(string inputText, Keys key)
        {
            var listChars = ConvertTextToNumbers(inputText).ToList();
            listChars.ForEach(el=> Console.Write(el+" "));
            var encryptedText = new string(ConvertTextToNumbers(inputText).Select(symbol => (char)FastPowFunc(symbol, key.EOpenKey, key.NOpenKey)).ToArray());
            return encryptedText;
        }

        public string Decode(string inputText, Keys key)
        {
            var decryptedText = ConvertNumbersToText(inputText.Select(symbol => (int)FastPowFunc(symbol, key.DSecretKey, key.NOpenKey)));
            return decryptedText;
        }


        private static int FastPowFunc(int number, int pow, int mod)
        {
            int power = 1;
            int bit = number % mod;

            while (pow > 0)
            {
                if ((pow & 1) == 1)
                {
                    power *= bit;
                    power %= mod;
                }

                bit *= bit;
                bit %= mod;
                pow >>= 1;
            }

            return power;
        }

        private static IEnumerable<int> ConvertTextToNumbers(string text)
        {
            return text.Select(symbol =>
            {
                if (symbol == ' ')
                    return 35;
                else
                {
                    return symbol - 1070;
                }
            });
        }

        private static string ConvertNumbersToText(IEnumerable<int> numbers)
        {
            return new string(numbers.Select(number =>
            {
                if (number == 35)
                    return ' ';
                else
                {
                    return (char)(number + 1070);
                }
            }).ToArray());
        }

        private static bool IsPrimeNumber(int n)
        {
            var result = true;

            if (n > 1)
            {
                for (var i = 2u; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        private static bool IsCoprime(int a, int b)
        {
            return a == b
                ? a == 1
                : a > b
                    ? IsCoprime(a - b, b)
                    : IsCoprime(b - a, a);
        }

        private int FindInverseElement(int baseNumber, int module)
        {
            int x, y;
            int g = CalculateGcdExtended(baseNumber, module, out x, out y);
            return (x % module + module) % module;
        }

        private int CalculateGcdExtended(int a, int b, out int x, out int y)
        {
            if (a == 0)
            {
                x = 0; y = 1;
                return b;
            }

            int x1, y1;
            int d = CalculateGcdExtended(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }
    }
}
