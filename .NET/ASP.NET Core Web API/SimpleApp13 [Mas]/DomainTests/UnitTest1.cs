using Domain.ValueObjects;
using Xunit.Abstractions;

namespace DomainTests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void Age_Correct()
        {
            var minAge = 18;
            var birthdate = DateTime.Now.AddYears(-minAge);

            var age = new Age(birthdate, minAge);
            _output.WriteLine(message: $"Y: {age.Years}, M: {age.Months}, D: {age.Days}");


            Assert.Equal(minAge, age.Years);
        }

        [Fact]
        public void Age_Incorrect()
        {
            var minAge = 18;
            var birthdate = DateTime.Now.AddYears(-minAge).AddDays(1);

            Assert.Throws<Exception>(() => new Age(birthdate, minAge));
        }

        [Theory]
        [InlineData("1234567891")]
        [InlineData("1234567893")]
        [InlineData("1234567892")]
        public void Nip_Correct(string nip)
        {

            var result = new Nip(nip);

            Assert.Equal(nip, result.Value);
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("12345678935")]
        [InlineData("")]
        public void Nip_Incorrect(string nip)
        {
            Assert.Throws<Exception>(() => new Nip(nip));
        }
        [Theory]
        [InlineData("12345678911")]
        [InlineData("12345678935")]
        public void Pesel_Incorrect(string pesel)
        {
            var result = new Pesel(pesel);

            Assert.Equal(pesel, result.Value);
        }


    }
}