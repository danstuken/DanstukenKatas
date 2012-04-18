namespace StringCalculator.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    public class StringCalculatorExpression
    {
        private string _expression;
        private char[] _tokenDelimeter = { ',', '\n' };

        public StringCalculatorExpression(string expression)
        {
            _expression = expression;
        }

        public IEnumerable<string> Tokenise()
        {
            if(ExpressionIsEmpty())
                return new string[] {};

            if (ExpressionSpecifiesDelimiter())
            {
                SetTokenDelimeterFromExpression();
                StripDelimiterSpecificationHeader();
            }

            return _expression.Split(_tokenDelimeter);
        }

        private void SetTokenDelimeterFromExpression()
        {
            _tokenDelimeter = _expression.Skip(2).Take(1).ToArray();
        }

        private void StripDelimiterSpecificationHeader()
        {
            _expression = new string(_expression.Skip(4).ToArray());
        }

        private bool ExpressionIsEmpty()
        {
            return string.IsNullOrEmpty(_expression);
        }

        private bool ExpressionSpecifiesDelimiter()
        {
            return _expression.StartsWith("//");
        }
    }
}