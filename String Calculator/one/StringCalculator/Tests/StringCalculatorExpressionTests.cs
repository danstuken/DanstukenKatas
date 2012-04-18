namespace StringCalculator.Tests
{
    using NUnit.Framework;
    using Shouldly;

    [TestFixture]
    public class StringCalculatorExpressionTests
    {

        [Test]
        public void StringCalculatorExpressionShouldTokeniseToEmptyEnumerationWhenEmptyStringProvided()
        {
            var stringCalculatorExpression = new StringCalculatorExpression(string.Empty);

            var tokens = stringCalculatorExpression.Tokenise();

            tokens.ShouldBeEmpty();
        }

        [Test]
        public void StringCalculatorExpressionShouldTokeniseToInputStringWhenNoDelimeterUsed()
        {
            var expression = new StringCalculatorExpression("1");

            var tokens = expression.Tokenise();

            tokens.ShouldBe(new[] { "1" });
        }

        [Test]
        public void StringCalculatorExpressionShouldSplitTokensByCommaByDefault()
        {
            var stringCalculatorExpression = new StringCalculatorExpression("1,2");

            var tokens = stringCalculatorExpression.Tokenise();

            tokens.ShouldBe(new[] { "1", "2" });
        }

        [Test]
        public void StringCalculatorExpressionSplitsTokensByCommaOrNewLineByDefault()
        {
            var stringCalculatorExpression = new StringCalculatorExpression("1,2\n3");

            var tokens = stringCalculatorExpression.Tokenise();

            tokens.ShouldBe(new[] { "1", "2", "3" });
        }

        [Test]
        public void StringCalculatorExpressionSplitsSingleTokensWhenDelimeterSpecified()
        {
            var stringCalculatorExpression = new StringCalculatorExpression("//.\n1");

            var tokens = stringCalculatorExpression.Tokenise();

            tokens.ShouldBe(new[] { "1" });
        }

        [Test]
        public void StringCalculatorExpressionSplitsTokensBySpecifiedDelimeter()
        {
            var stringCalculatorExpression = new StringCalculatorExpression("//$\n1$3$5");

            var tokens = stringCalculatorExpression.Tokenise();

            tokens.ShouldBe(new[] { "1", "3", "5" });
        }
    }
}