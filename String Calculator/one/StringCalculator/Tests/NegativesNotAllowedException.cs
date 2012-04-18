namespace StringCalculator.Tests
{
    using System;
    using System.Collections.Generic;

    internal class NegativesNotAllowedException: Exception
    {
        public NegativesNotAllowedException(IEnumerable<int> negatives)
            :base("Negatives not allowed: " + string.Join(",", negatives))
        {
        }
    }
}