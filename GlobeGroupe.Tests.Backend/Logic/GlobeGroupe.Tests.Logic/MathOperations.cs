using System.Numerics;

namespace GlobeGroupe.Tests.Logic;

public static class MathOperations
{
    /// <summary>
    ///     return the value of n!
    /// </summary>
    /// <param name="n">positive number</param>
    /// <returns></returns>
    public static BigInteger GetFactorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("n mus be a positive number");
        }

        BigInteger result = 1;
        for (int i = n; i > 1; i--)
        {
            result *= i;
        }
        return result;
    }
}
