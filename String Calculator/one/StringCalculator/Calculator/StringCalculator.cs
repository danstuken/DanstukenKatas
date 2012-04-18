namespace StringCalculator.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    public class StringCalculator
    {
        private StringCalculatorExpression _expression;

        public int Add(string numbers)
        {
            _expression = new StringCalculatorExpression(numbers);

            VerifyInputNumbersArePositive();

            return TokenisedExpression.Sum();
        }

        private void VerifyInputNumbersArePositive()
        {
            var negatives = TokenisedExpression.Where(t => t < 0);
            if (negatives.Any())
            {
                throw new NegativesNotAllowedException(negatives);
            }
        }

        private IEnumerable<int> TokenisedExpression
        {
            get
            {
                return _expression.Tokenise().Select(int.Parse);
            }
        }
    }
}