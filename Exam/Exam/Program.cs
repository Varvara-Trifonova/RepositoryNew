using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int limit = 10000000; 
            List<int> primes = GetPrimes(limit); 
            int semiPrimeCount = 0;

            for (int i = 0; i < primes.Count; i++)
            {
                for (int j = i; j < primes.Count; j++)
                {
                    long semiPrime = (long)primes[i] * primes[j];
                    if (semiPrime < limit)
                    {
                        semiPrimeCount++;
                    }
                    else
                    {
                        break; 
                    }
                }
            }

            Console.WriteLine($"Количество полупростых чисел, меньших {limit}: {semiPrimeCount}");
            Console.ReadKey();
        }

        static List<int> GetPrimes(int limit)
        {
            bool[] isPrime = new bool[limit + 1];
            for (int i = 2; i <= limit; i++) isPrime[i] = true;

            for (int i = 2; i * i <= limit; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            List<int> primes = new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
    }
}
