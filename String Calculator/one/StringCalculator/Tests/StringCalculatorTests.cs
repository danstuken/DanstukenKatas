namespace StringCalculator.Tests
{
    using NUnit.Framework;
    using Shouldly;

    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void InitialiseStringCalculator()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void AddingEmptyStringReturns0()
        {
            var result = _stringCalculator.Add(string.Empty);

            result.ShouldBe(0);
        }

        [Test]
        public void AddingSingleValueOf1Returns1()
        {
            var result = _stringCalculator.Add("1");

            result.ShouldBe(1);
        }

        [Test]
        public void AddingTwoValuesSumsThoseValues()
        {
            var result = _stringCalculator.Add("0,0");

            result.ShouldBe(0);
        }

        [Test]
        public void AddingThreeValuesSumsThoseValues()
        {
            var result = _stringCalculator.Add("0,1,2");

            result.ShouldBe(3);
        }

        [Test]
        public void AddingNumbersSeparatedByNewLinesSumsThoseValues()
        {
            var result = _stringCalculator.Add("1\n2");

            result.ShouldBe(3);
        }

        [Test]
        public void AddingNumbersSeparatedByMultipleSeparatorsSumsThoseValues()
        {
            var result = _stringCalculator.Add("1,2\n3");

            result.ShouldBe(6);
        }

        [Test]
        public void AddingNumbersSeparatedBySpecifiedDelimeterSumsThoseNumbers()
        {
            var result = _stringCalculator.Add("//.\n1.2.3");

            result.ShouldBe(6);
        }

        [Test]
        public void AdddingNumbersSeparatedBySpecifiedNewLineSumsThoseNumbers()
        {
            var result = _stringCalculator.Add("//\n\n1\n5");

            result.ShouldBe(6);
        }

        [Test]
        [ExpectedException(typeof(NegativesNotAllowedException))]
        public void CallingAddWithANegativeNumberThrowsNegativesNotAllowedException()
        {
            var result = _stringCalculator.Add("-1");
        }

        [Test]
        public void CallingAddWithANegativeNumberThrowsAnExceptionThatListsTheNegativeNumber()
        {
            try
            {
                var result = _stringCalculator.Add("-1");
            }
            catch(NegativesNotAllowedException e)
            {
                e.Message.ShouldBe("Negatives not allowed: -1");
            }
        }

        [Test]
        public void CallingAddWithMoreThanOneNegativeNumberThrowsAnExceptionThatListsAllTheNegativeNumbers()
        {
            try
            {
                var result = _stringCalculator.Add("-1,2,-3");
            }
            catch(NegativesNotAllowedException e)
            {
                e.Message.ShouldBe("Negatives not allowed: -1,-3");
            }
        }

        [Test]
        public void CallingAddWithMoreThanOneNegativeNumberAndSpecifiedDelimeterThrowsAnExceptionThatListsAllTheNegativeNumbers()
        {
            try
            {
                var result = _stringCalculator.Add("//.\n-1.2.-3");
            }
            catch(NegativesNotAllowedException e)
            {
                e.Message.ShouldBe("Negatives not allowed: -1,-3");
            }
        }
    }
}